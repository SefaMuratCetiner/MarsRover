using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using MediatR;

namespace Application.Commands
{
    public class CollectUserInputCommandHandler : IRequestHandler<CollectUserInputCommand>
    {
        public Task<Unit> Handle(CollectUserInputCommand request, CancellationToken cancellationToken)
        {
            Instruction.Instructions.Add(request.Instruction);

            return Unit.Task;
        }
    }
}