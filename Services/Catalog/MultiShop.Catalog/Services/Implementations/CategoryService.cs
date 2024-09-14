using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.ServiceResponse;
using MultiShop.Catalog.Services.Dtos.ReqDtos.CategoryReqDtos;
using MultiShop.Catalog.Services.Dtos.ResDtos.CategoryResDtos;
using MultiShop.Catalog.Services.Interfaces;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IDatabaseSettings _databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }
        public async Task<ServiceResponse<Category>> CreateCategoryAsync(CreateCategoryDto reqDto)
        {
            var result = new ServiceResponse<Category>();

            try
            {
                var data = _mapper.Map<Category>(reqDto);

                await _categoryCollection.InsertOneAsync(data);

                result.SetSuccesCreate(data);
            }
            catch (Exception ex)
            {
                result.SetError(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResponse<Category>> DeleteCategoryAsync(string id)
        {
            var result = new ServiceResponse<Category>();

            try
            {
                await _categoryCollection.DeleteOneAsync(x => x.Id == id);

                result.SetSuccesDelete();
            }
            catch (Exception ex)
            {
                result.SetError(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResponse<List<GetAllCategoriesResDto>>> GetAllCategoriesAsync()
        {
            var result = new ServiceResponse<List<GetAllCategoriesResDto>>();

            try
            {
                var collectResult = await _categoryCollection.Find(x => true).ToListAsync();

                var datas =  _mapper.Map<List<GetAllCategoriesResDto>>(collectResult);

                result.SetSuccessList(datas);
            }
            catch(Exception ex)
            {
                result.SetError(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResponse<GetCategoryResDto>> GetCategoryAsync(string id)
        {
            var result = new ServiceResponse<GetCategoryResDto>();

            try
            {
                var collectResult = await _categoryCollection.Find<Category>(x => x.Id == id).FirstOrDefaultAsync();

                var data = _mapper.Map<GetCategoryResDto>(collectResult);

                result.SetSuccess(data);
            }
            catch(Exception ex)
            {
                result.SetError(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResponse<Category>> UpdateCategoryAsync(UpdateCategoryDto reqDto)
        {
            var result = new ServiceResponse<Category>();

            try
            {
                var data = _mapper.Map<Category>(reqDto);

                await _categoryCollection.FindOneAndReplaceAsync(x => x.Id == reqDto.Id, data);

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