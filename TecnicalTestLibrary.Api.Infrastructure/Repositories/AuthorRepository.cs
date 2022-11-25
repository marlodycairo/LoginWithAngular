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
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext context;

        public AuthorRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task Delete(int id)
        {
            var author = await context.Authors.FindAsync(id);

            if (author == null)
            {
                throw new Exception("The author is null.");
            }

            context.Authors.Remove(author);

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Author>> GetAll()
        {
            return await context.Authors.ToListAsync();
        }

        public async Task<Author> GetById(int id)
        {
            return await context.Authors.FindAsync(id);
        }

        public async Task<Author> Insert(Author author)
        {
            var authorExist = await context.Authors.AnyAsync(p => p.Id == author.Id);

            if (authorExist)
            {
                throw new Exception("The author already exist.");
            }

            await context.Authors.AddAsync(author);

            await context.SaveChangesAsync();

            return author;
        }

        public async Task<Author> Update(Author author)
        {
            //var authorExist = await context.Authors.AnyAsync(p => p.Id == author.Id);

            //if (!authorExist)
            //{
            //    throw new Exception("The author don't exist.");
            //}
            context.ChangeTracker.Clear();

            context.Update(author);

            await context.SaveChangesAsync();

            return author;
        }
    }
}
