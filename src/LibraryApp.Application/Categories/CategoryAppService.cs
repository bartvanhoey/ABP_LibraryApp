using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.ObjectMapping;
using LibraryApp.Categories.Dtos;
using LibraryApp.Models;

namespace LibraryApp.Categories
{
    public class CategoryAppService : ApplicationService, ICategoryAppService
    {
        private readonly ICategoryManager _categoryManager;
        private readonly IObjectMapper _mapper;

        public CategoryAppService(ICategoryManager categoryManager,IObjectMapper mapper)
        {
            _categoryManager = categoryManager;
            _mapper = mapper;
        }

        public IEnumerable<GetCategoryOutput> ListAll()
        {
            var categories = _categoryManager.GetAllList();
            var output = _mapper.Map<IEnumerable<GetCategoryOutput>>(categories);
            return output;
        }

        public async Task Create(CreateCategoryInput input)
        {
            var category = _mapper.Map<Category>(input);
            await _categoryManager.Create(category);
        }

        public void Update(UpdateCategoryInput input)
        {
            var category = _mapper.Map<Category>(input);
            _categoryManager.Update(category);
        }

        public void Delete(DeleteCategoryInput input)
        {
            _categoryManager.Delete(input.Id);
        }

        public GetCategoryOutput GetCategoryById(GetCategoryInput input)
        {
            var category = _categoryManager.GetCategoryById(input.Id);
            var output = _mapper.Map<GetCategoryOutput>(category);
            return output;
        }
    }
}