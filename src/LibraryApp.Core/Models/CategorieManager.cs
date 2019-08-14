namespace LibraryApp.Models
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Abp.Domain.Repositories;
    using Abp.Domain.Services;
    using Abp.UI;

    namespace LibraryApp.Models
    {
        public class CategoryManager : DomainService, ICategoryManager
        {
            private readonly IRepository<Category> _repositoryCategory;

            public CategoryManager(IRepository<Category> repositoryCategory)
            {
                _repositoryCategory = repositoryCategory;
            }

            public IEnumerable<Category> GetAllList()
            {
                return _repositoryCategory.GetAllIncluding(x => x.Books);
            }

            public Category GetCategoryById(int id)
            {
                return _repositoryCategory.Get(id);
            }

            public async Task<Category> Create(Category entity)
            {
                var category = _repositoryCategory.FirstOrDefault(x => x.Id == entity.Id);
                if (category != null)
                    throw new UserFriendlyException("Already Exist");
                return await _repositoryCategory.InsertAsync(entity);
            }

            public void Update(Category entity)
            {
                _repositoryCategory.Update(entity);
            }

            public void Delete(int id)
            {
                var category = _repositoryCategory.FirstOrDefault(x => x.Id == id);
                if (category == null)
                    throw new UserFriendlyException("No Data Found");
                _repositoryCategory.Delete(category);
            }
        }
    }
}