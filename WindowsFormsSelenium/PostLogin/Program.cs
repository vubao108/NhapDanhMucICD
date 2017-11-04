using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PostLogin
{
    class Program
    {
        static string  formUrl = "http://guinhanvb.hatinh.gov.vn/names.nsf?Login";
        static string url = "http://guinhanvb.hatinh.gov.vn/guinhan/index.nsf/frmShowData?openform&dbtype=vbden&hienthi=toanbo&noinhan=benhvienhuongson.hs&startpage=1";
        static void Main(string[] args)
        {
            /*
            CookieCollection cookies = new CookieCollection();

           
            
            string formParams = string.Format("Username={0}&Password={1}", "benhvienhuongson.hs", "huongson123");
          //  string cookieHeader;
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(formUrl);
            req.CookieContainer = new CookieContainer();
            req.CookieContainer.Add(cookies);

            req.ContentType = "application/x-www-form-urlencoded";
            req.Method = "POST";
            req.KeepAlive = true;
            byte[] bytes = Encoding.ASCII.GetBytes(formParams);
            req.ContentLength = bytes.Length;
            Stream datastream;
            using ( datastream = req.GetRequestStream())
            {
                datastream.Write(bytes, 0, bytes.Length);
                datastream.Close();
            }
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            cookies = resp.Cookies;
            datastream = resp.GetResponseStream();
            StreamReader reader = new StreamReader(datastream);
            
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            datastream.Close();
            resp.Close();
            */
            CookieContainer c = Login();

            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);
            myRequest.CookieContainer = c;
         //   myRequest.CookieContainer.Add(cookies);
            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            Stream mydata = myResponse.GetResponseStream();
            StreamReader sreader = new StreamReader(mydata, Encoding.UTF8);
            string strdata = sreader.ReadToEnd();
            Console.WriteLine(strdata);
            sreader.Close();
            myResponse.Close();
            //cookieHeader = resp.Headers["Set-cookie"];


        }
        protected static CookieContainer Login()
        {
            string userName = "benhvienhuongson.hs";
            string password ="huongson123";

            ASCIIEncoding encoding = new ASCIIEncoding();
            string postData = "Username=" + userName + "&Password=" + password;
            byte[] postDataBytes = encoding.GetBytes(postData);

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(formUrl);

            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/x-www-form-urlencoded";
            httpWebRequest.ContentLength = postDataBytes.Length;
            httpWebRequest.AllowAutoRedirect = false;

            using (var stream = httpWebRequest.GetRequestStream())
            {
                stream.Write(postDataBytes, 0, postDataBytes.Length);
                stream.Close();
            }

            var cookieContainer = new CookieContainer();

            using (var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
            {
                using (var streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    foreach (Cookie cookie in httpWebResponse.Cookies)
                    {
                        cookieContainer.Add(cookie);
                    }
                }
            }

            return cookieContainer;
        }
    }
}
    