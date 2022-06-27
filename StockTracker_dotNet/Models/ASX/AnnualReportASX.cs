using System;
using System.Collections.Generic;

namespace StockTrade.API.Models.ASX
{
    public class AnnualReportASX
    {
        public string code { get; set; }
        public string name_full { get; set; }
        public string name_short { get; set; }
        public string name_abbrev { get; set; }
        public string principal_activities { get; set; }
        public string industry_group_name { get; set; }
        public string sector_name { get; set; }
        public DateTime listing_date { get; set; }
        public object delisting_date { get; set; }
        public string web_address { get; set; }
        public string mailing_address { get; set; }
        public string phone_number { get; set; }
        public string fax_number { get; set; }
        public string registry_name { get; set; }
        public string registry_address { get; set; }
        public string registry_phone_number { get; set; }
        public bool foreign_exempt { get; set; }
        public string investor_relations_url { get; set; }
        public string fiscal_year_end { get; set; }
        public string logo_image_url { get; set; }
        public string primary_share_code { get; set; }
        public bool recent_announcement { get; set; }
        public List<string> products { get; set; }
        public List<LatestAnnualReportASX> latest_annual_reports { get; set; }
        public PrimaryShareASX primary_share { get; set; }
    }

}
