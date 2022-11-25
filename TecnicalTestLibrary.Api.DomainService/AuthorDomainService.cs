using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnicalTestLibrary.Api.Domain;
using TecnicalTestLibrary.Api.Domain.Models;
using TecnicalTestLibrary.Api.Infrastructure.Entities;
using TecnicalTestLibrary.Api.Infrastructure.Repositories.IRepositories;

namespace TecnicalTestLibrary.Api.DomainService
{
    public class AuthorDomainService : IAuthorDomain
    {
        private readonly IAuthorRepository authorRepository;
        private readonly IMapper mapper;

        public AuthorDomainService(IAuthorRepository authorRepository, IMapper mapper)
        {
            this.authorRepository = authorRepository;
            this.mapper = mapper;
        }

        public async Task Delete(int id)
        {
            await authorRepository.Delete(id);
        }

        public async Task<IEnumerable<AuthorDto>> GetAll()
        {
            var authors = await authorRepository.GetAll();

            var authorsDto = mapper.Map<IEnumerable<AuthorDto>>(authors);

            return authorsDto;
        }

        public async Task<AuthorDto> GetById(int id)
        {
            var author = await authorRepository.GetById(id);

            var authorDto = mapper.Map<AuthorDto>(author);

            return authorDto;
        }

        public async Task<AuthorDto> Insert(AuthorDto authorDto)
        {
            var author = mapper.Map<Author>(authorDto);

            await authorRepository.Insert(author);

            return authorDto;
        }

        public async Task<UpdateAuthor> Update(UpdateAuthor author)
        {
            var _author = mapper.Map<Author>(author);

            await authorRepository.Update(_author);

            return author;
        }
    }
}
