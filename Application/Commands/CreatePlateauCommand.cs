using MediatR;

namespace Application.Commands
{
    public class CreatePlateauCommand : IRequest
    {
        public string Instruction { get; set; }
    }
}