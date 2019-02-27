using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingTest.Friends.Common.Models;

namespace CodingTest.Friends.BusinessLogic.Interfaces
{
    public interface IFriendsBusinessLogic
    {
        Friend[] GetAllFriends();
        Friend[] GetFriendsOrderedByGenderThenLastName();
        Friend[] GetFriendsOrderedByDOB();
        Friend[] GetFriendsOrderedByLastName();
    }
}
