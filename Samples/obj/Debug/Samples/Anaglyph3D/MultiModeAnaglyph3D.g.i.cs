﻿#pragma checksum "\\psf\Home\Documents\Visual Studio 2013\Projects\microsoft-smf-src-3\Samples\Samples\Anaglyph3D\MultiModeAnaglyph3D.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D08403EA4ACD76582598DEB4413195BA"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.SilverlightMediaFramework.Core;
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


namespace Microsoft.SilverlightMediaFramework.Samples.Samples.Anaglyph3D {
    
    
    public partial class MultiModeAnaglyph3D : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.ComboBox PluginSelector;
        
        internal System.Windows.Controls.ComboBox AnaglyphModeSelector;
        
        internal System.Windows.Controls.ComboBox StretchModeSelector;
        
        internal Microsoft.SilverlightMediaFramework.Core.SMFPlayer smfPlayer;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Microsoft.SilverlightMediaFramework.Samples;component/Samples/Anaglyph3D/MultiMo" +
                        "deAnaglyph3D.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.PluginSelector = ((System.Windows.Controls.ComboBox)(this.FindName("PluginSelector")));
            this.AnaglyphModeSelector = ((System.Windows.Controls.ComboBox)(this.FindName("AnaglyphModeSelector")));
            this.StretchModeSelector = ((System.Windows.Controls.ComboBox)(this.FindName("StretchModeSelector")));
            this.smfPlayer = ((Microsoft.SilverlightMediaFramework.Core.SMFPlayer)(this.FindName("smfPlayer")));
        }
    }
}
