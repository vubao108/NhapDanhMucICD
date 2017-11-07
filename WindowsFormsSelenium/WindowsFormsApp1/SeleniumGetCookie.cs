using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
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
            driver.Manage().Window.Size = new Size(900, 400);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
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
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(tbGetRequest.Text);
                myRequest.CookieContainer = cc;

                HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
                Stream mydata = myResponse.GetResponseStream();
                StreamReader sreader = new StreamReader(mydata, Encoding.UTF8);
                string strdata = sreader.ReadToEnd();
                mydata.Close();
                sreader.Close();
                tbHtml.Text = strdata;
            }
        }

        private void btGetData_Click(object sender, EventArgs e)
        {
            xuly_Selenium();

        }
        private void xuly_Selenium()
        {
            int sheetNum = int.Parse(tbSheet.Text);
            string file = "D:\\Work\\BHXH.xlsx";
            if (tbGetRequest.Text.Length > 0)
            {
                var url = tbGetRequest.Text;
                driver.Navigate().GoToUrl(url);

                //  var xpath = "//*[@id='gvEditing_DXDataRow']/td[2]";
                //handle page1
                ExcelHandle eh = new ExcelHandle();
                eh.open(file, sheetNum);
                for (int i = 0; i < 10; i++)
                {
                    var xpath = String.Format("//*[@id='gvEditing_DXDataRow{0}']/td[2]", i);
                    try
                    {
                        var text = driver.FindElement(By.XPath(xpath)).GetAttribute("title");
                        //tbHtml.AppendText(text);
                        Dictionary<string, string> data = handle_text(text);
                        eh.write(i + 2, data);
                    }
                    catch (NoSuchElementException nsex)
                    {
                        break;
                    }
                }

                //handle nextpage
                var xpath_nextpage01 = "//*[@id='gvEditing_DXPagerBottom']/a[2]";
                var nextpage01 = driver.FindElementsByXPath(xpath_nextpage01);
                if (nextpage01.Count > 0)
                {
                    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                    js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
                    nextpage01[0].Click();
                    for (int i = 10; i < 20; i++)
                    {
                        var xpath = String.Format("//*[@id='gvEditing_DXDataRow{0}']/td[2]", i);
                        try
                        {
                            var text = driver.FindElement(By.XPath(xpath)).GetAttribute("title");
                            // tbHtml.AppendText((i + 1) + " " + text);
                            Dictionary<string, string> data = handle_text(text);
                            eh.write(i + 2, data);
                        }
                        catch (NoSuchElementException)
                        {
                            break;
                        }
                    }
                

                    //handle page3,4,...
                    var xpath_nextpage = "//*[@id='gvEditing_DXPagerBottom']/a[11]";
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

                                    var xpath = String.Format("//*[@id='gvEditing_DXDataRow{0}']/td[2]", i);
                                    try
                                    {
                                        var text = driver.FindElement(By.XPath(xpath)).GetAttribute("title");
                                        //tbHtml.AppendText((i + 1) + " " + text);
                                        Dictionary<string, string> data = handle_text(text);

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
