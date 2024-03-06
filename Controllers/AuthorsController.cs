﻿using Microsoft.AspNetCore.Mvc;
using BookStoreManagement.Common.Interfaces;
using BookStoreManagement.Common.DTOs;

namespace BookStoreManagement.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthorsController : Controller
    {
        private readonly IAuthorsRepository _authorsRespository;

        public AuthorsController(IAuthorsRepository authorsRespository)
        {
            _authorsRespository = authorsRespository;
        }

        // GET - api/v1/[controller]
        [HttpGet]
        public async Task<ActionResult<List<AuthorDTO>>> GetAllAuthors()
        {
            ResponseDTO<List<AuthorDTO>> res = await _authorsRespository.GetAllAuthors(); 
            if(res.Success)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest(res);
            }
        }
    }
}
