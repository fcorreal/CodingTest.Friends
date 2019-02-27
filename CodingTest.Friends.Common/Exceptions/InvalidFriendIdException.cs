using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest.Friends.Common.Exceptions
{
    public class InvalidFriendIdException : Exception
    {
        public InvalidFriendIdException(string message): base(message)
        { 
}
    }
}
