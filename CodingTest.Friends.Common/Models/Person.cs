using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest.Friends.Common.Models
{
    public abstract class Person
    {
        public string id { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string gender { get; set; }
        public DateTime dateOfBirth { get; set; }
    }
}
