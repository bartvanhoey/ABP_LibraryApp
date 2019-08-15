namespace LibraryApp.Books.Dtos
{
    public class CreateBookInput
    {
        public string DisplayName { get; set; }
        public int? TotalPageNumber { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
    }
}