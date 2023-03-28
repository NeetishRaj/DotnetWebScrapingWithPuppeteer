using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

using System.Net;

using System.Xml;

//usine System.Configuration;
//using System.Data;
//usine System.Data.Sqlclient;
//using System.I0;
//using System.Ling;
//usine System.Net;
//using System.Threading;
//usine HtmlAgilityPack;
//usine SHDOCVW;



void print(string txt) { 
    Console.WriteLine(txt);
}
print("Hello t here");
//Private static List<Tuple<DateTime, double>> Myfonction(string xxx, string yyy)
//{



//    string url = "https://www.clal.it/en/index.php?section=latte_francia#fran";
//    string pageData = "";
//    int count = 0;



//    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
//    request.Method = "GET";
//    request.UserAgent = @"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.79 Safari/537.36";
//    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
//    var stream = response.GetResponseStream();
//    using (StreamReader reader = new StreamReader(stream))
//    {
//        pageData = reader.ReadToEnd();
//        response.Close();
//    }
//    HtmlDocument htmlDoc = new HtmlDocument();
//    htmlDoc.LoadHtml(pageData);



//    foreach (HtmlNode tableNode in htmlDoc.DocumentNode.Descendants("table")) //.Where(d => d.Attributes.Contains("class") && d.Attributes("class"].Value.Contains("left15")))
//    {
//        foreach (HtmlNode tdNode in htmlDoc.DocumentNode.Descendants("td").Where(d => d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("left1s")))
//        {
//            HtmlNode parentNode = tdNode.ParentNode.ParentNode;
//            foreach (HtmlNode trNode in parentNode.ChildNodes)
//            {
//                if (trNode.InnerText.Contains("Farm-gate milk prices, France"))
//                {
//                    foreach (HtmlNode tdNodeInTable in tableNode.ChildNodes)
//                    {
//                        if (tdNodeInTable.InnerText.Contains("20"))
//                        {
//                            var allText = tdNodeInTable.InnerText.Split(new string[] { "It", "t" }, StringSplitOptions.None);
//                            foreach (var line in allText)
//                            {
//                                if (line == "January")
//                                {
//                                    // Do something
//                                    res.Add(new Tuple<DateTime, double>(DateTime.Today, price));
//                                }
//                            }
//                        }
//                    }
//                }
//            }
//        }
//    }



//    return res;



//}