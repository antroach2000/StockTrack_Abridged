using AutoMapper;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using StockTrade.API.Models.ASX;
using StockTrade.API.API.Interfaces;

namespace StockTrade.API.API
{
    public class AsxComAPI : IAsxComAPI
    {
        private readonly IHttpClientFactory _clientFactory;
        public AsxComAPI(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<CompanyASX> GetCompany(string stockCode)
        {
            var client = _clientFactory.CreateClient(GlobalConstants.ASX_API);
            var response = await client.GetAsync($"company/{stockCode}?fields=primary_share");

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            var responseJson = JsonConvert.DeserializeObject<CompanyASX>(response.Content.ReadAsStringAsync().Result);

            return responseJson;
        }
        public async Task<LatestAnnualReportASX> GetCompanyAnnualReports(string StockCode)
        {
            var client = _clientFactory.CreateClient(GlobalConstants.ASX_API);
            var response = await client.GetAsync($"company/{StockCode}?fields=latest_annual_reports");

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            var responseJson = JsonConvert.DeserializeObject<AnnualReportASX>(response.Content.ReadAsStringAsync().Result);

            return responseJson.latest_annual_reports != null ? responseJson.latest_annual_reports[0] : null;
        }
        public async Task<object> GetCompanyDividends(string stockCode, int? yearsHistory)
        {
            var client = _clientFactory.CreateClient(GlobalConstants.ASX_API);
            var response = await client.GetAsync($"company/{stockCode}/dividends");

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            var dividendFull = JsonConvert.DeserializeObject<List<DividendFullASX>>(response.Content.ReadAsStringAsync().Result);
            List<DividendHistoryASX> dividendHistory = null;

            if (dividendFull != null)
                dividendFull.Reverse();

            if (yearsHistory != null)
            {
                var responseDividendHistory = await client.GetAsync($"company/{stockCode}/dividends/history?years={yearsHistory}");

                if (responseDividendHistory.StatusCode == HttpStatusCode.OK)
                {
                    dividendHistory = JsonConvert.DeserializeObject<List<DividendHistoryASX>>(responseDividendHistory.Content.ReadAsStringAsync().Result);

                    if (dividendHistory != null)
                        dividendHistory.Reverse();
                }

                return new { dividendFull, dividendHistory };
            }

            return new { dividendFull };
        }
        public async Task<AnnouncementASX> GetCompanyAnnouncements(string stockCode)
        {
            var client = _clientFactory.CreateClient(GlobalConstants.ASX_API);
            var response = await client.GetAsync($"company/{stockCode}/announcements?count=10&market_sensitive=false");

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            var responseJson = JsonConvert.DeserializeObject<AnnouncementASX>(response.Content.ReadAsStringAsync().Result);

            return responseJson;
        }
        public async Task<IList<MarketPriceASX>> GetCompanyShareData(string stockCode, int days)
        {
            var client = _clientFactory.CreateClient(GlobalConstants.ASX_API);
            var response = await client.GetAsync($"share/{stockCode}/prices?interval=daily&count={days}");

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            var responseJson = JsonConvert.DeserializeObject<dynamic>(response.Content.ReadAsStringAsync().Result);
            var transformedResponse = JsonConvert.DeserializeObject<IList<MarketPriceASX>>(responseJson.data.ToString());

            return transformedResponse;
        }
        public async Task<CompanyOfficerASX> GetCompanyPeople(string stockCode)
        {
            var client = _clientFactory.CreateClient(GlobalConstants.ASX_API);
            var response = await client.GetAsync($"company/{stockCode}/people");

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            var responseJson = JsonConvert.DeserializeObject<CompanyOfficerASX>(response.Content.ReadAsStringAsync().Result);

            return responseJson;
        }
    }
}
