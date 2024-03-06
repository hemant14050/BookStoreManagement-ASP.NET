using AutoMapper;
using BookStoreManagement.Common.DTOs;
using BookStoreManagement.Common.Interfaces;
using BookStoreManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreManagement.Repository
{
    public class AuthorsRepository : IAuthorsRepository
    {
        private readonly BookStoreDBContext _dbContext;
        private readonly IMapper _mapper;

        public AuthorsRepository(BookStoreDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ResponseDTO<List<AuthorDTO>>> GetAllAuthors()
        {
            try
            {
                List<AuthorDTO> authorsList = await _dbContext.Authors.Select(author => _mapper.Map<AuthorDTO>(author)).ToListAsync();
                return new ResponseDTO<List<AuthorDTO>>
                {
                    Success = true,
                    Message = "Authors retrived successfully.",
                    Data = authorsList
                };
            }
            catch(Exception ex)
            {
                Console.WriteLine("An exception: ", ex);
                return new ResponseDTO<List<AuthorDTO>>
                {
                    Success = false,
                    Message = "Something wents wrong!"
                };
            }
        }
    }
}
