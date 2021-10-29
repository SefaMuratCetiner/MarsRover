using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Commands;
using MediatR;
using Microsoft.Extensions.Hosting;

namespace ConsoleUI.Services
{
    public class UserInputService : IHostedService
    {
        private readonly ISender _mediator;

        public UserInputService(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task AskForUserInpt(CancellationToken cancellationToken = default)
        {
            PromptChoices();

            var userInput = GetUserInput();

            while (userInput != "0")
            {
                await CollectUserInput(userInput, cancellationToken);

                userInput = GetUserInput();
            }
        }

        private static void PromptChoices()
        {
            Console.WriteLine("You can give any number of instructions below.");
            Console.WriteLine("Please give your instructions line by line.");
            Console.WriteLine("Enter 0 to exit giving instructions and to start executing the given lines.");
        }

        private static string GetUserInput()
        {
            var userInput = Console.ReadLine();

            return userInput;
        }

        private async Task CollectUserInput(string userInput, CancellationToken cancellationToken = default)
        {
            var command = new CollectUserInputCommand
            {
                Instruction = userInput
            };

            await _mediator.Send(command, cancellationToken);
        }

        public async Task StartAsync(CancellationToken cancellationToken = default)
        {
            await AskForUserInpt(cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }
    }
}