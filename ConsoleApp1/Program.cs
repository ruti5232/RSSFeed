// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Caching.Memory;
using System.ServiceModel.Syndication;
using System.Xml;

Console.WriteLine("Hello, World!");
static void ParseRSSdotnet()
{
    SyndicationFeed feed = null;

    try
    {
        using (var reader = XmlReader.Create("https://www.recruiter.com/feed/career.xml"))
        {
            feed = SyndicationFeed.Load(reader);
        }
    }
    catch
    {
        Console.WriteLine("error while loadinggg!!!");
    } // TODO: Deal with unavailable resource.

    if (feed != null)
    {
        foreach (var element in feed.Items)
        {
            Console.WriteLine($"Title: {element.Title.Text}");
            Console.WriteLine($"Summary: {element.Summary.Text}");
        }

    }
}
//static void ParseRSSdotnet1()
//{
//    // Create or retrieve the MemoryCache instance
//    MemoryCache cache = new MemoryCache(new MemoryCacheOptions());

//    SyndicationFeed feed = null;

//    // Try to get the feed from cache
//    if (!cache.TryGetValue("rssFeed", out feed))
//    {
//        try
//        {
//            using (var reader = XmlReader.Create("https://www.recruiter.com/feed/career.xml"))
//            {
//                feed = SyndicationFeed.Load(reader);
//            }

//            // Store the feed in cache with a specific expiration time (e.g., 30 minutes)
//            var cacheEntryOptions = new MemoryCacheEntryOptions
//            {
//                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30)
//            };

//            cache.Set("rssFeed", feed, cacheEntryOptions);
//        }
//        catch
//        {
//            Console.WriteLine("Error while loading!!!");
//            // TODO: Deal with unavailable resource.
//        }
//    }

//    if (feed != null)
//    {
//        foreach (var element in feed.Items)
//        {
//            Console.WriteLine($"Title: {element.Title.Text}");
//            Console.WriteLine($"Summary: {element.Summary.Text}");
//        }
//    }
//}
 static List<SyndicationItem> ParseRSSdotnet1()
{
    // Create or retrieve the MemoryCache instance
    MemoryCache cache = new MemoryCache(new MemoryCacheOptions());

    SyndicationFeed feed = null;

    // Try to get the feed from cache
    if (!cache.TryGetValue("rssFeed", out feed))
    {
        try
        {
            using (var reader = XmlReader.Create("https://www.recruiter.com/feed/career.xml"))
            {
                feed = SyndicationFeed.Load(reader);
            }

            // Store the feed in cache with a specific expiration time (e.g., 30 minutes)
            var cacheEntryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30)
            };

            cache.Set("rssFeed", feed, cacheEntryOptions);
        }
        catch
        {
            Console.WriteLine("Error while loading!!!");
            // TODO: Deal with unavailable resource.
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
ParseRSSdotnet1();