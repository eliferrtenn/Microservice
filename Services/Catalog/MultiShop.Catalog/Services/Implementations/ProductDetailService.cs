using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ReqDtos.ProductDetailReqDtos;
using MultiShop.Catalog.Dtos.ResDtos.ProductDetailResDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.ServiceResponse;
using MultiShop.Catalog.Services.Interfaces;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.Implementations
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IMongoCollection<ProductDetail> _productDetailCollection;
        private readonly IMapper _mapper;

        public ProductDetailService(IDatabaseSettings _databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productDetailCollection = database.GetCollection<ProductDetail>(_databaseSettings.ProductDetailCollectionName);
            _mapper = mapper;
        }

        public async Task<ServiceResponse<ProductDetail>> CreateProductDetailAsync(CreateProductDetailReqDto reqDto)
        {
            var result = new ServiceResponse<ProductDetail>();

            try
            {
                var data = _mapper.Map<ProductDetail>(reqDto);

                await _productDetailCollection.InsertOneAsync(data);

                result.SetSuccesCreate(data);
            }
            catch (Exception ex)
            {
                result.SetError(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResponse<ProductDetail>> DeleteProductDetailAsync(string id)
        {
            var result = new ServiceResponse<ProductDetail>();

            try
            {
                await _productDetailCollection.DeleteOneAsync(x => x.Id == id);

                result.SetSuccesDelete();
            }
            catch (Exception ex)
            {
                result.SetError(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResponse<List<GetAllProductDetailResDto>>> GetAllProductDetailAsync()
        {
            var result = new ServiceResponse<List<GetAllProductDetailResDto>>();

            try
            {
                var collectResult = await _productDetailCollection.Find(x => true).ToListAsync();

                var datas = _mapper.Map<List<GetAllProductDetailResDto>>(collectResult);

                result.SetSuccessList(datas);
            }
            catch (Exception ex)
            {
                result.SetError(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResponse<GetProductDetailResDto>> GetProductDetailAsync(string id)
        {
            var result = new ServiceResponse<GetProductDetailResDto>();

            try
            {
                var collectResult = await _productDetailCollection.Find<ProductDetail>(x => x.Id == id).FirstOrDefaultAsync();

                var data = _mapper.Map<GetProductDetailResDto>(collectResult);

                result.SetSuccess(data);
            }
            catch (Exception ex)
            {
                result.SetError(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResponse<ProductDetail>> UpdateProductDetailAsync(UpdateProductDetailReqDto reqDto)
        {
            var result = new ServiceResponse<ProductDetail>();

            try
            {
                var data = _mapper.Map<ProductDetail>(reqDto);

                await _productDetailCollection.FindOneAndReplaceAsync(x => x.Id == reqDto.Id, data);

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
