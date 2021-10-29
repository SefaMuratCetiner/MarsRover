using System;
using System.Collections.Generic;
using Domain.Enums;

namespace Domain.Entities
{
    public class Rover : ICloneable
    {
        public int Id { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public Orientation Orientation { get; set; }

        public string Position => $"{X} {Y} {Orientation}";

        public static List<Rover> Rovers { get; set; } = new();

        public Rover()
        {
        }

        public Rover(Rover rover)
        {
            Id = rover.Id;
            X = rover.X;
            Y = rover.Y;
            Orientation = rover.Orientation;
        }

        public object Clone()
        {
            return new Rover(this);
        }
    }
}