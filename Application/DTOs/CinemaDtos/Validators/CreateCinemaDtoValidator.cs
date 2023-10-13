using Application.DTOs.MovieDtos.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.DTOs.CinemaDtos.Validators
{
    public class CreateCinemaDtoValidator :  AbstractValidator<CreateCinemaDto>
    {
        public CreateCinemaDtoValidator()
        {
            Include(new ICinemaDtoValidator());
        }
    }
}
