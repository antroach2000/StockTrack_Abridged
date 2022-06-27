using System.Collections.Generic;

namespace StockTrade.API.Models.ASX
{
    public class AnnouncementASX
    {       
        public List<AnnouncementItemASX> data { get; set; }
        public string paging_next_url { get; set; }
    }
}
