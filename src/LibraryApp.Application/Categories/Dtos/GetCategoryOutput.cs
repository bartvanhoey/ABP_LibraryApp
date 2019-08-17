using Abp.AutoMapper;
using LibraryApp.Models;

namespace LibraryApp.Categories.Dtos
{
    [AutoMapFrom(typeof(Category))]

    public class GetCategoryOutput
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
    }
}