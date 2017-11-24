using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
namespace CookieLogin
{
    public class ParseHtml
    {
        private HtmlDocument htmlDoc;

       // public HtmlDocument HtmlDoc { get => htmlDoc; private set => htmlDoc = value; }

        public ParseHtml(string html)

        {
            htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
        }
        public string get_total_item()
        {
            var xpath = "/html/body/form/div[4]/table/tbody/tr[2]/td/p";
            var last_page = htmlDoc.DocumentNode.SelectSingleNode(xpath).InnerText;

            return last_page.Split(null)[1];

        }
        public HtmlNodeCollection get_list_tr()
        {
            var xpath = "/html/body/form/div[4]/table/tbody/tr";
            return htmlDoc.DocumentNode.SelectNodes(xpath);
        }

      

        public string get_sokyhieu(HtmlNode current_node)
        {
            var xpath = "./td[3]";
            return current_node.SelectSingleNode(xpath).InnerText;
        }
        public string get_tieude(HtmlNode current_node)
        {
            var xpath = "./td[4]/a";
            return current_node.SelectSingleNode(xpath).InnerText;
        }
        public string get_noigui(HtmlNode current_node)
        {
            var xpath = "./td[5]";
            return current_node.SelectSingleNode(xpath).InnerText;
        }
        public string get_ngaynhan(HtmlNode current_node)
        {
            var xpath = "./td[8]";
            return current_node.SelectSingleNode(xpath).InnerText;
        }
        public string get_infourl(HtmlNode current_node)
        {
            var xpath = "./td[4]/a";
            string short_url = current_node.SelectSingleNode(xpath).Attributes["onclick"].Value.Substring(11, 32);
            return "http://guinhanvb.hatinh.gov.vn/guinhan/vbden.nsf/str/" + short_url;
        }

        public Dictionary<string, string> get_FileUrl()
        {
            //var xpath = "//*[@id='tblMain']/tr[3]/td/table/tr[9]/td[2]/a";
            //  var xpath = "//*[@id='tblMain']/tbody/tr[3]/td/table/tbody/tr[10]/td[2]/a";
            Dictionary<string,string> dict = new Dictionary<string,string>();
            dict.Add("pdfLink", "");
            dict.Add("docLink", "");
            dict.Add("otherLink", "");
            var xpath = "//table[@id='tblMain']/tr[9]/tr/tr/td[2]/a";
            
            var list_el = htmlDoc.DocumentNode.SelectNodes(xpath);
            if (list_el is null)
            {
                return dict;
            }
            else
            {
                foreach (HtmlNode node in list_el)
                {
                    var innerText = node.InnerText;
                    var extraType = innerText.Substring(innerText.Length - 3);
                    if (extraType.Equals("pdf", StringComparison.OrdinalIgnoreCase)) {
                        string tmp = node.Attributes["onclick"].Value;
                        string pdfLink = "http://guinhanvb.hatinh.gov.vn/guinhan/vbden.nsf/str/" + tmp.Substring(13, tmp.Length - 16);
                        dict["pdfLink"] = pdfLink;
                    }
                    else if (extraType.Equals("doc", StringComparison.OrdinalIgnoreCase) || extraType.Equals("ocx",StringComparison.OrdinalIgnoreCase))
                    {
                        string tmp = node.Attributes["onclick"].Value;
                        string docLink = "http://guinhanvb.hatinh.gov.vn/guinhan/vbden.nsf/str/" + tmp.Substring(13, tmp.Length - 16);
                        dict["docLink"] = docLink;
                    }
                    else
                    {
                        string tmp = node.Attributes["onclick"].Value;
                        string otherLink = "http://guinhanvb.hatinh.gov.vn/guinhan/vbden.nsf/str/" + tmp.Substring(13, tmp.Length - 16);
                        if (string.IsNullOrEmpty(dict["otherLink"])){
                            dict["otherLink"] = otherLink ;
                        }
                        else
                        {
                            dict["otherLink"] = dict["otherLink"] + "\n" + otherLink ;
                        }
                    }
                }
                return dict;
            }
        }
        public string get_nguoi_ky()
        {
            string xpath = "//*[@id='tblMain']/tr[7]/td[2]";
            var nguoi_ky = htmlDoc.DocumentNode.SelectSingleNode(xpath).InnerText;
            return nguoi_ky;

        }
        public string get_chuc_vu()
        {
            string xpath = "//*[@id='tblMain']/tr[8]/td[2]";
            return htmlDoc.DocumentNode.SelectSingleNode(xpath).InnerText;

        }
        public string get_do_khan()
        {
            string xpath = "//*[@id='tblMain']/tr[9]/td[2]";
            return htmlDoc.DocumentNode.SelectSingleNode(xpath).InnerText;

        }
        public string get_loai_van_ban()
        {
            string xpath = "//*[@id='tblMain']/tr[9]/tr/td[2]";
            return htmlDoc.DocumentNode.SelectSingleNode(xpath).InnerText;

        }
        public string get_ngay_ban_hanh()
        {
            string xpath = "//*[@id='tblMain']/tr[4]/td[2]";
            return htmlDoc.DocumentNode.SelectSingleNode(xpath).InnerText;

        }
    }
  
}

