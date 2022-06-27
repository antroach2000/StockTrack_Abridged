using System;

namespace StockTrade.API.Models.ASX
{
    public class DividendFullASX
    {
        public DateTime created_date { get; set; }
        public DateTime ex_date { get; set; }
        public DateTime payable_date { get; set; }
        public DateTime record_date { get; set; }
        public double amount { get; set; }
        public double raw_franked_percentage { get; set; }
        public string franked_percentage { get; set; }
        public string type { get; set; }
        public string comments { get; set; }
        public string asx_code { get; set; }
        public DateTime books_close_date { get; set; }
        public string company_name_abbrev { get; set; }
    }
}
