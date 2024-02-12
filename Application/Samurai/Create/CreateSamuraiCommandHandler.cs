using Application.Abstractions;
using Domain.Abstractions.Repositories;
using Domain.UnitOfWork;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
namespace Application.Samurai.Create
{
    public class CreateSamuraiCommandHandler : ICommandHandler<CreateSamuraiCommand>
    {
        private readonly ISamuraiRepository _samuraiRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateSamuraiCommandHandler(ISamuraiRepository samuraiRepository
            , IUnitOfWork unitOfWork)
        {
            _samuraiRepository = samuraiRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CreateSamuraiCommand request, CancellationToken cancellationToken)
        {
            var samurai = new Domain.Entities.Samurai(request.Name ,request.Age
                , request.Role ,request.Hight ,request.Weight);
            await _samuraiRepository.CreateAsync(samurai);
            await _unitOfWork.SaveChangesAsync();

            return Result.Ok();
        }
    }
}
