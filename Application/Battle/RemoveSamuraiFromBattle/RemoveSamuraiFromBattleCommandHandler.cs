using Application.Abstractions;
using Domain.Abstractions.Repositories;
using Domain.DomainEvents;
using Domain.UnitOfWork;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Battle.RemoveSamuraiFromBattle
{
    public class RemoveSamuraiFromBattleCommandHandler : ICommandHandler<RemoveSamuraiFromBattleCommand>
    {
        private readonly IBattleRepository _battleRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPublisher _publisher;
        public RemoveSamuraiFromBattleCommandHandler(IBattleRepository battleRepository
            ,IUnitOfWork unitOfWork
            ,IPublisher publisher)
        {
            _battleRepository = battleRepository;
            _unitOfWork = unitOfWork;
            _publisher = publisher;
        }
        public async Task<Result> Handle(RemoveSamuraiFromBattleCommand request, CancellationToken cancellationToken)
        {
            var battle = await  _battleRepository.GetByIdAsync(request.BattleId.Value);
            if (battle == null)
            {
                return Result.Fail(new Error("battle doesnot exist!!"));
            }
            var samuraiBattle = battle.samurais.Where(s =>
               (s.SamuraiId == request.SamuraiId.Value)
            && (!s.EndRodeDate.HasValue)).SingleOrDefault();

            if(samuraiBattle == null)
            {
                return Result.Fail(new Error("samurai already unparticipated in this battle!!"));
            }
            samuraiBattle.EndRodeDate = DateTime.Now;

            var domainEvent = new RemovedSamuraiWithHorseFromBattleDomainEvent
            {
                SamuraiId = samuraiBattle.SamuraiId,
                HorseId = samuraiBattle.HorseId
            };
            
            await _publisher.Publish(domainEvent);

            await _unitOfWork.SaveChangesAsync();

            return Result.Ok();
        }
    }
}
