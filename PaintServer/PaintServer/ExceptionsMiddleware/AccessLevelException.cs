﻿using System;

namespace PaintServer.Exeptions
{
    public class AccessLevelException : Exception
    {
        public AccessLevelException() { }

        public AccessLevelException(string message) : base(message) { }
    }
}
