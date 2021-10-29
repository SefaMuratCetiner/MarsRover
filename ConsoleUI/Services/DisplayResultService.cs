using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Queries;
using MediatR;
using Microsoft.Extensions.Hosting;

namespace ConsoleUI.Services
{
    public class DisplayResultService : IHostedService
    {
        private readonly ISender _mediator;

        public DisplayResultService(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        private async Task DisplayResult(CancellationToken cancellationToken = default)
        {
            Console.WriteLine("Result:");

            var rovers = await GetRovers(cancellationToken);

            foreach (var item in rovers)
            {
                Console.WriteLine($"{item.Position}");
            }
        }

        private async Task<List<RoverBriefDto>> GetRovers(CancellationToken cancellationToken = default)
        {
            var query = new GetRoversQuery();

            var rovers = await _mediator.Send(query, cancellationToken);

            return rovers;
        }

        public async Task StartAsync(CancellationToken cancellationToken = default)
        {
            await DisplayResult(cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }
    }
}