using Domain.Exceptions;

namespace Domain.Entities
{
    public static class Plateau
    {
        public static int Row { get; set; }

        public static int Column { get; set; }

        private static Rover[,] _plateauRepr;

        public static Rover[,] PlateauRepr
        {
            get
            {
                if (_plateauRepr is null)
                {
                    _plateauRepr = new Rover[Row + 1, Column + 1];
                }

                return _plateauRepr;
            }
        }

        public static void RemoveRover(Rover rover)
        {
            PlateauRepr[rover.Y, rover.X] = null;
        }

        public static void PlaceOnToPlateau(Rover rover)
        {
            var roverOnPlateau = PlateauRepr[rover.Y, rover.X];

            if (roverOnPlateau is not null)
            {
                throw new RoverCrashException(
                    $"Rover with id: {rover.Id} tried to crash into Rover with id: {roverOnPlateau.Id}. " +
                    $"Rover with id: {roverOnPlateau.Id} was on coordinates ({rover.X}, {rover.Y})");
            }

            PlateauRepr[rover.Y, rover.X] = rover;
        }
    }
}