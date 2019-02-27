﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest.Friends.Common.Exceptions
{
    public class InvalidDateOfBirthException : Exception
    {
        public InvalidDateOfBirthException(string message) : base(message)
        {

        }
    }
}
