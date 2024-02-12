using Application.Abstractions;
using Domain.Abstractions.Repositories;
using Domain.UnitOfWork;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Battle.Delete
{
    public class DeleteBattleCommandHandler : ICommandHandler<DeleteBattleCommand>
    {
        private readonly IBattleRepository _battleRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteBattleCommandHandler(IBattleRepository battleRepository
            , IUnitOfWork unitOfWork)
        {
            _battleRepository = battleRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(DeleteBattleCommand request, CancellationToken cancellationToken)
        {
            var battle = await _battleRepository.GetByIdAsync(request.Id);
            if(battle == null) 
            {
                return Result.Fail(new Error("Battle not found!!"));
            }
            
            battle.IsDeleted = true;


            await _unitOfWork.SaveChangesAsync();

            return Result.Ok(); 
        }
    }
}
