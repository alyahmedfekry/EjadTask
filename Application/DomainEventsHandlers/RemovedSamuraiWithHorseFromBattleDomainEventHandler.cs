using Domain.Abstractions.Repositories;
using Domain.DomainEvents;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DomainEventsHandlers
{
    public class RemovedSamuraiWithHorseFromBattleDomainEventHandler
        : INotificationHandler<RemovedSamuraiWithHorseFromBattleDomainEvent>
    {
        private readonly IHorseRepository _horseRepository;
        private readonly ISamuraiRepository _samuraiRepository;
        public RemovedSamuraiWithHorseFromBattleDomainEventHandler(
            IHorseRepository horseRepository
           ,ISamuraiRepository samuraiRepository)
        {
            _horseRepository = horseRepository;
            _samuraiRepository = samuraiRepository;
        }

        public async Task Handle(RemovedSamuraiWithHorseFromBattleDomainEvent notification, CancellationToken cancellationToken)
        {
          await  _horseRepository.SetIsAvailableStatus(notification.HorseId, true);
          await  _samuraiRepository.SetIsAvailableStatus(notification.SamuraiId, true);
        }
    }
}
