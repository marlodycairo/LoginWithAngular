using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnicalTestLibrary.Api.Domain;
using TecnicalTestLibrary.Api.Domain.Models;

namespace TecnicalTestLibrary.Api.DomainService
{
    public class BookDomainService : IBookDomain
    {
        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BookDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<BookDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BookDto> Insert(BookDto book)
        {
            throw new NotImplementedException();
        }

        public Task<BookDto> Update(BookDto book)
        {
            throw new NotImplementedException();
        }
    }
}
