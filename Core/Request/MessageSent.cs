using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Browser;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Microsoft.SilverlightMediaFramework.Core.Request
{
    public class MessageSent
    {
        static String HOST = "http://encode1.hk1.tvb.com/cgi-bin/m";
        static int RETRIED_TIME = 1;

        static public void GetRequest(MsgParams msgparams)
        {
            try
            {
                WebClient client = new WebClient();
                client.DownloadProgressChanged += ClientDownloadProgressChanged;

                string uri = HOST + msgparams.Params;
                client.DownloadStringAsync(new Uri(uri, UriKind.Absolute), "GET");
            }
            catch (WebException ex)
            {

            }
        }

        static private void ClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            
        }

        static public void PostRequest(MsgParams msgparams)
        {
            WebClient client = new WebClient();
            client.UploadProgressChanged += ClientUploadProgressChanged;
            string uri = HOST;
            string param = msgparams.Params;

            client.Headers["Content-type"] = "image/gif";
            client.UploadStringAsync(new Uri(uri), "POST", param);
        }

        static private void ClientUploadProgressChanged(object sender, UploadProgressChangedEventArgs e)
        {

        }
    }
}
