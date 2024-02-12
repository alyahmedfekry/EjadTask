using Application.Abstractions;
using Domain.Abstractions.Repositories;
using Domain.UnitOfWork;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Samurai.Update
{
    public class UpdateSamuraiCommandHandler : ICommandHandler<UpdateSamuraiCommand>
    {
        private readonly ISamuraiRepository _samuraiRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateSamuraiCommandHandler(ISamuraiRepository samuraiRepository
            , IUnitOfWork unitOfWork)
        {
            _samuraiRepository = samuraiRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> Handle(UpdateSamuraiCommand request, CancellationToken cancellationToken)
        {
            var samurai = new Domain.Entities.Samurai(request.Name, request.Age
                , request.Role, request.Hight, request.Weight);

            samurai.Id = request.Id;

            _samuraiRepository.Update(samurai);

            await _unitOfWork.SaveChangesAsync();

            return Result.Ok();
        }
    }
}
