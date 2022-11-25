using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnicalTestLibrary.Api.Infrastructure.Entities;

namespace TecnicalTestLibrary.Api.Infrastructure.Repositories.IRepositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAll();
        Task<Book> GetById(int id);
        Task<Book> Insert(Book book);
        Task<Book> Update(Book book);
        Task Delete(int id);
    }
}
