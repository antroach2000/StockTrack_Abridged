using AutoMapper;
using Microsoft.Extensions.Options;
using StockTrade.API.API.Interfaces;
using StockTrade.API.Models;
using StockTrade.API.Models.ASX;
using StockTrade.API.Models.DTO;
using StockTrade.API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockTrade.API.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IAsxComAPI _asxComAPI;
        private readonly IMapper _mapper;
        private readonly IOptions<AppOptions> _settings;

        public CompanyService(IAsxComAPI asxComAPI, IMapper mapper, IOptions<AppOptions> settings)
        {
            _asxComAPI = asxComAPI;
            _mapper = mapper;
            _settings = settings;
        }
        public async Task<IList<DirectorDTO>> GetCompanyPeople(string stockCode)
        {
            if (string.IsNullOrEmpty(stockCode))
                throw new ArgumentException($"{nameof(CompanyService)}->GetCompanyPeople() stockCode:{stockCode} is null or empty");

            var companyPeople = await _asxComAPI.GetCompanyPeople(stockCode);

            if (companyPeople == null)
                return null;

            var directors = companyPeople.directors.Select(x => new DirectorDTO
            {
                firstName = x.first_name,
                fullName = x.full_name,
                lastName = x.last_name,
                middleName = x.middle_name,
                salutation = x.salutation
            }).ToList();

            return directors;
        }
        public async Task<LatestAnnualReportDTO> GetCompanyAnnualReports(string stockCode)
        {
            if (string.IsNullOrEmpty(stockCode))
                throw new ArgumentException($"{nameof(CompanyService)}->GetCompanyAnnualReports() stockCode:{stockCode} is null or empty");

            var companyAnnualReports = await _asxComAPI.GetCompanyAnnualReports(stockCode);

            if (companyAnnualReports == null)
                return null;

            return _mapper.Map<LatestAnnualReportASX, LatestAnnualReportDTO>(companyAnnualReports);
        }
        public async Task<object> GetCompanyDividends(string stockCode, int? yearsHistory)
        {
            if (string.IsNullOrEmpty(stockCode) || yearsHistory <= 0)
                throw new ArgumentException($"{nameof(CompanyService)}->GetCompanyDividends() stockCode:{stockCode} is null or empty or yearsHistory:{yearsHistory} must be greater than zero");

            return await _asxComAPI.GetCompanyDividends(stockCode, yearsHistory);
        }
        public async Task<AnnouncementDTO> GetCompanyAnnouncements(string stockCode)
        {
            if (string.IsNullOrEmpty(stockCode))
                throw new ArgumentException($"{nameof(CompanyService)}->GetCompanyAnnouncements() stockCode:{stockCode} is null or empty");

            var companyAnnouncements = await _asxComAPI.GetCompanyAnnouncements(stockCode);

            if (companyAnnouncements == null)
                return null;

            return _mapper.Map<AnnouncementASX, AnnouncementDTO>(companyAnnouncements);
        }

        public async Task<MarketPriceListDTO> GetCompanyShareData(string stockCode, int days)
        {
            if (string.IsNullOrEmpty(stockCode) || days <= 0)
                throw new ArgumentException($"{nameof(CompanyService)}->GetCompanyShareData() stockCode:{stockCode} is null or empty or days:{days} must be greater than zero");

            var companyShareDataAsx = await _asxComAPI.GetCompanyShareData(stockCode, days);

            if (companyShareDataAsx == null)
                return null;

            var marketPriceListDTO = new MarketPriceListDTO()
            {
                shareDataHistory = new List<MarketPriceModelDTO>()
            };

            //reverse the list, asx.com returns opposite date range to yahoo api
            var shareDataHistory = Enumerable.Reverse(companyShareDataAsx);

            marketPriceListDTO.shareDataHistory = shareDataHistory.Select(x => new MarketPriceModelDTO
            {
                Code = x.code,
                ChangeInPercent = StripPercentageSymbol(x.change_in_percent),
                ChangePrice = x.change_price,
                ClosePrice = x.close_price,
                DayHighPrice = x.day_high_price,
                CloseDate = x.close_date,
                DayLowPrice = x.day_low_price,
                Volume = x.volume
            }).ToList();

            return marketPriceListDTO;
        }

        private double StripPercentageSymbol(string changeInPercent)
        {
            if (string.IsNullOrEmpty(changeInPercent))
                throw new ArgumentException($"{nameof(CompanyService)}->StripPercentageSymbol() changeInPercent:{changeInPercent} is null or empty");

            //asx.com return the changeInPercent formatted as string, so strip off % and convert to a double
            return Convert.ToDouble(changeInPercent.Substring(0, changeInPercent.Length - 1));
        }
    }
}
