using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Events;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Commands
{
    public class MoveRoverCommandHandler : IRequestHandler<MoveRoverCommand>
    {
        private readonly IPublisher _mediator;

        public MoveRoverCommandHandler(IPublisher mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<Unit> Handle(MoveRoverCommand request, CancellationToken cancellationToken)
        {
            var instruction = request.Instruction.ToCharArray();

            var rover = GetRoverById(request.Id);

            _ = rover ?? throw new InvalidOperationException($"Could not find rover with Id: {request.Id}");

            foreach (var item in instruction)
            {
                _ = Enum.TryParse(item.ToString(), true, out Movement movement);

                var oldRover = (Rover)rover.Clone();

                MoveRover(rover, movement);

                await _mediator.Publish(new MovementInitiatedEvent(oldRover, rover), cancellationToken);
            }

            return Unit.Value;
        }

        private static Rover GetRoverById(int id)
        {
            var rover = Rover.Rovers.FirstOrDefault(rover => rover.Id == id);

            return rover;
        }

        private static void MoveRover(Rover rover, Movement movement)
        {
            switch (movement)
            {
                case Movement.L:
                    TurnLeft(rover);
                    break;

                case Movement.R:
                    TurnRight(rover);
                    break;

                case Movement.M:
                    MoveForward(rover);
                    break;
            }
        }

        private static void TurnLeft(Rover rover) => rover.Orientation = rover.Orientation switch
        {
            Orientation.N => Orientation.W,
            Orientation.E => Orientation.N,
            Orientation.W => Orientation.S,
            Orientation.S => Orientation.E,
            _ => throw new NotImplementedException()
        };

        private static void TurnRight(Rover rover) => rover.Orientation = rover.Orientation switch
        {
            Orientation.N => Orientation.E,
            Orientation.E => Orientation.S,
            Orientation.W => Orientation.N,
            Orientation.S => Orientation.W,
            _ => throw new NotImplementedException()
        };

        private static void MoveForward(Rover rover) => _ = rover.Orientation switch
        {
            Orientation.N => rover.Y++,
            Orientation.E => rover.X++,
            Orientation.W => rover.X--,
            Orientation.S => rover.Y--,
            _ => throw new NotImplementedException()
        };
    }
}