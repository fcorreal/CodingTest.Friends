using CodingTest.Friends.BusinessLogic.Interfaces;
using CodingTest.Friends.BusinessLogic.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using CodingTest.Friends.BusinessLogic.Exceptions;
using System.Text;
using System.Threading.Tasks;
using CodingTest.Friends.Common.Models;
using CodingTest.Friends.Data.Contexts;
using CodingTest.Friends.Data;

namespace CodingTest.Friends.BusinessLogic.ControllerLogic
{
    public class FriendsBusinessLogic : IFriendsBusinessLogic
    {
        private FriendDbContext _friendsDbContext;

        // constructors
        public FriendsBusinessLogic()
        {
            _friendsDbContext = new FriendDbContext();

            // clear friend db context
            foreach (Friend friend in _friendsDbContext.Friends)
            {
                _friendsDbContext.Friends.Remove(friend);
            }

            _friendsDbContext.SaveChanges();

            // add test data
            _friendsDbContext.Friends.AddRange(TestDataRecords.Get());

            _friendsDbContext.SaveChanges();
        }

        // create
        public Friend AddFriend(string rawRecord)
        {
            Friend friend = RecordParserManager.ParseRecordFromString(rawRecord);

            if (_friendsDbContext == null)
                _friendsDbContext = new FriendDbContext();

            _friendsDbContext.Friends.Add(friend);
            _friendsDbContext.SaveChanges();

            return friend;
        }

        // get
        public Friend[] GetAllFriends()
        {
            IList<Friend> friends = new List<Friend>();

            foreach (Friend friend in _friendsDbContext.Friends.ToArray())
            {
                friends.Add(friend);
            }

            return friends.ToArray();
        }

        public Friend[] GetFriendsOrderedByGender()
        {
            return GetAllFriends().OrderBy(x => x.gender).ToArray();
        }

        public Friend[] GetFriendsOrderedByGenderThenLastName()
        {
            return GetAllFriends().OrderBy(x => x.gender).ThenBy(y => y.lastName).ToArray();
        }

        public Friend[] GetFriendsOrderedByDOB()
        {
            return GetAllFriends().OrderBy(x => x.dateOfBirth).ToArray();
        }

        public Friend[] GetFriendsOrderedByLastName()
        {
            return GetAllFriends().OrderByDescending(x => x.lastName).ToArray();
        }

        private T[] OrderBy<T>(bool ascending, IEnumerable<T> toSort, Func<T, IComparable> sortProp)
        {
            List<Func<T, IComparable>> sortProps = new List<Func<T, IComparable>>()
            {
                sortProp,
            };

            return OrderBy<T>(ascending, toSort, sortProps);
        }

        private T[] OrderBy<T>(bool ascending, IEnumerable<T> toSort, List<Func<T, IComparable>> sortProps)
        {
            IOrderedEnumerable<T> result = null;

            foreach (Func<T, IComparable> sortProp in sortProps)
            {
                if (result == null)
                {
                    if (ascending)
                        result = toSort.OrderBy(x => sortProp(x));
                    else
                        result = toSort.OrderByDescending(x => sortProp(x));
                }

                else
                {
                    if (ascending)
                        result.ThenBy(x => sortProp(x));
                    else
                        result.ThenByDescending(x => sortProp(x));
                }
            }

            return result.ToArray();
        }
    }
}
