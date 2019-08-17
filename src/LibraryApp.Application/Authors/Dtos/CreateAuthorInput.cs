using System;
using Abp.AutoMapper;
using LibraryApp.Models;

namespace LibraryApp.Authors.Dtos
{
    [AutoMapTo(typeof(Author))]
    public class CreateAuthorInput
    {
        public string DisplayName { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }
    }
}