using Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainEvents
{
    public class RemovedSamuraiWithHorseFromBattleDomainEvent : INotification
    {
        public int SamuraiId { get; set; }
        public int HorseId { get; set; }
    }
}
