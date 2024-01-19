using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.ServiceModel.Syndication;

namespace UI
{
    [Route("api/[controller]")]
    [ApiController]
    public class RSSFeedController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetRssFeed()
        {
            List<SyndicationItem> rssFeed = DAL.LoadRSS.ParseRSSdotnet();
            return Ok(rssFeed);
        }
    }
}
