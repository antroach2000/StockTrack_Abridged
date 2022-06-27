using StockTrade.API.Models.ASX;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockTrade.API.API.Interfaces
{
    public interface IAsxComAPI
    {
        Task<CompanyASX> GetCompany(string stockCode);
        Task<IList<MarketPriceASX>> GetCompanyShareData(string stockCode, int days);
        Task<LatestAnnualReportASX> GetCompanyAnnualReports(string stockCode);
        Task<object> GetCompanyDividends(string stockCode, int? yearsHistory);
        Task<CompanyOfficerASX> GetCompanyPeople(string stockCode);
        Task<AnnouncementASX> GetCompanyAnnouncements(string stockCode);
    }
}