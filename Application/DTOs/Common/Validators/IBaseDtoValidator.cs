using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Common.Validators
{
    public class IBaseDtoValidator : AbstractValidator<BaseDto>
    {
        public IBaseDtoValidator()
        {
            RuleFor(x => x.Id)
             .NotNull()
             .WithMessage("Id is required and cannot be null.")
             .NotEqual(Guid.Empty)
             .WithMessage("Id must be a valid Guid.");
        }
    }
}
