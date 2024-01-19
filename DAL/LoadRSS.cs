using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DAL
{
    public class LoadRSS
    {
        public static List<SyndicationItem> ParseRSSdotnet()
        {
            MemoryCache cache = new MemoryCache(new MemoryCacheOptions());

            SyndicationFeed feed = null;

            if (!cache.TryGetValue("rssFeed", out feed))
            {
                try
                {
                    using (var reader = XmlReader.Create("http://news.google.com/news?pz=1&cf=all&ned=en_il&hl=en&output=rss"))
                    {
                        feed = SyndicationFeed.Load(reader);
                    }

                    var cacheEntryOptions = new MemoryCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30)
                    };

                    cache.Set("rssFeed", feed, cacheEntryOptions);
                }
                catch
                {
                    Console.WriteLine("Error while loading!!!");
                }
            }

            if (feed != null)
            {
                foreach (var element in feed.Items)
                {
                    Console.WriteLine($"Title: {element.Title.Text}");
                    Console.WriteLine($"Summary: {element.Summary.Text}");
                } 
                return feed.Items.ToList();
            }
            return new List<SyndicationItem>();
        }
    }
}
