using Application.DTOs.MovieDtos;
using Application.DTOs.MovieDtos.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.CinemaDtos.Validators
{
    public class ICinemaDtoValidator : AbstractValidator<ICinemaDto>
    {
        public ICinemaDtoValidator()
        {
           
            RuleFor(x => x.ContactInformation)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");


            RuleFor(x => x.Location)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");


            RuleFor(x => x.ContactInformation)
               .NotEmpty().WithMessage("Contact information is required.")
               .MaximumLength(150).WithMessage("Contact information must not exceed 150 characters.");
        }
    }
}
