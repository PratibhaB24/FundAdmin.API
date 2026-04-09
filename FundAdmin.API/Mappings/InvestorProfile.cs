using AutoMapper;
using FundAdmin.API.DTOs.Investor;
using FundAdmin.API.Models;

namespace FundAdmin.API.Mappings
{
    public class InvestorProfile : Profile
    {
        public InvestorProfile()
        {
            CreateMap<Investor, InvestorResponseDto>();

            CreateMap<CreateInvestorDto, Investor>()
                .ForMember(dest => dest.InvestorId, opt => opt.MapFrom(_ => Guid.NewGuid()));

            CreateMap<UpdateInvestorDto, Investor>();
        }
    }
}
