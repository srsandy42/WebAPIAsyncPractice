using AutoMapper;
using WebApiProjectAsync.Dto;
using WebApiProjectAsync.Model;

namespace WebApiProjectAsync.Profiles
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Product,ProductDto>().ReverseMap();
        }
    }
}
