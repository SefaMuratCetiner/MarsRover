using System.Collections.Generic;
using Application.Dtos;
using MediatR;

namespace Application.Queries
{
    public class GetRoversQuery : IRequest<List<RoverBriefDto>>
    {
    }
}