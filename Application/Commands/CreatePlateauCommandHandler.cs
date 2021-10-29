using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using MediatR;

namespace Application.Commands
{
    public class CreatePlateauCommandHandler : IRequestHandler<CreatePlateauCommand>
    {
        public Task<Unit> Handle(CreatePlateauCommand request, CancellationToken cancellationToken)
        {
            var instruction = request.Instruction.Split();

            Plateau.Row = int.Parse(instruction[0]);
            Plateau.Column = int.Parse(instruction[1]);

            return Unit.Task;
        }
    }
}