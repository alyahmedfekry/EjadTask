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
    public class AddedSamuraiWithHorseToBattleDomainEventHandler
        : INotificationHandler<AddedSamuraiWithHorseToBattleDomainEvent>
    {
        private readonly ISamuraiRepository _samuraiRepository;
        private readonly IHorseRepository _horseRepository;

        public AddedSamuraiWithHorseToBattleDomainEventHandler(
            ISamuraiRepository samuraiRepository
           ,IHorseRepository horseRepository)
        {
            _samuraiRepository = samuraiRepository;
            _horseRepository = horseRepository;
        }

        public async Task Handle(AddedSamuraiWithHorseToBattleDomainEvent notification, CancellationToken cancellationToken)
        {
            var horse = await _horseRepository.GetByIdAsync(notification.HorseId);
            var samurai = await _samuraiRepository.GetByIdAsync(notification.SamuraiId);
            horse.IsAvailable = false;
            samurai.IsAvailable = false;
        }
    }
}
