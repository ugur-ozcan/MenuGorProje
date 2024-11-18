// MenuGor.Application/Mappings/MappingProfile.cs
using AutoMapper;
using MenuGor.Core.Entities;
using MenuGor.Application.DTOs;

namespace MenuGor.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Admin entity mapping
            CreateMap<Admin, AdminDto>()
                .ForMember(dest => dest.Password, opt => opt.Ignore()) // Password alanını mapping dışında tutuyoruz
                .ReverseMap()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore()); // PasswordHash alanını mapping dışında tutuyoruz

            CreateMap<Company, CompanyDto>()
            .ForMember(dest => dest.BranchCount, opt => opt.MapFrom(src => src.Branches.Count));
            CreateMap<CompanyDto, Company>();

            CreateMap<Branch, BranchDto>().ReverseMap();
            CreateMap<Dealer, DealerDto>().ReverseMap();


        }


    }
}

