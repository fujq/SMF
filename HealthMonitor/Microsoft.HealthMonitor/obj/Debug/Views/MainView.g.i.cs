﻿#pragma checksum "\\psf\Home\Documents\Visual Studio 2013\Projects\microsoft-smf-src-3\HealthMonitor\Microsoft.HealthMonitor\Views\MainView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0A847EB1F99AC2B6077A3D3B472F0AE3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.HealthMonitorPlayer.Views;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Microsoft.HealthMonitor.Views {
    
    
    public partial class MainView : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.DataGrid TraceGrid;
        
        internal System.Windows.Controls.Button buttonCapture;
        
        internal System.Windows.Controls.ContentControl playerFrame;
        
        internal Microsoft.HealthMonitorPlayer.Views.Player Player;
        
        internal System.Windows.Controls.TextBox TextStreamUrl;
        
        internal System.Windows.Controls.Button ButtonPlay;
        
        internal System.Windows.Controls.AutoCompleteBox TextPlayerId;
        
        internal System.Windows.Controls.Button ButtonConnect;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/Microsoft.HealthMonitor;component/Views/MainView.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.TraceGrid = ((System.Windows.Controls.DataGrid)(this.FindName("TraceGrid")));
            this.buttonCapture = ((System.Windows.Controls.Button)(this.FindName("buttonCapture")));
            this.playerFrame = ((System.Windows.Controls.ContentControl)(this.FindName("playerFrame")));
            this.Player = ((Microsoft.HealthMonitorPlayer.Views.Player)(this.FindName("Player")));
            this.TextStreamUrl = ((System.Windows.Controls.TextBox)(this.FindName("TextStreamUrl")));
            this.ButtonPlay = ((System.Windows.Controls.Button)(this.FindName("ButtonPlay")));
            this.TextPlayerId = ((System.Windows.Controls.AutoCompleteBox)(this.FindName("TextPlayerId")));
            this.ButtonConnect = ((System.Windows.Controls.Button)(this.FindName("ButtonConnect")));
        }
    }
}

