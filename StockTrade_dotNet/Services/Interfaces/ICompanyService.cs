using StockTrade.API.Enums;
using StockTrade.API.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockTrade.API.Services.Interfaces
{
    public interface ICompanyService
    {
        Task<IList<DirectorDTO>> GetCompanyPeople(string stockCode);
        Task<MarketPriceListDTO> GetCompanyShareData(string stockCode, int days);
        Task<LatestAnnualReportDTO> GetCompanyAnnualReports(string stockCode);
        Task<object> GetCompanyDividends(string stockCode, int? yearsHistory);
        Task<AnnouncementDTO> GetCompanyAnnouncements(string stockCode);
    }
}
