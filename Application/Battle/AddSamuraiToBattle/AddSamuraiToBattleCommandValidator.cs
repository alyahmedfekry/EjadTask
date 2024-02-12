using Application.Battle.Create;
using Domain.Abstractions.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Battle.AddSamuraiToBattle
{
    public class AddSamuraiToBattleCommandValidator : AbstractValidator<AddSamuraiToBattleCommand>
    {
        public AddSamuraiToBattleCommandValidator(IHorseRepository horseRepository
            ,ISamuraiRepository samuraiRepository)
        {
            RuleFor(h => h.HorseId).NotNull().WithMessage("HorseId is required!!")
                .MustAsync(async (horseid, _) =>
                {
                    return await horseRepository.IsAvailable(horseid.Value);
                }).WithMessage("this horse is assigned to another samurai!!");


            RuleFor(h => h.SamuraiId).NotNull().WithMessage("samuraiid is required!!")
                .MustAsync(async (samuraiId, _) =>
                {
                    return await horseRepository.IsAvailable(samuraiId.Value);
                }).WithMessage("this samurai already participated in this battle or anotherone!!");

            RuleFor(h => h.BattleId).NotNull().WithMessage("battle id is required!!");
        }
    }
}
