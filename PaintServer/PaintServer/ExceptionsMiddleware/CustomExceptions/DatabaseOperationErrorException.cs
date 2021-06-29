using System;

namespace PaintServer.Exeptions
{
    public class DatabaseOperationErrorException : Exception
    {
        public DatabaseOperationErrorException() { }

        public DatabaseOperationErrorException(string message) : base(message) { }
    }
}