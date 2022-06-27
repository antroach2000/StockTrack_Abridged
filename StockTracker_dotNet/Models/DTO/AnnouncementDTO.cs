using System.Collections.Generic;

namespace StockTrade.API.Models.DTO
{
    public class AnnouncementDTO
    {
        public List<AnnouncementItemDTO> announcements{ get; set; }
        public string pagingNextUrl { get; set; }
    }
}
