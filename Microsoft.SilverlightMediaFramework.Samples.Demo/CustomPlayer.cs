using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.SilverlightMediaFramework.Core;
using Microsoft.Web.Media.SmoothStreaming;

namespace Microsoft.SilverlightMediaFramework.Samples.Demo
{
    public class CustomPlayer : SMFPlayer
    {
        protected override void OnMediaOpened()
        {
            base.OnMediaOpened();

            SmoothStreamingMediaElement player = ActiveMediaPlugin.VisualElement as SmoothStreamingMediaElement;

        }
    }
}
