using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.ServiceResponse;
using MultiShop.Catalog.Services.Dtos.ReqDtos.ProductImageReqDtos;
using MultiShop.Catalog.Services.Dtos.ResDtos.ProductImageResDtos;
using MultiShop.Catalog.Services.Interfaces;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.Implementations
{
    public class ProductImageService : IProductImageService
    {
        private readonly IMongoCollection<ProductImage> _productImageCollection;
        private readonly IMapper _mapper;

        public ProductImageService(IDatabaseSettings _databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productImageCollection = database.GetCollection<ProductImage>(_databaseSettings.ProductImageCollectionName);
            _mapper = mapper;
        }
        public async Task<ServiceResponse<ProductImage>> CreateProductImageAsync(CreateProductImageReqDto reqDto)
        {
            var result = new ServiceResponse<ProductImage>();

            try
            {
                var data = _mapper.Map<ProductImage>(reqDto);

                await _productImageCollection.InsertOneAsync(data);

                result.SetSuccesCreate(data);
            }
            catch (Exception ex)
            {
                result.SetError(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResponse<ProductImage>> DeleteProductImageAsync(string id)
        {
            var result = new ServiceResponse<ProductImage>();

            try
            {
                await _productImageCollection.DeleteOneAsync(x => x.Id == id);

                result.SetSuccesDelete();
            }
            catch (Exception ex)
            {
                result.SetError(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResponse<List<GetAllProductImageResDto>>> GetAllProductImageAsync()
        {
            var result = new ServiceResponse<List<GetAllProductImageResDto>>();

            try
            {
                var collectResult = await _productImageCollection.Find(x => true).ToListAsync();

                var datas = _mapper.Map<List<GetAllProductImageResDto>>(collectResult);

                result.SetSuccessList(datas);
            }
            catch (Exception ex)
            {
                result.SetError(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResponse<GetProductImageResDto>> GetProductImageAsync(string id)
        {
            var result = new ServiceResponse<GetProductImageResDto>();

            try
            {
                var collectResult = await _productImageCollection.Find<ProductImage>(x => x.Id == id).FirstOrDefaultAsync();

                var data = _mapper.Map<GetProductImageResDto>(collectResult);

                result.SetSuccess(data);
            }
            catch (Exception ex)
            {
                result.SetError(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResponse<ProductImage>> UpdateProductImageAsync(UpdateProductImageReqDto reqDto)
        {
            var result = new ServiceResponse<ProductImage>();

            try
            {
                var data = _mapper.Map<ProductImage>(reqDto);

                await _productImageCollection.FindOneAndReplaceAsync(x => x.Id == reqDto.Id, data);

                result.SetSuccesCreate(data);
            }
            catch (Exception ex)
            {

                result.SetError(ex.Message);
            }

            return result;
        }
    }
}