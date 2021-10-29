using MediatR;

namespace Application.Commands
{
    public class CreateRoverCommand : IRequest
    {
        public int Id { get; set; }

        public string Instruction { get; set; }
    }
}