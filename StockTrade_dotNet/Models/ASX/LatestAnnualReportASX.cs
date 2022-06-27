using System;

namespace StockTrade.API.Models.ASX
{
    public class LatestAnnualReportASX
    {
        public string id { get; set; }
        public DateTime document_release_date { get; set; }
        public DateTime document_date { get; set; }
        public string url { get; set; }
        public string relative_url { get; set; }
        public string header { get; set; }
        public bool market_sensitive { get; set; }
        public int number_of_pages { get; set; }
        public string size { get; set; }
        public bool legacy_announcement { get; set; }
    }
}
