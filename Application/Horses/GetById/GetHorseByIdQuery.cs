using Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Horses.GetById
{
    public sealed class GetHorseByIdQuery : IQuery<GetHorseByIdQueryResponse>
    {
        public int Id { get; set; } 
    }
}
