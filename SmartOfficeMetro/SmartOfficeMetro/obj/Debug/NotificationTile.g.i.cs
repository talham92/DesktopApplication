﻿#pragma checksum "..\..\NotificationTile.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B023DD89F32BEC9D254C62DB00868143"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SmartOfficeMetro;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace SmartOfficeMetro {
    
    
    /// <summary>
    /// NotificationTile
    /// </summary>
    public partial class NotificationTile : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\NotificationTile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid TileRow;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\NotificationTile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer descriptionPanel;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\NotificationTile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textDescription;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\NotificationTile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelHeader;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\NotificationTile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelTime;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\NotificationTile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelSender;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\NotificationTile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle highligter;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\NotificationTile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonFetch;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SmartOfficeMetro;component/notificationtile.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\NotificationTile.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.TileRow = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.descriptionPanel = ((System.Windows.Controls.ScrollViewer)(target));
            
            #line 21 "..\..\NotificationTile.xaml"
            this.descriptionPanel.ScrollChanged += new System.Windows.Controls.ScrollChangedEventHandler(this.descriptionPanel_ScrollChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.textDescription = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.labelHeader = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.labelTime = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.labelSender = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.highligter = ((System.Windows.Shapes.Rectangle)(target));
            
            #line 34 "..\..\NotificationTile.xaml"
            this.highligter.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.LabelHeader_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 8:
            this.buttonFetch = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

