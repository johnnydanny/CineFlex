using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.MovieDtos.Validators
{
    public class UpdateMovieDtoValidator : AbstractValidator<UpdateMovieDto>
    {
        public UpdateMovieDtoValidator()
        {
            Include(new IMovieDtoValidator());
            // now because we are updating the movie, the id must be valid

            RuleFor(x => x.Id)
              .NotNull()
              .WithMessage("Id is required and cannot be null.")
              .NotEqual(Guid.Empty)
              .WithMessage("Id must be a valid Guid.");
        }
    }
}
