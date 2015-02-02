using System;
using System.Net;

namespace Microsoft.SilverlightMediaFramework.Samples.Demo
{
    public class Token
    {
        public string strToken;
        public delegate void DownloadStringCompletedHandler(object sender, Token e);
        public event DownloadStringCompletedHandler OnCompleted;

        public Token()
        {
            this.strToken = "";
        }

        public void PostRequest()
        {
            string tokenUri = "http://encode1.hk1.tvb.com/prtoken.php";

            var client = new WebClient();
            client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(ClientDownloadStringCompleted);

            client.DownloadStringAsync(new Uri(tokenUri, UriKind.Absolute));

        }

        private void ClientDownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            this.strToken = e.Result;
            OnCompleted(this, new Token() { strToken = e.Result });
        }

    }
}
