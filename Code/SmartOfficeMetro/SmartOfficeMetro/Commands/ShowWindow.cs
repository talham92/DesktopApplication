using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
namespace SmartOfficeMetro.Commands
{
    public class ShowWindow : CommandBase<ShowWindow>
    {
        public override void Execute(object parameter)
        {
            MetroWindow window = Application.Current.MainWindow as MetroWindow;
            Window win = GetTaskbarWindow(parameter);
            if (!win.IsVisible)
            {
                
                window.Show();
                window.BringIntoView();
                window.WindowState = WindowState.Maximized;
                //CommandManager.InvalidateRequerySuggested();
            }
            else
            {
                window.Hide();
            }
        }


        public override bool CanExecute(object parameter)
        {
            MetroWindow window = Application.Current.MainWindow as MetroWindow;
            Window win = GetTaskbarWindow(parameter);
            return window != null && !window.IsVisible;
        }
    }
}

