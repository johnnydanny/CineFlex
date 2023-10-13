using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.MovieDtos.Validators
{
    public class IMovieDtoValidator : AbstractValidator<IMovieDto>
    {
        public IMovieDtoValidator()
        {
           RuleFor(x => x.Title)
              .NotEmpty().WithMessage("{PropertyName} is required.")
              .MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");


            RuleFor(x => x.Genre)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .MaximumLength(100).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
