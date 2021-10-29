using System;
using Domain.Entities;
using MediatR;

namespace Application.Events
{
    public class MovementInitiatedEvent : INotification
    {
        public MovementInitiatedEvent(Rover oldRover, Rover newRover)
        {
            OldRover = oldRover ?? throw new ArgumentNullException(nameof(oldRover));
            NewRover = newRover ?? throw new ArgumentNullException(nameof(newRover));
        }

        public Rover OldRover { get; set; }

        public Rover NewRover { get; set; }
    }
}