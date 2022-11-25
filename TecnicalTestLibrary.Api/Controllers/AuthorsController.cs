using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecnicalTestLibrary.Api.Application;
using TecnicalTestLibrary.Api.Domain.Models;

namespace TecnicalTestLibrary.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorApplication author;

        public AuthorsController(IAuthorApplication author)
        {
            this.author = author;
        }

        [HttpGet]
        public async Task<IEnumerable<AuthorDto>> GetAllAuthors()
        {
            var authors = await author.GetAll();

            return authors;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDto>> GetAuthorById(int id)
        {
            var authorById = await author.GetById(id);

            return Ok(authorById);
        }

        [HttpPost]
        public async Task<ActionResult<AuthorDto>> CreateAuthor(AuthorDto authorDto)
        {
            var newAuthor = await author.Insert(authorDto);

            return Ok(newAuthor);
        }

        [HttpPut]
        public async Task<ActionResult<UpdateAuthor>> UpdateAuthor(UpdateAuthor updateAuthor)
        {
            var authorUpdated = await author.Update(updateAuthor);

            return Ok(authorUpdated);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAuthor(int id)
        {
            await author.Delete(id);
        }
    }
}
