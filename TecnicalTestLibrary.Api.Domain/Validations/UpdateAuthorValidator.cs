using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnicalTestLibrary.Api.Domain.Models;
using TecnicalTestLibrary.Api.Infrastructure.Repositories.IRepositories;

namespace TecnicalTestLibrary.Api.Domain.Validations
{
    public class UpdateAuthorValidator : AbstractValidator<UpdateAuthor>
    {
        private readonly IAuthorRepository authorRepo;

        public UpdateAuthorValidator(IAuthorRepository authorRepo)
        {
            this.authorRepo = authorRepo;

            RuleFor(author => author.Id)
                .Cascade(CascadeMode.Stop)
                .NotEmpty();

            RuleFor(author => author.Id)
                .Cascade(CascadeMode.Stop)
                .MustAsync(async (id, cancellation) =>
                {
                    var authors = (await authorRepo.GetAll()).Any(x => x.Id == id);

                    return authors;
                }).WithMessage("author no existe.");

            RuleFor(p => p.FullName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("{PropertyName} All data marked with an asterisk are required.");

            RuleFor(p => p.BirthDate)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("All data marked with an asterisk are required.");

            RuleFor(p => p.CityOrigin)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("All data marked with an asterisk are required.");

            RuleFor(p => p.EMail)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("All data marked with an asterisk are required.");
        }
    }
}
