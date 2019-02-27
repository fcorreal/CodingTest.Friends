using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest.Friends.Common.Models
{
    public class Friend : Person
    {
        public string favoriteColor { get; set; }

        public Friend()
        {
            id = Guid.NewGuid().ToString();
        }
    }
}
