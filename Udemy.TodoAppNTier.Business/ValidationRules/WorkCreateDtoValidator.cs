using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.TodoAppNtier.Dtos.WorkDto;

namespace Udemy.TodoAppNTier.Business.ValidationRules
{
    public class WorkCreateDtoValidator : AbstractValidator<WorkCreateDto>
    {
        public WorkCreateDtoValidator()
        {
            RuleFor(x=>x.Definition).NotEmpty().WithMessage("İş tanım alanı boş geçilemez");
        }
    }
}
