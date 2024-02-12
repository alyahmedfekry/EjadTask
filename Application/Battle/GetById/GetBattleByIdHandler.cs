using Application.Abstractions;
using Domain.Abstractions.Repositories;
using Domain.UnitOfWork;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Battle.GetById
{
    public class GetBattleByIdHandler : IQueryHandler<GetBattleByIdQuery
        , GetBattleByIdQueryResponse>
    {
        private readonly IBattleRepository _battleRepository;
        private readonly IUnitOfWork _unitOfWork;
        public GetBattleByIdHandler(IBattleRepository battleRepository
            , IUnitOfWork unitOfWork)
        {
            _battleRepository = battleRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<GetBattleByIdQueryResponse>> Handle(GetBattleByIdQuery request, CancellationToken cancellationToken)
        {
            var battle = await _battleRepository.GetByIdAsync(request.Id);

            if (battle == null)
            {
                return Result.Fail(new Error("battle not found!!"));
            }

            var response = new GetBattleByIdQueryResponse
            {
                Id = battle.Id,
                Name = battle.Name,
                FinishedDate = battle.FinishedDate,
                IsDeleted = battle.IsDeleted,
            };

            return Result.Ok(response);
        }
    }
}
