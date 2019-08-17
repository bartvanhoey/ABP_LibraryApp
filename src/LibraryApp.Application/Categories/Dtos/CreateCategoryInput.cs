using Abp.AutoMapper;
using LibraryApp.Models;

namespace LibraryApp.Categories.Dtos
{
    [AutoMapTo(typeof(Category))]
    public class CreateCategoryInput
    {
        public string DisplayName { get; set; }
    }
}