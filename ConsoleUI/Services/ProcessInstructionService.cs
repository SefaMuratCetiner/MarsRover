using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Commands;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Hosting;

namespace ConsoleUI.Services
{
    public class ProcessInstructionService : IHostedService
    {
        private readonly ISender _mediator;

        public ProcessInstructionService(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        private async Task ProcessInstruction(CancellationToken cancellationToken = default)
        {
            var instructions = Instruction.Instructions;

            for (int i = 0; i < instructions.Count; i++)
            {
                if (i == 0)
                {
                    await CreatePlateau(instructions[i], cancellationToken);
                }
                else if (i % 2 == 1)
                {
                    await CreateRover(i, instructions[i], cancellationToken);
                }
                else
                {
                    await MoveRover(i - 1, instructions[i], cancellationToken);
                }
            }
        }

        private async Task CreatePlateau(string instruction, CancellationToken cancellationToken = default)
        {
            var command = new CreatePlateauCommand
            {
                Instruction = instruction
            };

            await _mediator.Send(command, cancellationToken);
        }

        private async Task CreateRover(int id, string instruction, CancellationToken cancellationToken = default)
        {
            var command = new CreateRoverCommand
            {
                Id = id,
                Instruction = instruction
            };

            await _mediator.Send(command, cancellationToken);
        }

        private async Task MoveRover(int id, string instruction, CancellationToken cancellationToken = default)
        {
            var command = new MoveRoverCommand
            {
                Id = id,
                Instruction = instruction
            };

            await _mediator.Send(command, cancellationToken);
        }

        public async Task StartAsync(CancellationToken cancellationToken = default)
        {
            await ProcessInstruction(cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }
    }
}