
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

namespace Application.Battle.AddSamuraiToBattle
{
    public class AddSamuraiToBattleCommandHandler : ICommandHandler<AddSamuraiToBattleCommand>
    {
        private readonly IBattleRepository _battleRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPublisher _publisher;

        public AddSamuraiToBattleCommandHandler(IBattleRepository battleRepository
            , IUnitOfWork unitOfWork
            , IPublisher publisher)
        {
            _battleRepository = battleRepository;
            _unitOfWork = unitOfWork;
            _publisher = publisher;
        }
        public async Task<Result> Handle(AddSamuraiToBattleCommand request, CancellationToken cancellationToken)
        {
            var battle = await _battleRepository.GetByIdAsync(request.BattleId.Value);

            if (battle == null)
            {
                return Result.Fail(new Error("battle not found!!"));
            }

            battle.AddSamuraiWithHorse(request.HorseId.Value, request.SamuraiId.Value);

            var domainEvent =  new AddedSamuraiWithHorseToBattleDomainEvent
            {
             HorseId = request.HorseId.Value,
             SamuraiId = request.SamuraiId.Value,
            };
            await _publisher.Publish(domainEvent);

            await _unitOfWork.SaveChangesAsync();

            return Result.Ok();
        }
    }
}
