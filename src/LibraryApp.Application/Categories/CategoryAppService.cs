using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using AutoMapper;
using LibraryApp.Categories.Dtos;
using LibraryApp.Models;

namespace LibraryApp.Categories
{
    public class CategoryAppService : ApplicationService, ICategoryAppService
    {
        private readonly ICategoryManager _categoryManager;

        public CategoryAppService(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }

        public IEnumerable<GetCategoryOutput> ListAll()
        {
            var categories = _categoryManager.GetAllList();
            var output = Mapper.Map<IEnumerable<Category>, IEnumerable<GetCategoryOutput>>(categories);
            return output;
        }

        public async Task Create(CreateCategoryInput input)
        {
            var category = Mapper.Map<CreateCategoryInput, Category>(input);
            await _categoryManager.Create(category);
        }

        public void Update(UpdateCategoryInput input)
        {
            var category = Mapper.Map<UpdateCategoryInput, Category>(input);
            _categoryManager.Update(category);
        }

        public void Delete(DeleteCategoryInput input)
        {
            _categoryManager.Delete(input.Id);
        }

        public GetCategoryOutput GetCategoryById(GetCategoryInput input)
        {
            var category = _categoryManager.GetCategoryById(input.Id);
            var output = Mapper.Map<Category, GetCategoryOutput>(category);
            return output;
        }
    }
}