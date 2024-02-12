using Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Battle.GetById
{
    public class GetBattleByIdQuery : IQuery<GetBattleByIdQueryResponse>
    {
        public int Id { get; set; }
    }
}
