using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest.Friends.Common.Exceptions
{
    public class InvalidRecordFormatException : Exception
    {
        public InvalidRecordFormatException(string message) : base(message)
        {
            
        }

        public static string BuildErrorMessage(string record)
        {
            return $"Invalid array array format. Record must be delmited by only a Pipe( | ), Comma(, ) or Space( ):{record}";
        }
    }
}
