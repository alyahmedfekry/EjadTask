using Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Samurai.GetById
{
    public sealed class GetSamuraiByIdQuery : IQuery<GetSamuraiByIdQueryResponse>
    {
        public int Id { get; set; }
    }
}
