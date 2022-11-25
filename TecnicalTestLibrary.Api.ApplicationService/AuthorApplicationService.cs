using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnicalTestLibrary.Api.Application;
using TecnicalTestLibrary.Api.Domain;
using TecnicalTestLibrary.Api.Domain.Models;

namespace TecnicalTestLibrary.Api.ApplicationService
{
    public class AuthorApplicationService : IAuthorApplication
    {
        private readonly IAuthorDomain authorDomain;

        public AuthorApplicationService(IAuthorDomain authorDomain)
        {
            this.authorDomain = authorDomain;
        }

        public async Task Delete(int id)
        {
            await authorDomain.Delete(id);
        }

        public async Task<IEnumerable<AuthorDto>> GetAll()
        {
            return await authorDomain.GetAll();
        }

        public async Task<AuthorDto> GetById(int id)
        {
            return await authorDomain.GetById(id);
        }

        public async Task<AuthorDto> Insert(AuthorDto author)
        {
            return await authorDomain.Insert(author);
        }

        public async Task<UpdateAuthor> Update(UpdateAuthor author)
        {
            return await authorDomain.Update(author);
        }
    }
}
