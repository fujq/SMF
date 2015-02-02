using Microsoft.SilverlightMediaFramework.Core;
using Microsoft.SilverlightMediaFramework.Core.Media;
using Microsoft.SilverlightMediaFramework.Plugins.Primitives;
using Microsoft.SilverlightMediaFramework.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Browser;

namespace Microsoft.SilverlightMediaFramework.Samples.Demo
{
    public partial class App : Application
    {
        private string strUri0 = "";//http://e0.vdowowza.hk3.tvb.com/visualon/mp4:visualon/setb5/000000338933.mp4/Manifest";
        private string strUri = "http://e0.vdowowza.hk3.tvb.com/vod/_definst_/smil:XBOX_TEST/XBOX_token.smil/Manifest";
        private string strToken;

        private bool needToken = true;

        private SMFPlayer player;

        string strSubtitle = "";

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
                /*player.PlaylistVisibility = player.Playlist != null && player.Playlist.Count > 1
                                         ? FeatureVisibility.Hidden
                                         : FeatureVisibility.Disabled;
                
                player.CaptionsVisibility = e.InitParams.ContainsKeyIgnoreCase(SupportedInitParams.SelectedCaptionStream)
                                        ? FeatureVisibility.Visible
                                        : FeatureVisibility.Disabled;
                 */
            }
            player.PlaylistVisibility = FeatureVisibility.Disabled;
            player.CaptionsVisibility = FeatureVisibility.Visible;

            strUri0 = GetVideoLink();

            if (needToken)
            {
                Token myToken = new Token();
                myToken.OnCompleted += new Token.DownloadStringCompletedHandler(GetToken);
                myToken.PostRequest();
            }
            else
            {
                AddTestClip();
            }
            
            player.AutoPlay = true;

            this.RootVisual = player;
            //this.RootVisual = new MainPage();

            HtmlPage.Document.GetElementById("btnCallJSMethod").AttachEvent("click", new EventHandler(this.CallGlobalJSMethod));
        }

        private string GetVideoLink()
        {
            string link = "";

            
            link = HtmlPage.Window.Invoke("getLink").ToString();

            return link;
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

        private void GetToken(object sender, Token e)
        {
            strToken = e.strToken;
            AddTestClip();
        }

        private void AddTestClip()
        {
            var playlist = new ObservableCollection<PlaylistItem>();
            var playlistItem = new PlaylistItem
            {
                MediaSource = new Uri(strUri0), 
            };

            playlistItem.Title = "第1集 - 歹徒為脫身街上駁火";
            playlistItem.Description = "Description";
            playlistItem.ThumbSource = new Uri("000003217098_1389329122.jpg", UriKind.Relative);

            string pageUri = System.Windows.Browser.HtmlPage.Document.DocumentUri.ToString();
            
            string[] words = pageUri.Split('/');
            for (int i = 0; i < words.Length - 1; ++i)
            {
                strSubtitle += words[i] + "/";
            }
            strSubtitle += "convert.php?p=img.tvb.com/he/subtitle/1576/157529_tc.xml&d=Silverlight"; //OK
//            string strSubtitle = "http://10.2.128.167/~monica.fu/sl/ClientBin/157529_tc.xml"; //OK
//            string strSubtitle = "http://10.2.2.82/convert.php?p=img.tvb.com/he/subtitle/1576/157529_tc.xml&d=Silverlight"; // monica-fu.inline.tvb.com
//            string strSubtitle = "157529_tc.xml";//OK

            playlistItem.IsMultipleAudioTracks = true;

            playlistItem.DeliveryMethod = DeliveryMethods.AdaptiveStreaming;
            
            if (strToken != null && !strToken.Equals("") && !strToken.Equals("undifined"))
            {
                playlistItem.BearerToken = strToken;
            }

            if (strSubtitle != null)
            {
                MarkerResource caption = new MarkerResource();
                caption.Source = new Uri(strSubtitle, UriKind.RelativeOrAbsolute);
                playlistItem.MarkerResources.Add(caption);
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

        private void CallGlobalJSMethod(object o, EventArgs e)
        {
            HtmlPage.Window.Invoke("globalJSMethod", strSubtitle);
        }
    }
}
