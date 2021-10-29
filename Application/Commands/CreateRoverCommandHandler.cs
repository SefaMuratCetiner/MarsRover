using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Events;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Commands
{
    public class CreateRoverCommandHandler : IRequestHandler<CreateRoverCommand>
    {
        private readonly IPublisher _mediator;

        public CreateRoverCommandHandler(IPublisher mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<Unit> Handle(CreateRoverCommand request, CancellationToken cancellationToken)
        {
            var instruction = request.Instruction.Split();

            _ = Enum.TryParse(instruction[2], true, out Orientation orientation);

            var rover = new Rover
            {
                Id = request.Id,
                X = int.Parse(instruction[0]),
                Y = int.Parse(instruction[1]),
                Orientation = orientation
            };

            Rover.Rovers.Add(rover);

            await _mediator.Publish(new RoverCreatedEvent(rover), cancellationToken);

            return Unit.Value;
        }
    }
}