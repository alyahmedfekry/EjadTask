using Domain.Abstractions.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Samurai.Update
{
    public class UpdateSamuraiCommandValidator : AbstractValidator<UpdateSamuraiCommand>
    {
        public UpdateSamuraiCommandValidator(ISamuraiRepository samuraiRepository)
        {
            RuleFor(h => h.Name).MustAsync(async (name, _) =>
            {
                return await samuraiRepository.IsUniqueName(name);
            }).WithMessage("name must be unique!!");
            RuleFor(h => h.Weight).NotEmpty().WithMessage("Weight is Required!!");
            RuleFor(h => h.Role).NotEmpty().WithMessage("Role is Required!!");
            RuleFor(h => h.Age).NotEmpty().WithMessage("Age is Required!!");
            RuleFor(h => h.Hight).NotEmpty().WithMessage("Hight is Required!!");
        }
    }
}
