using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CookieLogin
{
    class Program
    {
        static void Main(string[] args)
        {
            var loginAddress = "http://guinhanvb.hatinh.gov.vn/names.nsf?Login";
            var getAddress = "http://guinhanvb.hatinh.gov.vn/guinhan/index.nsf/frmShowData?openform&dbtype=vbden&hienthi=toanbo&noinhan=benhvienhuongson.hs&startpage=1";
            var loginData = new NameValueCollection
            {
              { "Username", "benhvienhuongson.hs" },
              { "Password", "huongson123" }
            };

            var client = new CookieAwareWebClient();
            client.Login(loginAddress, loginData);
            
            
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(getAddress);
            myRequest.CookieContainer = client.MyCookieContainer;

           
            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            Stream mydata = myResponse.GetResponseStream();
            StreamReader sreader = new StreamReader(mydata, Encoding.UTF8);
            string strdata = sreader.ReadToEnd();
            Console.WriteLine(strdata);
            Console.ReadKey();
            sreader.Close();
            myResponse.Close();
            
            
        }
    }
}
