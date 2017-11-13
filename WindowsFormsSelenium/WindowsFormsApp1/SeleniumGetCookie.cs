using OpenQA.Selenium;

using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace WindowsFormsApp1
{
    public partial class SeleniumGetCookie : Form
    {
        ChromeDriver driver;
        CookieContainer cc;
        public SeleniumGetCookie()
        {
            InitializeComponent();
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            if (driver is null)
            {
                initializeWebDriver();
            }
            if(tbAddress.Text.Length > 0)
            {
                driver.Navigate().GoToUrl(tbAddress.Text);
            }

        }

        private void initializeWebDriver()
        {
            driver = new ChromeDriver();
          // driver.Manage().Window.Size = new Size(900, 700);
          //driver.Manage().Window.Size = 
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
          //  driver.Manage().Window.Maximize();
        }

        private void GetCookie_Click(object sender, EventArgs e)
        {
            if (cc is null)
            {
                cc = new CookieContainer();
            }
            foreach(OpenQA.Selenium.Cookie c in driver.Manage().Cookies.AllCookies)
            {
                string name = c.Name;
                string value = c.Value;
                cc.Add(new System.Net.Cookie(name, value, c.Path, c.Domain));
            }
            
        }
        private void GetRequest_Click(object sender, EventArgs e)
        {
            if(tbGetRequest.Text.Length > 0)
            {
                tbHtml.Text = getRequest(tbGetRequest.Text);
            }
        }

        private void btPOST_Click(object sender, EventArgs e)
        {
            if (tbGetRequest.Text.Length > 0)
            {
                string data = tbPostData.Text;
                string strdata = postRequest(tbGetRequest.Text, data);
                tbHtml.Text = strdata;
            }
        }
        private string getRequest(string url)
        {
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);
            myRequest.CookieContainer = cc;


            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            Stream mydata = myResponse.GetResponseStream();
            StreamReader sreader = new StreamReader(mydata, Encoding.UTF8);
            string strdata = sreader.ReadToEnd();
            mydata.Close();
            sreader.Close();
            return strdata;
        }
        private string postRequest(string url, string data)
        {
            string result = null;


            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.CookieContainer = cc;



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

        private void btGetData_Click(object sender, EventArgs e)
        {
            xuly_Selenium();

        }
        private string getWaitText(string xpath)
        {
            int flag = 0;
            var element = driver.FindElementByXPath(xpath);
            //var script = "arguments[0].scrollIntoView(true);";
            /*
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);";, element);
            
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            actions.Perform();
            */
          //  IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            while (flag < 10)
            {
                if(element.Text.Length > 0)
                {
                    return element.Text;
                }
                else
                {
                    ++flag;
                    Thread.Sleep(500);
                }
            }
            return "";
        }
        private void ZoomOut()
        {
            /*
            Actions action = new Actions(driver);
            for (int i = 0; i < 6; i++)
            {
                action.SendKeys(OpenQA.Selenium.Keys.Control).SendKeys(OpenQA.Selenium.Keys.Subtract).Perform();
            }
            */
            //((IJavaScriptExecutor)driver).ExecuteScript("document.body.style.zoom = '30%';");
            IWebElement html = driver.FindElementByTagName("html");

            new Actions(driver)
                .SendKeys(OpenQA.Selenium.Keys.Control).SendKeys(OpenQA.Selenium.Keys.Subtract).SendKeys( OpenQA.Selenium.Keys.Null)
                .Perform();

        }
        private void scrollToRight()
        {
            IJavaScriptExecutor js = driver;
            js.ExecuteScript("window.scrollBy(300,0);","");
        }
        public Dictionary<string,string> getTextElements(int i)
        {
                Dictionary<string, string> dict = new Dictionary<string, string>();
                //   IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

                // js.ExecuteScript("window.scrollTo(5000,0);");
                var xpath = String.Format("//*[@id='gvEditing_DXDataRow{0}']", i);
                var current_row = driver.FindElementByXPath(xpath);

            var list_col = current_row.FindElements(By.XPath("./td"));
            int order = 0;
            foreach(var col in list_col)
            {
                ++order;
                scrollToRight();
               var value = col.Text;
            
                switch (order)
                {
                    case 1:
                        {
                            dict["stt"] = value;
                            break;

                        }
                    case 2:
                        {
                            dict["ten"] = value;
                            break;

                        }
                    case 22:
                        {
                            dict["loaithuoc"] = value;
                            break;

                        }
                    case 23:
                        {
                            dict["nhomthau"] = value;
                            break;

                        }
                    case 24:
                        {
                            dict["nam"] = value;
                            break;

                        }
                    case 25:
                        {
                            dict["trangthai"] = value;
                            break;

                        }



                }

            }
               /*
                dict["stt"] = current_row.FindElement(By.XPath("./td[1]")).Text;

            var ma_el = "./td[2]";
                dict["ma"] = current_row.FindElement(By.XPath(ma_el)).Text;
                

                var ten_el = String.Format("./td[3]");
                dict["ten"] = current_row.FindElement(By.XPath(ten_el)).Text;

            var sttpd_el = String.Format("./td[4]");
                dict["sttpd"] = current_row.FindElement(By.XPath(sttpd_el)).Text;

           // var hoatchat_el = String.Format("//*[@id='gvEditing_DXDataRow{0}']/td[5]", i);
                dict["hoatchat"] = current_row.FindElement(By.XPath("./td[5]")).Text;

           // var maduongdung_el = String.Format("//*[@id='gvEditing_DXDataRow{0}']/td[6]", i);
                dict["maduongdung"] = current_row.FindElement(By.XPath("./td[6]")).Text;

            //var duongdung_el = String.Format("//*[@id='gvEditing_DXDataRow{0}']/td[7]", i);
                dict["duongdung"] = current_row.FindElement(By.XPath("./td[7]")).Text;

          //  var hamluong_el = String.Format("//*[@id='gvEditing_DXDataRow{0}']/td[8]", i);
                dict["hamluong"] = current_row.FindElement(By.XPath("./td[8]")).Text;

           // var sodk_el = String.Format("//*[@id='gvEditing_DXDataRow{0}']/td[9]", i);
                dict["sodk"] = current_row.FindElement(By.XPath("./td[9]")).Text;

            //var nhasx_el = String.Format("//*[@id='gvEditing_DXDataRow{0}']/td[10]", i);
                dict["nhasx"] = current_row.FindElement(By.XPath("./td[10]")).Text;

            //var nuocsx_el = String.Format("//*[@id='gvEditing_DXDataRow{0}']/td[11]", i);
                dict["nuocsx"] = current_row.FindElement(By.XPath("./td[11]")).Text;

           // var quycach_el = String.Format("//*[@id='gvEditing_DXDataRow{0}']/td[12]", i);
                dict["quycach"] = current_row.FindElement(By.XPath("./td[12]")).Text;

            //var dvt_el = String.Format("//*[@id='gvEditing_DXDataRow{0}']/td[13]", i);
                dict["dvt"] = current_row.FindElement(By.XPath("./td[13]")).Text;

            //var soluong_el = String.Format("//*[@id='gvEditing_DXDataRow{0}']/td[14]", i);
                dict["soluong"] = current_row.FindElement(By.XPath("./td[14]")).Text;

            //var dongia_el = String.Format("//*[@id='gvEditing_DXDataRow{0}']/td[15]", i);
                dict["dongia"] = current_row.FindElement(By.XPath("./td[15]")).Text;

           // var thanhtien_el = String.Format("//*[@id='gvEditing_DXDataRow{0}']/td[16]", i);
                dict["thanhtien"] = current_row.FindElement(By.XPath("./td[16]")).Text;

           // var tennhathau_el = String.Format("//*[@id='gvEditing_DXDataRow{0}']/td[17]", i);
                dict["tennhathau"] = current_row.FindElement(By.XPath("./td[17]")).Text;

           // var quyetdinh_el = String.Format("//*[@id='gvEditing_DXDataRow{0}']/td[18]", i);
                dict["quyetdinh"] = current_row.FindElement(By.XPath("./td[18]")).Text;

            //var ngayHL_el = String.Format("//*[@id='gvEditing_DXDataRow{0}']/td[19]", i);
                dict["ngayHL"] = current_row.FindElement(By.XPath("./td[19]")).Text;

            //var ngayHH_el = String.Format("//*[@id='gvEditing_DXDataRow{0}']/td[20]", i);
                dict["ngayHH"] = current_row.FindElement(By.XPath("./td[20]")).Text;

            //var goithau_el = String.Format("//*[@id='gvEditing_DXDataRow{0}']/td[21]", i);
                dict["goithau"] = current_row.FindElement(By.XPath("./td[21]")).Text;

            //var loaithuoc_el = String.Format("//*[@id='gvEditing_DXDataRow{0}']/td[22]", i);
                dict["loaithuoc"] = current_row.FindElement(By.XPath("./td[22]")).Text;

            //var nhomthau_el = String.Format("//*[@id='gvEditing_DXDataRow{0}']/td[23]", i);
                dict["nhomthau"] = current_row.FindElement(By.XPath("./td[23]")).Text;

            //var nam_el = String.Format("//*[@id='gvEditing_DXDataRow{0}']/td[24]", i);
                dict["nam"] = current_row.FindElement(By.XPath("./td[24]")).Text;

            //var trangthai_el = String.Format("//*[@id='gvEditing_DXDataRow{0}']/td[25]", i);
                dict["trangthai"] = current_row.FindElement(By.XPath("./td[25]")).Text;

            //var mieuta_el = String.Format("//*[@id='gvEditing_DXDataRow{0}']/td[26]", i);
                dict["mieuta"] = current_row.FindElement(By.XPath("./td[26]")).Text;
                */

            return dict;

        }
        private void xuly_Selenium()
        {
            int sheetNum = int.Parse(tbSheet.Text);
            string file = "D:\\Work\\BHXH02.xlsx";
            if (tbGetRequest.Text.Length > 0)
            {
                var url = tbGetRequest.Text;
                driver.Navigate().GoToUrl(url);


                //  var xpath = "//*[@id='gvEditing_DXDataRow']/td[2]";
                //handle page1
                ExcelHandle eh = new ExcelHandle();
                eh.open(file, sheetNum);

                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("window.scrollTo(5000,0);");
                //  ZoomOut();
                for (int i = 0; i < 10; i++)
                {
                  //  var xpath = String.Format("//*[@id='gvEditing_DXDataRow{0}']/td[2]", i);
                    try
                    {
                        
                        //  var text = driver.FindElement(By.XPath(xpath)).GetAttribute("title");
                        //tbHtml.AppendText(text);
                        Dictionary<string, string> data = getTextElements( i);
                        eh.write(i + 2, data);
                    }
                    catch (NoSuchElementException nsex)
                    {
                        break;
                    }
                }

                //handle nextpage
                //var xpath_nextpage01 = "//*[@id='gvEditing_DXPagerBottom']/a[2]";
                var xpath_nextpage01 = "//*[@id='gvEditing_DXPagerBottom']/a[10]/img";
                var nextpage01 = driver.FindElementsByXPath(xpath_nextpage01);
                if (nextpage01.Count > 0)
                {
                  //  IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                   // js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
                    nextpage01[0].Click();
                    for (int i = 10; i < 20; i++)
                    {
                       // var xpath = String.Format("//*[@id='gvEditing_DXDataRow{0}']/td[2]", i);
                        try
                        {
                            Dictionary<string, string> data = getTextElements( i);
                            
                            eh.write(i + 2, data);
                        }
                        catch (NoSuchElementException)
                        {
                            break;
                        }
                    }
                

                    //handle page3,4,...
                    var xpath_nextpage = "//*[@id='gvEditing_DXPagerBottom']/a[11]/img";
                    int count = 20;
                        while (true)
                        {
                            var nextpage_list = driver.FindElementsByXPath(xpath_nextpage);
                            if (nextpage_list.Count > 0)
                            {

                                IJavaScriptExecutor js2 = (IJavaScriptExecutor)driver;
                                js2.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
                                nextpage_list[0].Click();
                                for (int i = count; i < count + 10; i++)
                                {

                                    
                                    try
                                    {
                                        Dictionary<string, string> data = getTextElements( i);

                                        eh.write(i + 2, data);

                                    }
                                    catch (NoSuchElementException e)
                                    {
                                        e.ToString();
                                        break;
                                    }
                                }
                                count = count + 10;
                            }
                            else
                            {
                                break;
                            }
                        }
                }

                eh.close();
            }
            
        }
        private Dictionary<string,string> handle_text(string text)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            var list_line = text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            int i = 0;
            foreach(string line in list_line)
            {
                
                var tmp_list = line.Split(new string[] { ":" }, StringSplitOptions.None);
                if (tmp_list.Length > 1)
                {
                    ++i;
                    var value = tmp_list[1];
                    switch (i)
                    {
                        case 1:
                            {
                                dict["stt"] = value;
                                break;
                            }
                        case 2:
                            {
                                dict["ma"] = value;
                                break;
                            }
                        case 3:
                            {
                                dict["ten"] = value;
                                break;
                            }
                        case 4:
                            {
                                dict["duong_dung"] = value;
                                break;
                            }
                        case 5:
                            {
                                dict["stt_hoatchat"] = value;
                                break;
                            }
                        case 6:
                            {
                                dict["hoat_chat"] = value;
                                break;
                            }
                        case 7:
                            {
                                dict["ham_luong"] = value;
                                break;
                            }
                        case 8:
                            {
                                dict["so_dang_ky"] = value;
                                break;
                            }
                        case 9:
                            {
                                dict["nha_sx"] = value;
                                break;
                            }
                        case 10:
                            {
                                dict["nuoc_sx"] = value;
                                break;
                            }
                        case 11:
                            {
                                dict["quy_cach"] = value;
                                break;
                            }
                        case 12:
                            {
                                dict["don_vi_tinh"] = value;
                                break;
                            }
                        case 13:
                            {
                                dict["ma_nha_thau"] = value;
                                break;
                            }
                        case 14:
                            {
                                dict["ten_nha_thau"] = value;
                                break;
                            }
                        case 15:
                            {
                                dict["quyet_dinh"] = value;
                                break;
                            }
                        case 16:
                            {
                                dict["ngay_cong_bo"] = value;
                                break;
                            }
                        case 17:
                            {
                                dict["tieu_chuan"] = value;
                                break;
                            }
                        case 18:
                            {
                                dict["goi_thau"] = value;
                                break;
                            }
                        case 19:
                            {
                                dict["nhom_thuoc"] = value;
                                break;
                            }
                        case 20:
                            {
                                dict["han_dung"] = value;
                                break;
                            }
                        case 21:
                            {
                                dict["nam"] = value;
                                break;
                            }
                        case 22:
                            {
                                dict["mieu_ta"] = value;
                                break;
                            }
                        case 23:
                            {
                                dict["trang_thai"] = value;
                                break;
                            }
                    }
                }
            }
            return dict;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
