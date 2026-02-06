using AutoMapper;
using FSProduct_CategoryApi.Entities;
using FSProduct_CategoryApi.Entities.Auth;
using FSProduct_CategoryApi.Entities.Dtos.Auth;
using FSProduct_CategoryApi.Entities.Dtos.Categories;
using FSProduct_CategoryApi.Entities.Dtos.Cities;
using FSProduct_CategoryApi.Entities.Dtos.Countiries;
using FSProduct_CategoryApi.Entities.Dtos.Products;

namespace FSProduct_CategoryApi.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateCategoryDto,Category>();
            CreateMap<GetDto,Category>().ReverseMap();
            CreateMap<UpdateCategoryDto, Category>().ReverseMap();

            CreateMap<Product,GetAllProductsDto>()
                .ForMember(dest => dest.CategoryName,
                           opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<Product,GetProductByIdDto>().ForMember(dest => dest.CategoryName,
                           opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<CreateProductDto,Product>().ReverseMap();
            CreateMap<UpdateProductDto,Product>().ReverseMap();

            //Country  //Country)
            CreateMap<Country, GetAllCountryDto>().ReverseMap();
            CreateMap<Country, GetCountryByIdDto>().ReverseMap();
            CreateMap<CreatCountryDto, Country>();
            CreateMap<UpdateCountryDto, Country>();

            //Cities
            CreateMap<City,GetAllCitiesDto>().ForMember(p => p.CountryName, opt => opt.MapFrom(src => src.Country.Name));
            CreateMap<City,GetCityByIdDto>().ForMember(p => p.CountryName, opt => opt.MapFrom(src => src.Country.Name));
            CreateMap<CreateCityDto, City>();
            CreateMap<UpdateCityDto, City>();

            //Auth
            CreateMap<AppUser, RegisterDto>().ReverseMap();
        }
    }
}
