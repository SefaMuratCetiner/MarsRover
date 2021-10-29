using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Events
{
    public class RoverCreatedEventHandler : INotificationHandler<RoverCreatedEvent>
    {
        private readonly ILogger _logger;

        public RoverCreatedEventHandler(ILogger<RoverCreatedEventHandler> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task Handle(RoverCreatedEvent notification, CancellationToken cancellationToken)
        {
            Plateau.PlaceOnToPlateau(notification.Rover);

            _logger.LogInformation("Rover with Id: {RoverId} has been successfully placed on to Plateau.", notification.Rover.Id);

            return Task.CompletedTask;
        }
    }
}