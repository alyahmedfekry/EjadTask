using Application.Abstractions;
using Domain.Abstractions.Repositories;
using Domain.Entities;
using Domain.UnitOfWork;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Battle.Create
{
    internal class CreateBattleCommandHandler : ICommandHandler<CreateBattleCommand>
    {
        private readonly IBattleRepository _battleRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateBattleCommandHandler(IBattleRepository battleRepository
            , IUnitOfWork unitOfWork)
        {
            _battleRepository = battleRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CreateBattleCommand request, CancellationToken cancellationToken)
        {
            var battle = new Domain.Entities.Battle(request.Name);

            await _battleRepository.CreateAsync(battle);

            await _unitOfWork.SaveChangesAsync();

            return Result.Ok();
        }
    }
}
