using System;
using Domain.Entities;
using MediatR;

namespace Application.Events
{
    public class RoverCreatedEvent : INotification
    {
        public RoverCreatedEvent(Rover rover)
        {
            Rover = rover ?? throw new ArgumentNullException(nameof(rover));
        }

        public Rover Rover { get; set; }
    }
}