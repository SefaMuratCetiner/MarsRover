using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Events
{
    public class MovementInitiatedEventHandler : INotificationHandler<MovementInitiatedEvent>
    {
        private readonly ILogger _logger;

        public MovementInitiatedEventHandler(ILogger<MovementInitiatedEventHandler> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task Handle(MovementInitiatedEvent notification, CancellationToken cancellationToken)
        {
            Plateau.RemoveRover(notification.OldRover);

            Plateau.PlaceOnToPlateau(notification.NewRover);

            _logger.LogInformation("Rover with Id: {RoverId} has been successfully moved on the Plateau.", notification.NewRover.Id);

            return Task.CompletedTask;
        }
    }
}