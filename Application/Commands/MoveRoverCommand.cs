using MediatR;

namespace Application.Commands
{
    public class MoveRoverCommand : IRequest
    {
        public int Id { get; set; }

        public string Instruction { get; set; }
    }
}