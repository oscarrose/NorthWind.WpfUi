﻿#pragma checksum "..\..\..\..\UserControlDesign\UserControlRegion.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "01C047B0007DC80C0E82AF90EA500988AD098162"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MahApps.Metro;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MaterialDesignThemes.MahApps;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using NorthWind.WpfUi;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace NorthWind.WpfUi {
    
    
    /// <summary>
    /// UserControlRegion
    /// </summary>
    public partial class UserControlRegion : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\..\UserControlDesign\UserControlRegion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.Transitions.TransitioningContent TrainsitionOfCOnteent;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\UserControlDesign\UserControlRegion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox InputRegionDescription;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\UserControlDesign\UserControlRegion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock RegionDescriptionError;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\..\UserControlDesign\UserControlRegion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveRegionButton;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\..\UserControlDesign\UserControlRegion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EditRegionButton;
        
        #line default
        #line hidden
        
        
        #line 106 "..\..\..\..\UserControlDesign\UserControlRegion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteRegionButton;
        
        #line default
        #line hidden
        
        
        #line 139 "..\..\..\..\UserControlDesign\UserControlRegion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGridRegion;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.6.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/NorthWind.WpfUi;component/usercontroldesign/usercontrolregion.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UserControlDesign\UserControlRegion.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.6.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.TrainsitionOfCOnteent = ((MaterialDesignThemes.Wpf.Transitions.TransitioningContent)(target));
            return;
            case 2:
            this.InputRegionDescription = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.RegionDescriptionError = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.SaveRegionButton = ((System.Windows.Controls.Button)(target));
            
            #line 68 "..\..\..\..\UserControlDesign\UserControlRegion.xaml"
            this.SaveRegionButton.Click += new System.Windows.RoutedEventHandler(this.SaveRegionButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.EditRegionButton = ((System.Windows.Controls.Button)(target));
            return;
            case 6:
            this.DeleteRegionButton = ((System.Windows.Controls.Button)(target));
            return;
            case 7:
            this.DataGridRegion = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

