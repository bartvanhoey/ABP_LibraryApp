using System;
using Abp.AutoMapper;
using LibraryApp.Models;

namespace LibraryApp.Authors.Dtos
{
    [AutoMapFrom(typeof(Author))]
    public class GetAuthorOutput
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }
    }
}