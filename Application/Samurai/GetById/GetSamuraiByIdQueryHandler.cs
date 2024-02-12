using Application.Abstractions;
using Domain.Abstractions.Repositories;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Samurai.GetById
{
    public class GetSamuraiByIdQueryHandler : IQueryHandler<GetSamuraiByIdQuery
        , GetSamuraiByIdQueryResponse>
    {
        private readonly ISamuraiRepository _samuraiRepository;
        public GetSamuraiByIdQueryHandler(ISamuraiRepository samuraiRepository)
        {
            _samuraiRepository = samuraiRepository;
        }
        public async Task<Result<GetSamuraiByIdQueryResponse>> Handle(GetSamuraiByIdQuery request, CancellationToken cancellationToken)
        {
            var samurai = await _samuraiRepository.GetByIdAsync(request.Id);
            if(samurai == null) 
            {
                return Result.Fail(new Error("samurai not found!!"));
            }
            var response = new GetSamuraiByIdQueryResponse
            {
                Id = samurai.Id,
                Name = samurai.Name,
                Age = samurai.Age,
                Hight = samurai.Hight,
                Weight = samurai.Weight,
                Role = samurai.Role,
                IsAvailable = samurai.IsAvailable,
                IsDeleted = samurai.IsDeleted,
            };

            return Result.Ok(response);
        }
    }
}
