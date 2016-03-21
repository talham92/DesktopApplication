using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace SmartOfficeServer.Model
{
    class DBConnect
    {
        private MySqlConnection connection = null;
        //private MySqlDataReader reader = null;
        private String server;
        private String port;
        private String username;
        private String password;
        private String database;
        public DBConnect()
        {
            Initialize();
        }

        private void Initialize()
        {
            server = "localhost";
            database = "smartoffice";
            username = "root";
            password = "123";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + username + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
           catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
        }

        //Close connection
        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch(MySqlException e)
            {
                switch(e.Number)
                {
                    case 0:
                        Console.WriteLine("Unable to establish connection, Contact Admin/Check connection");
                        break;
                    case 1045:
                        Console.WriteLine("Invalid username/password!");
                        break;
                }
                return false;
            }//catch
            
        }//close connection

        //Insert statement
        public Boolean Insert(String tablename, String columns,List<String> args)
        {
            String query = "Insert into " + tablename + " (" + columns + ") values (";
            query += string.Join(",", args);
            /*foreach(String value in args)
            {
                //query += value + ",";
                query.Join(",", value);
            }*/
            query += ");";
            Console.WriteLine(query);
                    
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch(MySqlException e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Message);
                return false;
            }
            
        }

        //Update statement
        public Boolean Update(String tablename, String oldArg, String newArg, String condition)
        {
            String query = "";
            switch (tablename.ToLower())
            {
                case "user":
                    query = "Update user set " + oldArg + " = " + newArg + " where " + condition + ";";
                    break;
                case "delivery":
                    query = "Update delivery set " + oldArg + " = " + newArg + " where " + condition + ";";
                    break;
            }//switch
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Message);
                return false;
            }
        }


        //Delete statement
        public Boolean Delete(String tablename, String condition)
        {
            String query = "";
            switch (tablename.ToLower())
            {
                case "user":
                    query = "Delete from user where "  + condition + ";";
                    break;
                case "delivery":
                    query = "Delete from delivery where "  + condition + ";";
                    break;
            }//switch
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Message);
                return false;
            }
        }

        //Select statement
        /// <summary>
        /// executes a select query on the given table with the given condition that returns an object of the
        /// form List<List<string>> where the outer list is rows, and inner list is column data
        /// </summary>
        /// <param name="tablename"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public List<List<String>> SelectAll(String tablename,String columns, String condition)
        {
            String query = "";
            List<List<String>> returnData = new List<List<String>>();
            List<String> row = null;
            query = "Select " + columns + " from " + tablename + " where " + condition + ";";
            MySqlDataReader reader;
            try
            {
                //create and execute command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    reader.Close();
                    return null;    //no data found
                }
                while (reader.Read())
                {
                    row = new List<string>();
                    for (int i = 0; i <= 8; i++)
                    {
                        try
                        {
                            row.Add(reader[i].ToString());
                        }
                        catch(Exception e) { break; } //array out of bounds. when returned rows are less than 8
                    }//end for                           // nothing serioes and we can ignore
                    returnData.Add(row);
                }//end while

                reader.Close();
                return returnData;


                /*
                               else if(tablename.ToLower() == "delivery")
                                {
                                    if (!reader.HasRows)
                                    {
                                        reader.Close();
                                        return null;    //no data found
                                    }
                                    while (reader.Read())
                                    {
                                        row = new List<string>();
                                        for (int i = 0; i <= 6; i++)
                                        {
                                            row.Add(reader[i].ToString());
                                        }
                                        returnData.Add(row);
                                    }//end while
                                }//end elseif
                                else if (tablename.ToLower() == "notification")
                                {
                                    if (!reader.HasRows)
                                    {
                                        reader.Close();
                                        return null;    //no data found
                                    }

                                    while (reader.Read())
                                    {
                                        row = new List<string>();
                                        for (int i = 0; i <= 5; i++)
                                        {
                                            row.Add(reader[i].ToString());
                                        }
                                        returnData.Add(row);
                                    }//end while
                                }//end elseif
                */

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Message);
                return null;
            }
        }//end selectAll

        //Can be used to handle custom/complex queries
        public MySqlConnection getConnection()
        {
            return connection;
        }





    }//class
}//namespace
