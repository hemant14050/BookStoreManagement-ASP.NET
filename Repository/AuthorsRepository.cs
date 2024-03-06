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
        private readonly ILogger<AuthorsRepository> _logger;

        public AuthorsRepository(BookStoreDBContext dbContext, IMapper mapper, ILogger<AuthorsRepository> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
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
                _logger.LogError(ex.Message);
                return new ResponseDTO<List<AuthorDTO>>
                {
                    Success = false,
                    Message = "Something wents wrong!"
                };
            }
        }

        public async Task<ResponseDTO<AuthorDTO>> GetAuthorById(int authorId)
        {
            try
            {
                Author? currAuthor = await _dbContext.Authors.FirstOrDefaultAsync(a => a.Id == authorId);
                if(currAuthor == null)
                {
                    return new ResponseDTO<AuthorDTO>
                    {
                        Success = false,
                        Message = "Invalid author id."
                    };
                }

                return new ResponseDTO<AuthorDTO>
                {
                    Success = true,
                    Message = "Author retrived successfully.",
                    Data = _mapper.Map<AuthorDTO>(currAuthor)
                };
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return new ResponseDTO<AuthorDTO>
                {
                    Success = false,
                    Message = "Something wents wrong!"
                };
            }
        }
    }
}
