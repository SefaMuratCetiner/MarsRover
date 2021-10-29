using MediatR;

namespace Application.Commands
{
    public class CollectUserInputCommand : IRequest
    {
        public string Instruction { get; set; }
    }
}