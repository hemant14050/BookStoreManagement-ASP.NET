using AutoMapper;
using BookStoreManagement.Common.DTOs;
using BookStoreManagement.Models;

namespace BookStoreManagement.Common.Helpers
{
    public class ApplicationModelMapping : Profile
    {
        public ApplicationModelMapping()
        {
            CreateMap<Author, AuthorDTO>().ReverseMap();
        }
    }
}
