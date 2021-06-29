using System;

namespace PaintServer.Exeptions
{
    public class ParameterValidationException : Exception
    {
        public ParameterValidationException() { }

        public ParameterValidationException(string message) : base(message) { }
    }
}
