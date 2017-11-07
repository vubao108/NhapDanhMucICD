using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.IO;
using System.Threading;

namespace WindowsFormsSelenium
{
    public partial class WinformSelenium : Form
    {
        private IWebDriver driver;
        
        private static String urlPage = "http://guinhanvb.hatinh.gov.vn/guinhan/index.nsf/frmShowData?openform&dbtype=vbden&hienthi=toanbo&noinhan=benhvienhuongson.hs&startpage=";
        private static int lastPage;
        
        public WinformSelenium()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Size = new Size(900, 400);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("http://guinhanvb.hatinh.gov.vn/guinhan/index.nsf");
            button1.Enabled = false;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
        private void btXuly_Click(object sender, EventArgs e)
        {
            Thread thrd = new Thread(Xuly_background);
          //  thrd.IsBackground = true;
            thrd.Start();
        }

         void Xuly_background()
        {
            driver.Navigate().GoToUrl(urlPage + "1");
            IWebElement el_lastpage = driver.FindElement(By.XPath("//*[@id='pagination']/li[14]/a"));
            string last_url = el_lastpage.GetAttribute("href");

           
           lastPage = int.Parse(last_url.Substring(136));

            //driver.Navigate().GoToUrl();
            int count = 0;
            int break_count = 0;

            for (int page = 1; page <= lastPage && break_count < 10; page++)
            {
                driver.Navigate().GoToUrl(urlPage + page);
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
                //    lbPage.Text = page.ToString();
                //driver.switchTo().frame(driver.findElement(By.id("ifContent")));

                IList<IWebElement> list = driver.FindElements(By.XPath("/html/body/form/div[4]/table/tbody/tr"));
               
                //  System.out.println(list.size());

                for (int i = 2; i < list.Count && break_count < 10; i++)
                {
                    IWebElement el = list[i];
                    IWebElement el_sokyhieu = el.FindElement(By.XPath("./td[3]"));
                    IWebElement el_tieude = el.FindElement(By.XPath("./td[4]/a"));
                    IWebElement el_noigui = el.FindElement(By.XPath("./td[5]"));
                    IWebElement el_ngaynhan = el.FindElement(By.XPath("./td[8]"));
                    if (!isExist_sokyhieu(el_sokyhieu.Text))
                    {
                        break_count = 0;
                        String pdflink_str = "http://guinhanvb.hatinh.gov.vn/guinhan/vbden.nsf/str/" + el_tieude.GetAttribute("onclick").Substring(11, 32);

                        DBConnection.ExecuteQuery($"call vu_insert_vanban('{el_sokyhieu.Text}','{el_tieude.Text}','{el_noigui.Text}','{el_ngaynhan.Text}','{pdflink_str}')");
                        count++;
                        // lbCount.Text = count.ToString();
                    }
                    else
                    {
                        break_count++;
                    }

                }
            }



        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            btXuly.Enabled = false;
            Thread thrd = new Thread(bg_layUrl);
           // thrd.IsBackground = true;
            thrd.Start();
           // bg_layUrl();

        }
        bool isExist_sokyhieu(string sokyhieu)
        {
            DataTable dt = DBConnection.GetDataByQuery($"call vu_check_so_ky_hieu('{sokyhieu}')");
            
            if (dt.Rows.Count == 0)
            {
                return false;
            }
            return true;
        }
        void bg_layUrl()
        {
            DataTable dt = DBConnection.GetDataByQuery("call vu_lay_so_ky_hieu()");
            foreach(DataRow row in dt.Rows)
            {
                string sokyhieu = row["so_ky_hieu"].ToString();
                string info_url = row["info_url"].ToString();

                driver.Navigate().GoToUrl(info_url);
                try
                {
                    IWebElement el_link = driver.FindElement(By.XPath("//*[@id='tblMain']/tbody/tr[3]/td/table/tbody/tr[10]/td[2]/a"));
                    string url_part = el_link.GetAttribute("onclick");
                    string url = url_part.Substring(13, url_part.Length - 16);
                    string pdfurl = "http://guinhanvb.hatinh.gov.vn/guinhan/vbden.nsf/str/" + url;

                    DBConnection.ExecuteQuery($"call vu_update_file_url('{sokyhieu}','{pdfurl}')");
                }
                catch(NoSuchElementException e)
                {
                    DBConnection.ExecuteQuery($"call vu_update_file_url('{sokyhieu}','')");
                }

            }
        }
    }
}
