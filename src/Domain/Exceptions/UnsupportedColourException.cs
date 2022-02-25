using System;

namespace DrumSpace.Domain.Exceptions
{
    public class UnsupportedColourException : Exception
    {
        public UnsupportedColourException(string code) : base($"Colour \"{code}\" is unsupported.")
        {
        }
    }
}