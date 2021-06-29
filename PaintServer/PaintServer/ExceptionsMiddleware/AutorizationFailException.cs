using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaintServer.ExceptionsMiddleware
{
    public class AutorizationFailException: Exception
    {
        public AutorizationFailException()
        {

        }

        public AutorizationFailException(string message) : base(message)
        {

        }
    }
}
