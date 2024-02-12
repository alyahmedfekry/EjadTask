using Application.Abstractions;
using Domain.Abstractions.Repositories;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Samurai.GetAll
{
    public class GetAllSamuraiQueryHandler : IQueryHandler<GetAllSamuraiQuery
        , List<Domain.Entities.Samurai>>
    {
        private readonly ISamuraiRepository _samuraiRepository;
        public GetAllSamuraiQueryHandler(ISamuraiRepository samuraiRepository)
        {
            _samuraiRepository = samuraiRepository;
        }
        public async Task<Result<List<Domain.Entities.Samurai>>> Handle(GetAllSamuraiQuery request, CancellationToken cancellationToken)
        {
            var response = await _samuraiRepository.GetAllAsync();

            return Result.Ok(response);
        }
    }
}
