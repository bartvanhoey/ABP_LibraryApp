using Abp.AutoMapper;
using LibraryApp.Models;

namespace LibraryApp.Books.Dtos
{
    [AutoMapFrom(typeof(Book))]

    public class GetBookOutput
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public int? TotalPageNumber { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
    }
}