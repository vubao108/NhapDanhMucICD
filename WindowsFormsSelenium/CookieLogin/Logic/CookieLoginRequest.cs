using System;

using System.Linq;
using System.Net;
using System.Text;
using System.Collections.Specialized;
using System.IO;

namespace CookieLogin.Logic
{
    public class CookieRequest : WebClient
    {
        public void Login(string loginPageAddress, NameValueCollection loginData)
        {


            var request = (HttpWebRequest)WebRequest.Create(loginPageAddress);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            var query = string.Join("&",
              loginData.Cast<string>().Select(key => $"{key}={loginData[key]}"));

            var buffer = Encoding.ASCII.GetBytes(query);
            request.ContentLength = buffer.Length;
            var requestStream = request.GetRequestStream();
            requestStream.Write(buffer, 0, buffer.Length);
            requestStream.Close();

            request.CookieContainer = new CookieContainer();

            var response = request.GetResponse();
            response.Close();
            this.MyCookieContainer = request.CookieContainer;
        }

        public CookieRequest(CookieContainer container)
        {
            MyCookieContainer = container;
        }

        public CookieRequest()
          : this(new CookieContainer())
        { }

        public CookieContainer MyCookieContainer { get; private set; }

        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = (HttpWebRequest)base.GetWebRequest(address);
            request.CookieContainer = this.MyCookieContainer;
            return request;
        }
        public string postRequest(string url, string data)
        {
            string result = null;


            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.CookieContainer = this.MyCookieContainer;



            var buffer = Encoding.ASCII.GetBytes(data);
            request.ContentLength = buffer.Length;
            var requestStream = request.GetRequestStream();
            requestStream.Write(buffer, 0, buffer.Length);
            requestStream.Close();



            var response = (HttpWebResponse)request.GetResponse();
            Stream mydata = response.GetResponseStream();
            StreamReader sreader = new StreamReader(mydata, Encoding.UTF8);
            result = sreader.ReadToEnd();
            response.Close();
            mydata.Close();
            sreader.Close();

            return result;
        }

        public string getHtmlPageStr(string address)
        {
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(address);
            myRequest.CookieContainer = this.MyCookieContainer;


            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            Stream mydata = myResponse.GetResponseStream();
            StreamReader sreader = new StreamReader(mydata, Encoding.UTF8);
            string strdata = sreader.ReadToEnd();
            mydata.Close();
            sreader.Close();
            return strdata;
        }

    }

}