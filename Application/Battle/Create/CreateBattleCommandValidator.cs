using Domain.Abstractions.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Battle.Create
{
    public class CreateBattleCommandValidator : AbstractValidator<CreateBattleCommand>
    {
       public CreateBattleCommandValidator(IBattleRepository battleRepository) 
        {
            RuleFor(h => h.Name).NotEmpty().WithMessage("name is required!!")
                .MustAsync(async (name, _) =>
            {
                return await battleRepository.IsUniqueName(name);
            }).WithMessage("name must be unique!!");
        }
    }
}
