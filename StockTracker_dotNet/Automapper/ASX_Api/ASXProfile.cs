using AutoMapper;
using StockTrade.API.Models.ASX;
using StockTrade.API.Models.DTO;

namespace StockTrade.API.Automapper.ASX_Api
{
    public class ASXProfile : Profile
    {
        public ASXProfile()
        {
            CreateMap<AnnouncementASX, AnnouncementDTO>()
                    .ForMember(dest => dest.announcements, opt => opt.MapFrom(src => src.data))
                    .ForMember(dest => dest.pagingNextUrl, opt => opt.MapFrom(src => src.paging_next_url));

            CreateMap<AnnouncementItemASX, AnnouncementItemDTO>()
                    .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.id))
                    .ForMember(dest => dest.documentReleaseDate, opt => opt.MapFrom(src => src.document_release_date))
                    .ForMember(dest => dest.documentDate, opt => opt.MapFrom(src => src.document_date))
                    .ForMember(dest => dest.url, opt => opt.MapFrom(src => src.url))
                    .ForMember(dest => dest.relativeUrl, opt => opt.MapFrom(src => src.relative_url))
                    .ForMember(dest => dest.header, opt => opt.MapFrom(src => src.header))
                    .ForMember(dest => dest.marketSensitive, opt => opt.MapFrom(src => src.market_sensitive))
                    .ForMember(dest => dest.numberPages, opt => opt.MapFrom(src => src.number_of_pages))
                    .ForMember(dest => dest.size, opt => opt.MapFrom(src => src.size))
                    .ForMember(dest => dest.legacyAnnouncement, opt => opt.MapFrom(src => src.legacy_announcement));

            CreateMap<LatestAnnualReportASX, LatestAnnualReportDTO>()
                    .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.id))
                    .ForMember(dest => dest.documentReleaseDate, opt => opt.MapFrom(src => src.document_release_date))
                    .ForMember(dest => dest.documentDate, opt => opt.MapFrom(src => src.document_date))
                    .ForMember(dest => dest.url, opt => opt.MapFrom(src => src.url))
                    .ForMember(dest => dest.relativeUrl, opt => opt.MapFrom(src => src.relative_url))
                    .ForMember(dest => dest.header, opt => opt.MapFrom(src => src.header))
                    .ForMember(dest => dest.marketSensitive, opt => opt.MapFrom(src => src.market_sensitive))
                    .ForMember(dest => dest.numberOfPages, opt => opt.MapFrom(src => src.number_of_pages))
                    .ForMember(dest => dest.size, opt => opt.MapFrom(src => src.size))
                    .ForMember(dest => dest.legacyAnnouncement, opt => opt.MapFrom(src => src.legacy_announcement));
        }
    }
}