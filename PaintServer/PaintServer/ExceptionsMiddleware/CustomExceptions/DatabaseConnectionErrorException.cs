using System;

namespace PaintServer.Exeptions
{
    public class DatabaseConnectionErrorException : Exception
    {
        public DatabaseConnectionErrorException() { }

        public DatabaseConnectionErrorException(string message) : base(message) { }
    }
}
