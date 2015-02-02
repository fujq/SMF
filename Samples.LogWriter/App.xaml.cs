using Microsoft.SilverlightMediaFramework.Core;
using Microsoft.SilverlightMediaFramework.Core.Media;
using Microsoft.SilverlightMediaFramework.Plugins.Primitives;
using Microsoft.SilverlightMediaFramework.Utilities.Extensions;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Browser;

namespace Microsoft.SilverlightMediaFramework.Samples.LogWriter
{
    public partial class App : Application
    {
        private string strUri = "http://e0.vdowowza.hk3.tvb.com/vod/_definst_/smil:XBOX_TEST/XBOX.smil/Manifest";
        private string strToken;

        private SMFPlayer player;

        public App()
        {
            this.Startup += this.Application_Startup;
            this.Exit += this.Application_Exit;
            this.UnhandledException += this.Application_UnhandledException;

            InitializeComponent();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            player = new SMFPlayer();

            if (e.InitParams != null)
            {
                if (!e.InitParams.ContainsKeyIgnoreCase(SupportedInitParams.DeliveryMethod))
                {
                    e.InitParams.Add(SupportedInitParams.DeliveryMethod, DeliveryMethods.AdaptiveStreaming.ToString());
                }

                player.LoadInitParams(e.InitParams);
                player.PlaylistVisibility = player.Playlist != null && player.Playlist.Count > 1
                                         ? FeatureVisibility.Hidden
                                         : FeatureVisibility.Disabled;

                player.CaptionsVisibility = e.InitParams.ContainsKeyIgnoreCase(SupportedInitParams.SelectedCaptionStream)
                                        ? FeatureVisibility.Visible
                                        : FeatureVisibility.Disabled;
            }

            Token myToken = new Token();
            myToken.OnCompleted += new Token.DownloadStringCompletedHandler(AddTestClip);
            myToken.PostRequest();

            player.AutoPlay = true;

 //         player.LogWriters = "LogWriterExampleId";
 //         player.LogLevel = LogLevel.All;

            this.RootVisual = player;
            //this.RootVisual = new MainPage();

            HtmlDocument doc = HtmlPage.Document;

            // Hook up the simple JavaScript method HTML button.
            doc.GetElementById("btnGetToken").AttachEvent("click",
                                new EventHandler(this.CallGlobalJSMethod));
        }

        private void Application_Exit(object sender, EventArgs e)
        {

        }

        private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            // If the app is running outside of the debugger then report the exception using
            // the browser's exception mechanism. On IE this will display it a yellow alert 
            // icon in the status bar and Firefox will display a script error.
            if (!System.Diagnostics.Debugger.IsAttached)
            {

                // NOTE: This will allow the application to continue running after an exception has been thrown
                // but not handled. 
                // For production applications this error handling should be replaced with something that will 
                // report the error to the website and stop the application.
                e.Handled = true;
                Deployment.Current.Dispatcher.BeginInvoke(delegate { ReportErrorToDOM(e); });
            }
        }

        private void ReportErrorToDOM(ApplicationUnhandledExceptionEventArgs e)
        {
            try
            {
                string errorMsg = e.ExceptionObject.Message + e.ExceptionObject.StackTrace;
                errorMsg = errorMsg.Replace('"', '\'').Replace("\r\n", @"\n");

                System.Windows.Browser.HtmlPage.Window.Eval("throw new Error(\"Unhandled Error in Silverlight Application " + errorMsg + "\");");
            }
            catch (Exception)
            {
            }
        }

        private void CallGlobalJSMethod(object o, EventArgs e)
        {
            HtmlPage.Window.Invoke("globalJSMethod", strUri, strToken);
        }

        private void AddTestClip(object sender, Token e)
        {
            var playlist = new ObservableCollection<PlaylistItem>();
            var playlistItem = new PlaylistItem
            {
                MediaSource = new Uri(strUri)
            };

            strToken = e.strToken;

            playlistItem.Title = "Title";
            playlistItem.Description = "Description";

            playlistItem.DeliveryMethod = DeliveryMethods.AdaptiveStreaming;
            
            if (strToken != null && !strToken.Equals("") && !strToken.Equals("undifined"))
            {
                playlistItem.BearerToken = strToken;
            }

            playlist.Add(playlistItem);
            foreach (var item in playlist)
            {
                if (!String.IsNullOrWhiteSpace(item.BearerToken))
                {
                    item.LicenseAcquirer =
                        new Microsoft.SilverlightMediaFramework.Core.AMSTokenAuthentication.AMSBearerTokenLicenseAcquirer()
                        {
                            AddAuthorizationToken = true,
                            Token = item.BearerToken
                        };
                }
            }

            player.Playlist = playlist;

        }
    }
}
