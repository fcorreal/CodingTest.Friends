using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest.Friends.BusinessLogic.Exceptions
{
    public class InvalidFriendIdException : Exception
    {
        public InvalidFriendIdException(string message): base(message)
        { 
}
    }
}
