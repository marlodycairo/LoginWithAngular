using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnicalTestLibrary.Api.Domain.Models;

namespace TecnicalTestLibrary.Api.Domain.Validations
{
    public class AuthorValidator : AbstractValidator<AuthorDto>
    {
        public AuthorValidator()
        {
            RuleFor(p => p.FullName).NotNull()
                .NotEmpty().WithMessage("{PropertyName} All data marked with an asterisk are required.");

            RuleFor(p => p.BirthDate).NotEmpty().WithMessage("All data marked with an asterisk are required.");

            RuleFor(p => p.CityOrigin).NotNull()
                .NotEmpty().WithMessage("All data marked with an asterisk are required.");

            RuleFor(p => p.EMail).NotNull()
                .NotEmpty().WithMessage("All data marked with an asterisk are required.");
        }
    }
}
