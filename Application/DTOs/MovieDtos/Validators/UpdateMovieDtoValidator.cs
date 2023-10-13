using Application.DTOs.Common.Validators;
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
            Include(new IBaseDtoValidator());
            // now because we are updating the movie, the id must be valid

        }
    }
}
