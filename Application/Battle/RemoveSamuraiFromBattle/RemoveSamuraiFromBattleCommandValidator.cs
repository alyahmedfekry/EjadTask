using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Battle.RemoveSamuraiFromBattle
{
    public class RemoveSamuraiFromBattleCommandValidator : AbstractValidator<RemoveSamuraiFromBattleCommand>
    {
        public RemoveSamuraiFromBattleCommandValidator()
        {
            RuleFor(h => h.SamuraiId).NotNull().WithMessage("samurai id is required!!");
            RuleFor(h => h.BattleId).NotNull().WithMessage("battle id is required!!");
        }
    }
}
