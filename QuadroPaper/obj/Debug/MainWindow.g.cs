﻿#pragma checksum "..\..\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4E77CB7DED3F8B107B1E40CD3D88F57847BDE18AC8BC6BE4B45BD4C51B291C2C"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using QuadroPaper;
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


namespace QuadroPaper {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Navigation.NavigationWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid mainGrid;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TB_Search;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox SortCB;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox FilterCB;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView LV;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PrevPageButton;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Button1;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Button2;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Button3;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Button4;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button NextPageButton;
        
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
            System.Uri resourceLocater = new System.Uri("/QuadroPaper;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
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
            
            #line 8 "..\..\MainWindow.xaml"
            ((QuadroPaper.MainWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.DB_Load);
            
            #line default
            #line hidden
            return;
            case 2:
            this.mainGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.TB_Search = ((System.Windows.Controls.TextBox)(target));
            
            #line 20 "..\..\MainWindow.xaml"
            this.TB_Search.GotFocus += new System.Windows.RoutedEventHandler(this.TB_GotFocus);
            
            #line default
            #line hidden
            
            #line 20 "..\..\MainWindow.xaml"
            this.TB_Search.LostFocus += new System.Windows.RoutedEventHandler(this.TB_LostFocus);
            
            #line default
            #line hidden
            
            #line 20 "..\..\MainWindow.xaml"
            this.TB_Search.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TB_Search_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.SortCB = ((System.Windows.Controls.ComboBox)(target));
            
            #line 24 "..\..\MainWindow.xaml"
            this.SortCB.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.SortCB_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.FilterCB = ((System.Windows.Controls.ComboBox)(target));
            
            #line 35 "..\..\MainWindow.xaml"
            this.FilterCB.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.FilterCB_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.LV = ((System.Windows.Controls.ListView)(target));
            return;
            case 7:
            this.PrevPageButton = ((System.Windows.Controls.Button)(target));
            
            #line 67 "..\..\MainWindow.xaml"
            this.PrevPageButton.Click += new System.Windows.RoutedEventHandler(this.PrevPageButtonClick);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Button1 = ((System.Windows.Controls.TextBlock)(target));
            
            #line 68 "..\..\MainWindow.xaml"
            this.Button1.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.ButtonPageClick);
            
            #line default
            #line hidden
            return;
            case 9:
            this.Button2 = ((System.Windows.Controls.TextBlock)(target));
            
            #line 69 "..\..\MainWindow.xaml"
            this.Button2.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.ButtonPageClick);
            
            #line default
            #line hidden
            return;
            case 10:
            this.Button3 = ((System.Windows.Controls.TextBlock)(target));
            
            #line 70 "..\..\MainWindow.xaml"
            this.Button3.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.ButtonPageClick);
            
            #line default
            #line hidden
            return;
            case 11:
            this.Button4 = ((System.Windows.Controls.TextBlock)(target));
            
            #line 71 "..\..\MainWindow.xaml"
            this.Button4.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.ButtonPageClick);
            
            #line default
            #line hidden
            return;
            case 12:
            this.NextPageButton = ((System.Windows.Controls.Button)(target));
            
            #line 72 "..\..\MainWindow.xaml"
            this.NextPageButton.Click += new System.Windows.RoutedEventHandler(this.NextPageButtonClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
