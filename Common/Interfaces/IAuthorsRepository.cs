using BookStoreManagement.Common.DTOs;

namespace BookStoreManagement.Common.Interfaces
{
    public interface IAuthorsRepository
    {
        Task<ResponseDTO<List<AuthorDTO>>> GetAllAuthors(); 
    }
}
