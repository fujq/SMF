using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.SilverlightMediaFramework.Core;

namespace Samples.Advertising
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (player == null) return;
            string state = (sender as RadioButton).Content.ToString();
            var visibility = (FeatureVisibility)Enum.Parse(typeof(FeatureVisibility), state, true);
            player.LoggingConsoleVisibility = visibility;
        }

    }
}
