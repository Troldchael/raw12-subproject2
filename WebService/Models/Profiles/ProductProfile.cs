using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataServiceLib.Framework;

namespace WebService.Models.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDetailsDto>();
            CreateMap<Product, ProductListElementDto>()
                .ForMember(src => src.Category,
                    opt => opt.MapFrom(x => x.Category.Name));
        }
    }
}
