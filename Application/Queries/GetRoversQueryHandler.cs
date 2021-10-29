using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Dtos;
using Domain.Entities;
using MediatR;

namespace Application.Queries
{
    public class GetRoversQueryHandler : IRequestHandler<GetRoversQuery, List<RoverBriefDto>>
    {
        public Task<List<RoverBriefDto>> Handle(GetRoversQuery request, CancellationToken cancellationToken)
        {
            var rovers = GetRovers();

            var dto = new List<RoverBriefDto>();

            foreach (var item in rovers)
            {
                dto.Add(new RoverBriefDto(item.Position));
            }

            return Task.FromResult(dto);
        }

        private static List<Rover> GetRovers()
        {
            var rovers = Rover.Rovers;

            return rovers;
        }
    }
}