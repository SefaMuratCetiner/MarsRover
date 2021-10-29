using System;

namespace Application.Dtos
{
    public class RoverBriefDto
    {
        public RoverBriefDto()
        {
        }

        public RoverBriefDto(string position)
        {
            Position = position ?? throw new ArgumentNullException(nameof(position));
        }

        public string Position { get; set; }
    }
}