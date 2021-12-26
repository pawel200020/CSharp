using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace _10_Metric_Hitler
{
    class Crawler
    {
        readonly private int mainThreadId;
        readonly private string mainLink;
        readonly private int depth;
        private List<string> links;
        public Crawler(int mainThreadId, int depth,string mainLink)
        {
            this.mainThreadId = mainThreadId;
            this.depth = depth + 1;
            if (mainLink.Equals("http://en.wikipedia.org/wiki/Special:Random"))
            {
                this.mainLink = GetFinalRedirect(mainLink);
            }
            else
            {
                this.mainLink = mainLink;
            }
        }
        private static void StartThread(string url)
        {
            Crawler c = new Crawler(0, 0, url);
            c.Run();
        }
        public void Run()
        {
            Console.WriteLine(mainLink);
            links = GetAllLinksFromWebPage();
            foreach (var item in links)
            {
                Task taskA = Task.Run(() => StartThread(item));
                taskA.Wait();
            }
        }
        private bool FilterPage(string a)
        {
            if (a.StartsWith("/wiki/") && !a.Contains("/wiki/File:") && !a.Contains("/wiki/Special:") && !a.Contains("/wiki/Category") && !a.Contains("/wiki/Talk") && !a.Contains("/wiki/Template:") && !a.Contains("/wiki/Template_talk:") && !a.Contains("/wiki/Help") && !a.Contains("/wiki/Wikipedia:Stub"))
            {
                return true;
            }
            else { return false; }
        }
        private List<string> GetAllLinksFromWebPage()
        {
            List<string> result = new List<string>();

            string URL = mainLink;
            HtmlWeb hw = new HtmlWeb();
            HtmlDocument doc = hw.Load(URL);
            int i = 0;
            foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//a/@href"))
            {
                string a = node.GetAttributeValue("href", null);
                if (a.Contains("//en.m.wikipedia.org/wiki/"))
                {
                    Console.WriteLine("--------------------------"+a);
                }
                if (a.Equals("/wiki/Main_Page"))
                {
                    Console.WriteLine(i + " " + a);
                    break;
                }
                if (FilterPage(a))
                {
                    
                    if (!result.Contains(a))
                    {
                        Console.WriteLine(i + " " + a);
                        result.Add("https://en.wikipedia.org/" + a);
                        ++i;
                    }          
                }
            }
            return result;
        }
        private string GetFinalRedirect(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return url;

            int maxRedirCount = 3;  // prevent infinite loops
            string newUrl = url;
            do
            {
                HttpWebRequest req = null;
                HttpWebResponse resp = null;
                try
                {
                    req = (HttpWebRequest)HttpWebRequest.Create(url);
                    req.Method = "HEAD";
                    req.AllowAutoRedirect = false;
                    resp = (HttpWebResponse)req.GetResponse();
                    switch (resp.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            return newUrl;
                        case HttpStatusCode.Redirect:
                        case HttpStatusCode.MovedPermanently:
                        case HttpStatusCode.RedirectKeepVerb:
                        case HttpStatusCode.RedirectMethod:
                            newUrl = resp.Headers["Location"];
                            if (newUrl == null)
                                return url;

                            if (newUrl.IndexOf("://", System.StringComparison.Ordinal) == -1)
                            {
                                // Doesn't have a URL Schema, meaning it's a relative or absolute URL
                                Uri u = new Uri(new Uri(url), newUrl);
                                newUrl = u.ToString();
                            }
                            break;
                        default:
                            return newUrl;
                    }
                    url = newUrl;
                }
                catch (WebException)
                {
                    // Return the last known good URL
                    return newUrl;
                }
                catch (Exception ex)
                {
                    return null;
                }
                finally
                {
                    if (resp != null)
                        resp.Close();
                }
            } while (maxRedirCount-- > 0);

            return newUrl;
        }

    }
}
