using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnicalTestLibrary.Api.Infrastructure.Context;
using TecnicalTestLibrary.Api.Infrastructure.Entities;
//using TecnicalTestLibrary.Api.Infrastructure.Exceptions;
using TecnicalTestLibrary.Api.Infrastructure.Repositories.IRepositories;

namespace TecnicalTestLibrary.Api.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext context;

        public BookRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task Delete(int id)
        {
            var book = await context.Books.FindAsync(id);

            if (book == null)
            {
                throw new Exception("The entity is null.");
            }

            context.Books.Remove(book);

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await context.Books.ToListAsync();
        }

        public async Task<Book> GetById(int id)
        {
            return await context.Books.FindAsync(id);
        }

        public async Task<Book> Insert(Book book)
        {
            var bookExist = await context.Books.AnyAsync(p => p.Id == book.Id);

            if (bookExist)
            {
                throw new Exception("The book already exist.");
            }

            await context.Books.AddAsync(book);

            await context.SaveChangesAsync();

            return book;
        }

        public async Task<Book> Update(Book book)
        {
            var bookExist = await context.Books.AnyAsync(p => p.Id == book.Id);

            if (!bookExist)
            {
                throw new Exception("The book don't exist.");
            }

            context.Update(book);

            await context.SaveChangesAsync();

            return book;
        }
    }
}
