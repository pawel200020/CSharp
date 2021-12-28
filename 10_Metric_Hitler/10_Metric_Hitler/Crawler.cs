using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace _10_Metric_Hitler
{
    class Crawler
    {
        readonly private int mainThreadId;
        readonly private string mainLink;
        readonly private long depth;
        private List<string> links;
        public Crawler(int mainThreadId, long depth,string mainLink)
        {
            this.mainThreadId = mainThreadId;
            this.depth = depth;
            if (mainLink.Equals("http://en.wikipedia.org/wiki/Special:Random"))
            {
                this.mainLink = GetFinalRedirect(mainLink);
            }
            else
            {
                this.mainLink = mainLink;
            }
        }
        private void StartThread(string url)
        {
            Crawler c = new Crawler(this.mainThreadId, this.depth + 1, url);
            c.Run();
        }
        public async void Run()
        {

            if (mainLink.Equals("https://en.wikipedia.org//wiki/Adolf_Hitler"))
            {
                try
                {
                    await Program.semaphore.WaitAsync();
                    if (depth < Program.depthArray[mainThreadId])
                    {
                        Program.depthArray[mainThreadId] = depth;
                    }
                    Program.res.Add($"Adolf znaleziony w watku: {mainThreadId} na glebokosci {depth}");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Adolf znaleziony w watku: {mainThreadId} na glebokosci {depth}");
                    Console.ResetColor();
                }
                finally
                {
                    Program.semaphore.Release();
                }
                

                return;
            }
            if (Program.visited.Contains(mainLink) || depth == Program.MAX_DEPTH)
            {
                return;
            }
            else
            {
                Program.visited.Add(mainLink);
            }

            Console.WriteLine(mainLink+" depth: "+depth+" mainthreadId: "+mainThreadId);
            links = GetAllLinksFromWebPage();
            var tasks = new List<Task>();
            foreach (var item in links)
            {
                Task t = new Task(() => StartThread(item));
                tasks.Add(t);
                t.Start();
            }
            Task.WaitAll(tasks.ToArray());
        }
        private bool FilterPage(string a)
        {
            if (a.StartsWith("/wiki/") && !a.Contains("/wiki/File:") && !a.Contains("/wiki/Special:") && !a.Contains("/wiki/Category") && !a.Contains("/wiki/Talk") && !a.Contains("/wiki/Template:") && !a.Contains("/wiki/Template_talk:") && !a.Contains("/wiki/Help") && !a.Contains("/wiki/Wikipedia:Stub") && !a.Contains("/wiki/User:"))
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
                if (a.Equals("/wiki/Main_Page"))
                {
                   // Console.WriteLine(i + " " + a+"\n\n");
                    break;
                }
                if (FilterPage(a))
                {
                    
                    if (!result.Contains(a))
                    {
                        //Console.WriteLine(i + " " + a);
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
