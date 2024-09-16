using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ReqDtos.ProductReqDtos;
using MultiShop.Catalog.Dtos.ResDtos.ProductResDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.ServiceResponse;
using MultiShop.Catalog.Services.Dtos.ResDtos.CategoryResDtos;
using MultiShop.Catalog.Services.Interfaces;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMapper _mapper;

        public ProductService(
            IDatabaseSettings _databaseSettings,
            IMapper mapper)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _mapper = mapper;
        }
        public async Task<ServiceResponse<Product>> CreateProductAsync(CreateProductReqDto reqDto)
        {
            var result = new ServiceResponse<Product>();

            try
            {
                var data = _mapper.Map<Product>(reqDto);

                await _productCollection.InsertOneAsync(data);

                result.SetSuccesCreate(data);
            }
            catch (Exception ex)
            {
                result.SetError(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResponse<Product>> DeleteProductAsync(string id)
        {
            var result = new ServiceResponse<Product>();

            try
            {
                await _productCollection.DeleteOneAsync(x => x.Id == id);

                result.SetSuccesDelete();
            }
            catch (Exception ex)
            {
                result.SetError(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResponse<List<GetAllProductResDto>>> GetAllProductAsync()
        {
            var result = new ServiceResponse<List<GetAllProductResDto>>();

            try
            {
                var collectResult = await _productCollection.Find(x => true).ToListAsync();

                var datas = _mapper.Map<List<GetAllProductResDto>>(collectResult);

                result.SetSuccessList(datas);
            }
            catch (Exception ex)
            {
                result.SetError(ex.Message);
            }

            return result;
        }
  

        public async Task<ServiceResponse<GetProductResDto>> GetProductAsync(string id)
        {
            var result = new ServiceResponse<GetProductResDto>();

            try
            {
                var collectResult = await _productCollection.Find<Product>(x => x.Id == id).FirstOrDefaultAsync();

                var data = _mapper.Map<GetProductResDto>(collectResult);

                result.SetSuccess(data);
            }
            catch (Exception ex)
            {
                result.SetError(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResponse<Product>> UpdateProductAsync(UpdateProductReqDto reqDto)
        {

            var result = new ServiceResponse<Product>();

            try
            {
                var data = _mapper.Map<Product>(reqDto);

                await _productCollection.FindOneAndReplaceAsync(x => x.Id == reqDto.Id, data);

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