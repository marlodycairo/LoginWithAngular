using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnicalTestLibrary.Api.Domain.Models;

namespace TecnicalTestLibrary.Api.Domain
{
    public interface IAuthorDomain
    {
        Task<IEnumerable<AuthorDto>> GetAll();
        Task<AuthorDto> GetById(int id);
        Task<AuthorDto> Insert(AuthorDto author);
        Task<UpdateAuthor> Update(UpdateAuthor author);
        Task Delete(int id);
    }
}
