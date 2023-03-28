using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using PuppeteerSharp;
using System.Text.RegularExpressions;


namespace price_scraper
{
    internal class Program
    {
        private static async Task scrape_monthly_milk_prices()
        {
            Console.WriteLine("Started Scraping");

            const string URL_TO_FETCH = "https://www.clal.it/en/index.php?section=latte_francia#fran";

            var browserFetcher = new BrowserFetcher();
            await browserFetcher.DownloadAsync();
            var browser = await Puppeteer.LaunchAsync(
                new LaunchOptions { Headless = true });

            var page = await browser.NewPageAsync();
            await page.GoToAsync(URL_TO_FETCH);

            // Running on the browser console to extract data
            var price_data = await page.EvaluateFunctionAsync<dynamic>(@"(value) => { 
                const list = document.querySelectorAll('a[name=""fran""] table tbody tr[style=""height:25px""]');
                const data = [];

                for(let i = 0; i < list.length; i++) {
                    data.push(list[i].textContent);
                }

                return data
            }", 5);


            var res = new List<Tuple<DateTime, double>>();
            foreach (var price in price_data)
            {
                var result = Regex.Replace(Convert.ToString(price), "\\s\\s+", " ").Replace(",", ".").Trim();
                Console.WriteLine(result);

                var items = result.Split(' ');

                var date_2020 = Convert.ToDateTime(items[0] + " 01, 2020");
                var date_2021 = Convert.ToDateTime(items[0] + " 01, 2021");
                var date_2022 = Convert.ToDateTime(items[0] + " 01, 2022");

                res.Add(Tuple.Create(date_2020, Convert.ToDouble(items[1])));
                res.Add(Tuple.Create(date_2021, Convert.ToDouble(items[2])));
                res.Add(Tuple.Create(date_2022, Convert.ToDouble(items[3])));

                if (items[0] == "January")
                {
                    Console.WriteLine("Adding for January");
                    var date_2023 = Convert.ToDateTime(items[0] + " 01, 2023");
                    res.Add(Tuple.Create(date_2023, Convert.ToDouble(items[4])));
                }
            }

            foreach (var item in res)
            {
                Tuple<DateTime, double> val = item;
                Console.WriteLine("Time: " + val.Item1.ToString() + ", Price: " + val.Item2);
            }

            Console.WriteLine("Ended Scraping");

            await page.CloseAsync();
            page.Dispose();
            await browser.CloseAsync();
            browser.Dispose();
            browserFetcher.Dispose();
        }

        static void Main(string[] args)
        {

            scrape_monthly_milk_prices();
            Console.ReadLine();
        }
    }
}
