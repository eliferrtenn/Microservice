using AutoMapper;
using MultiShop.Catalog.Dtos.ReqDtos.CategoryReqDtos;
using MultiShop.Catalog.Dtos.ReqDtos.ProductDetailReqDtos;
using MultiShop.Catalog.Dtos.ReqDtos.ProductImageReqDtos;
using MultiShop.Catalog.Dtos.ReqDtos.ProductReqDtos;
using MultiShop.Catalog.Dtos.ResDtos.CategoryResDtos;
using MultiShop.Catalog.Dtos.ResDtos.ProductDetailResDtos;
using MultiShop.Catalog.Dtos.ResDtos.ProductImageResDtos;
using MultiShop.Catalog.Dtos.ResDtos.ProductResDtos;
using MultiShop.Catalog.Entities;

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
            CreateMap<ProductImage, CreateProductImagReqDto>().ReverseMap();
            CreateMap<ProductImage, UpdateProductImagReqDto>().ReverseMap();
        }
    }
}