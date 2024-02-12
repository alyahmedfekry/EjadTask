using Application.Abstractions;
using Domain.Abstractions.Repositories;
using Domain.UnitOfWork;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Battle.Update
{
    public class UpdateBattleCommandHnadler : ICommandHandler<UpdateBattleCommand>
    {
        private readonly IBattleRepository _battleRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateBattleCommandHnadler(IBattleRepository battleRepository
            , IUnitOfWork unitOfWork)
        {
            _battleRepository = battleRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(UpdateBattleCommand request, CancellationToken cancellationToken)
        {
            var battle = new Domain.Entities.Battle(request.Name);

            battle.Id = request.Id;

            _battleRepository.Update(battle);
         
            await  _unitOfWork.SaveChangesAsync();

            return Result.Ok();
        }
    }
}
