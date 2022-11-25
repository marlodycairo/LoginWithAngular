using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnicalTestLibrary.Api.Infrastructure.Entities;

namespace TecnicalTestLibrary.Api.Infrastructure.Repositories.IRepositories
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAll();
        Task<Author> GetById(int id);
        Task<Author> Insert(Author author);
        Task<Author> Update(Author author);
        Task Delete(int id);
    }
}
