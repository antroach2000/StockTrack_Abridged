using System;

namespace StockTrade.API.Models.DTO
{
    public class AnnouncementItemDTO
    {
        public string id { get; set; }
        public DateTime documentReleaseDate { get; set; }
        public DateTime documentDate { get; set; }
        public string url { get; set; }
        public string relativeUrl { get; set; }
        public string header { get; set; }
        public bool marketSensitive { get; set; }
        public int numberPages { get; set; }
        public string size { get; set; }
        public bool legacyAnnouncement { get; set; }
    }
}
