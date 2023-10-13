using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.MovieDtos.Validators
{
    public class CreateMovieDtoValidator : AbstractValidator<CreateMovieDto>
    {
        public CreateMovieDtoValidator()
        {
                Include(new IMovieDtoValidator());    // ImovieDto is an interface for this purpose(resuable validation)
        }
    }
}
