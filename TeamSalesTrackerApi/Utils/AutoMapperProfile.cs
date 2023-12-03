using AutoMapper;
using TeamSalesTrackerApi.Business.Commands;
using TeamSalesTrackerApi.Dtos;
using TeamSalesTrackerApi.Models;

namespace TeamSalesTrackerApi.Utils
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //USERS
            CreateMap<RegisterUserCommand, User>()
                .ForMember(dest => dest.Password, opt => opt.Ignore());
            CreateMap<User, RegisteredUserDto>();
            CreateMap<RegisterUserCommand, Address>();

            //PRODUCTS
            CreateMap<CreateProductCommand, Product>();
            CreateMap<UpdateProductCommand, Product>();

            //BRANCHES
            CreateMap<CreateBranchCommand, Branch>();
            CreateMap<CreateBranchCommand, Address>();
            CreateMap<Branch, BranchDto>()
                .ForMember(dest => dest.StreetName, opt => opt.MapFrom(src => src.Address.StreetName))
                .ForMember(dest => dest.StreetNumber, opt => opt.MapFrom(src => src.Address.StreetNumber));

     
        }
    }
}
