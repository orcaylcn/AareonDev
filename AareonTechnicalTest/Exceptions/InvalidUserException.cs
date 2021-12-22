﻿using System;

namespace AareonTechnicalTest.Exceptions
{
    public class InvalidUserException : Exception
    {
        public InvalidUserException()
        {
        }

        public InvalidUserException(string message)
            : base(message)
        {
        }

        public InvalidUserException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
