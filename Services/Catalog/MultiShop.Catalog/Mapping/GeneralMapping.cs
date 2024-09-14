using AutoMapper;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.Dtos.ReqDtos.CategoryReqDtos;
using MultiShop.Catalog.Services.Dtos.ReqDtos.ProductDetailReqDtos;
using MultiShop.Catalog.Services.Dtos.ReqDtos.ProductImageReqDtos;
using MultiShop.Catalog.Services.Dtos.ReqDtos.ProductReqDtos;
using MultiShop.Catalog.Services.Dtos.ResDtos.CategoryResDtos;
using MultiShop.Catalog.Services.Dtos.ResDtos.ProductDetailResDtos;
using MultiShop.Catalog.Services.Dtos.ResDtos.ProductImageResDtos;
using MultiShop.Catalog.Services.Dtos.ResDtos.ProductResDtos;

namespace MultiShop.Catalog.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping() 
        {
            CreateMap<Category, GetAllCategoriesResDto>().ReverseMap();
            CreateMap<Category, GetCategoryResDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();

            CreateMap<Product, GetAllProductResDto>().ReverseMap();
            CreateMap<Product, GetProductResDto>().ReverseMap();
            CreateMap<Product, CreateProductReqDto>().ReverseMap();
            CreateMap<Product, UpdateProductReqDto>().ReverseMap();

            CreateMap<ProductDetail, GetAllProductDetailResDto>().ReverseMap();
            CreateMap<ProductDetail, GetProductDetailResDto>().ReverseMap();
            CreateMap<ProductDetail, CreateProductDetailReqDto>().ReverseMap();
            CreateMap<ProductDetail, UpdateProductDetailReqDto>().ReverseMap();

            CreateMap<ProductImage, GetAllProductImageResDto>().ReverseMap();
            CreateMap<ProductImage, GetProductImageResDto>().ReverseMap();
            CreateMap<ProductImage, CreateProductImageReqDto>().ReverseMap();
            CreateMap<ProductImage, UpdateProductImageReqDto>().ReverseMap();
        }
    }
}