using Application.DTOs.Common;
using Application.DTOs.Common.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.CinemaDtos.Validators
{
    public class UpdateCinemaDtoValidator : AbstractValidator<UpdateCinemaDto>
    {
        public UpdateCinemaDtoValidator()
        {
            Include(new ICinemaDtoValidator());
            Include(new IBaseDtoValidator());
        }
    }
}
