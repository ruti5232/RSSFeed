using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ServiceModel.Syndication;

namespace UI.Pages.RSSFeed
{
    public class IndexModel : PageModel
    {

        public List<SyndicationItem> RSSFeed { get; set; }
        public void OnGet()
        {
            RSSFeed = DAL.LoadRSS.ParseRSSdotnet();
        }
    }
}
