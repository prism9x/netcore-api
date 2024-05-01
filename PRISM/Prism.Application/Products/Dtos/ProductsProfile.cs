using AutoMapper;
using Prism.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism.Application.Products.Dtos
{
    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            // Config Map cho CreateProduct -> Product
            CreateMap<CreateProductDto, Product > ();
            // Config Map cho Product -> ProductDto
            CreateMap<Product, ProductDto>();
        }
    }
}
