using System;
using System.Linq.Expressions;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Microsoft.SilverlightMediaFramework.Core.Request
{
    public class MsgParams
    {
        private string ci = "hk-";
        private string ci1 = "801802";
        private string ci2 = "tvb";

        private string c6 = "vc,";
        private string c61 = "b01";
        private string c62 = "c03";

        private string cc = "1";
        private string js = "1";
        private string cd = "24";
        private string tz = "8";

        private string ck = "y";
        private string je = "y";

        private string du;

        private string tl = "dav{0}-";
        private string tlnull = "null";
        private string tlid = "{0}/{1}/{2}";

        private string ou = "http://mytv.tvb.com/";
        private string si;
        private string rp;

        private string tp = "ggHEX40=<m v=1 c=co5vco6ts2wqFCBQHtpuhakjQDUz6uBG>#0,	";

        private string cg = "chhdjregular";
        
        private string ts = "v60.js";
        private string vn = "6.0.27";
        private string lg = "en-US";
        private string sr = "1440x900";

        private string rnd = "12345";
        private string id = "lstrg-4e89fd582c113c0d4af842e4dd7552cc";

        public string Params
        {
            get;
            set;
        }

        public MsgParams(RequestState state, string kind, string name, string identity, string duration)
        {
            if (state == RequestState.Initialize)
            {
                tlid = String.Format(tlid, kind, name, identity);

                ci = ci + ci2;
                cg = "0";
                si = ou + tlid;
                rp = ou;    // previous page

                Params = "?" + GetVariableName(new { rnd }) + "=" + rnd + "&" +
                    GetVariableName(new { ci }) + "=" + ci + "&" +
                    GetVariableName(new { js }) + "=" + js + "&" +
                    GetVariableName(new { cg }) + "=" + cg + "&" +
                    GetVariableName(new { ts }) + "=" + ts + "&" +
                    GetVariableName(new { vn }) + "=" + vn + "&" +
                    GetVariableName(new { cc }) + "=" + cc + "&" +
                    GetVariableName(new { cd }) + "=" + cd + "&" +
                    GetVariableName(new { ck }) + "=" + ck + "&" +
                    GetVariableName(new { je }) + "=" + je + "&" +
                    GetVariableName(new { lg }) + "=" + lg + "&" +
                    GetVariableName(new { si }) + "=" + si + "&" +
                    GetVariableName(new { rp }) + "=" + rp + "&" +
                    GetVariableName(new { sr }) + "=" + sr + "&" +
                    GetVariableName(new { id }) + "=" + id + "&" +
                    GetVariableName(new { tz }) + "=" + tz;
            }
            else if (state == RequestState.Play)
            {
                tlid = String.Format(tlid, kind, name, identity);
            
                ci = ci + ci2;
                tl = tl + tlid;
                du = duration;
                c6 = c6 + c62;
                rp = ou + tlid;

                if (duration == "0")
                {
                    tl = String.Format(tl, 0);

                    Params = "?" + GetVariableName(new { rnd }) + "=" + ci + "&" +
                        GetVariableName(new { cg }) + "=" + cg + "&" +
                        GetVariableName(new { tl }) + "=" + tl + "&" +
                        GetVariableName(new { c6 }) + "=" + c6 + "&" +
                        GetVariableName(new { rp }) + "=" + rp + "&" +
                        GetVariableName(new { rnd }) + "=" + rnd;
                }
                else
                {
                    tl = String.Format(tl, 1);

                    Params = "?" + GetVariableName(new { rnd }) + "=" + ci + "&" + 
                        GetVariableName(new { cg }) + "=" + cg + "&" +
                        GetVariableName(new { tl }) + "=" + tl + "&" +
                        GetVariableName(new { du }) + "=" + du + "&" +
                        GetVariableName(new { c6 }) + "=" + c6 + "&" +
                        GetVariableName(new { rp }) + "=" + rp + "&" +
                        GetVariableName(new { rnd }) + "=" + rnd;
                }
               
            }
            else if (state == RequestState.Stop)
            {
                tl = String.Format(tl, 1);
                tlid = String.Format(tlid, kind, name, identity);

                ci = ci + ci1;
                c6 = c6 + c61;
                du = duration;
                tl = tl + tlnull;
                ou = ou + tlid;

                Params = "?" + GetVariableName(new { rnd }) + "=" + ci + "&" +
                    GetVariableName(new { c6 }) + "=" + c6 + "&" +
                    GetVariableName(new { cc }) + "=" + cc + "&" +
                    GetVariableName(new { du }) + "=" + du + "&" +
                    GetVariableName(new { tl }) + "=" + tl + "&" +
                    GetVariableName(new { ou }) + "=" + ou + "&" +
                    GetVariableName(new { tp }) + "=" + tp;
            }
            else if (state == RequestState.Leave)
            {
                tlid = String.Format(tlid, kind, name, identity);

                ci = ci + ci2;
                cg = "0";
                si = ou;        // jump page
                rp = ou + tlid;

                Params = "?" + GetVariableName(new { rnd }) + "=" + rnd + "&" +
                    GetVariableName(new { ci }) + "=" + ci + "&" +
                    GetVariableName(new { js }) + "=" + js + "&" +
                    GetVariableName(new { cg }) + "=" + cg + "&" +
                    GetVariableName(new { ts }) + "=" + ts + "&" +
                    GetVariableName(new { vn }) + "=" + vn + "&" +
                    GetVariableName(new { cc }) + "=" + cc + "&" +
                    GetVariableName(new { cd }) + "=" + cd + "&" +
                    GetVariableName(new { ck }) + "=" + ck + "&" +
                    GetVariableName(new { je }) + "=" + je + "&" +
                    GetVariableName(new { lg }) + "=" + lg + "&" +
                    GetVariableName(new { si }) + "=" + si + "&" +
                    GetVariableName(new { rp }) + "=" + rp + "&" +
                    GetVariableName(new { sr }) + "=" + sr + "&" +
                    GetVariableName(new { id }) + "=" + id + "&" +
                    GetVariableName(new { tz }) + "=" + tz;
            }
        }

        static string GetVariableName<T>(T item) where T : class
        {
            if (item == null)
                return string.Empty;

            return typeof(T).GetProperties()[0].Name;
        }
    }

}
