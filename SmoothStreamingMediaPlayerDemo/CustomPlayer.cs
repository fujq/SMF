using Microsoft.SilverlightMediaFramework.Core;
using Microsoft.Web.Media.SmoothStreaming;
using System.Windows;

namespace SmoothStreamingMediaPlayerDemo
{
    public class CustomPlayer : SMFPlayer
    {
        protected override void OnMediaOpened()
        {
            base.OnMediaOpened();

            SmoothStreamingMediaElement ssme = ActiveMediaPlugin.VisualElement as SmoothStreamingMediaElement;

            if (ssme != null)
            {
                MessageBox.Show("Accessed the SmoothStreamingMediaElement");
            }
        }
    }
}
