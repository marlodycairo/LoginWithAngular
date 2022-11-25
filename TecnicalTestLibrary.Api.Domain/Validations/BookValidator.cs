using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using TecnicalTestLibrary.Api.Domain.Models;

namespace TecnicalTestLibrary.Api.Domain.Validations
{
    public class BookValidator : AbstractValidator<BookDto>
    {
        public BookValidator()
        {
            RuleFor(p => p.Title).NotNull()
                .NotEmpty();

            RuleFor(p => p.Date).NotEmpty();

            RuleFor(p => p.Genre).NotNull()
                .NotEmpty();

            RuleFor(p => p.NumberOfPages).NotNull()
                .NotEmpty();
        }
    }
}
