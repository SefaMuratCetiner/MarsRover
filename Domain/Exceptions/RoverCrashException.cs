using System;

namespace Domain.Exceptions
{
    public class RoverCrashException : Exception
    {
        public RoverCrashException(string message)
            : base(message)
        {
        }
    }
}
