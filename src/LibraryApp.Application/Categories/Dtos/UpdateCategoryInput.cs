using Abp.AutoMapper;
using LibraryApp.Models;

namespace LibraryApp.Categories.Dtos
{
    [AutoMapTo(typeof(Category))]
    public class UpdateCategoryInput
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
    }
}