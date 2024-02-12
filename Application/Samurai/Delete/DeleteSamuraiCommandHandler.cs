using Application.Abstractions;
using Domain.Abstractions.Repositories;
using Domain.UnitOfWork;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Samurai.Delete
{
    public class DeleteSamuraiCommandHandler : ICommandHandler<DeleteSamuraiCommand>
    {
        private readonly ISamuraiRepository _samuraiRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteSamuraiCommandHandler(ISamuraiRepository samuraiRepository
            , IUnitOfWork unitOfWork)
        {
            _samuraiRepository = samuraiRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> Handle(DeleteSamuraiCommand request, CancellationToken cancellationToken)
        {
            var samurai = await _samuraiRepository.GetByIdAsync(request.Id);

            if(samurai is null)
            {
                return Result.Fail(new Error("samurai not found!!"));
            }

            samurai.IsDeleted = true;

            await _unitOfWork.SaveChangesAsync();

            return Result.Ok();
        }
    }
}
