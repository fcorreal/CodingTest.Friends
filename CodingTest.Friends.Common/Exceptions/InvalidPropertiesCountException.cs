using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest.Friends.Common.Exceptions
{
    public class InvalidPropertiesCountException : Exception
    {
        public InvalidPropertiesCountException(string message) : base(message)
        {
            
        }

        public static string BuildErrorMessage(string[] array, string methodName)
        {
            return $"Invalid array count of {array.Count()} passed into {methodName}: {string.Concat(array)}";
        }
    }
}
