using System;
using CodingTest.Friends.BusinessLogic.ControllerLogic;
using CodingTest.Friends.Common.Models;
using CodingTest.Friends.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CodingTest.Friends.Tests
{
    [TestClass]
    public class FriendsBusinessLogicTests
    {
        [TestMethod]
        public void GetAllFriendsTest()
        {
            FriendsBusinessLogic friendsBusinessLogic = new FriendsBusinessLogic();

            Friend[] expected = TestDataRecords.Get();
            Friend[] actual = friendsBusinessLogic.GetAllFriends();

            Assert.AreEqual(expected.Length, actual.Length);

            foreach (Friend a in actual)
            {
                Assert.IsTrue(DoesFriendEqual(a, expected.Single(x => x.dateOfBirth == a.dateOfBirth)));
            }
        }

        [TestMethod]
        public void GetFriendsOrderedByGenderThenLastNameTest()
        {
            FriendsBusinessLogic friendsBusinessLogic = new FriendsBusinessLogic();

            Friend[] actual = friendsBusinessLogic.GetFriendsOrderedByGenderThenLastName();
            Friend[] expected = GetFriendsOrderedByGenderThenLastNameExpected();

            Assert.AreEqual(actual.Length, expected.Length);

            for(int index = 0; index < 5; index++)
            {
                DoesFriendEqual(actual[index], expected[index]);
            }
        }

        [TestMethod]
        public void GetFriendsOrderedByGenderTest()
        {
            FriendsBusinessLogic friendsBusinessLogic = new FriendsBusinessLogic();

            Friend[] actual = friendsBusinessLogic.GetFriendsOrderedByGender();
            Friend[] expected = GetFriendsOrderedByGenderExpected();

            Assert.AreEqual(actual.Length, expected.Length);

            for (int index = 0; index < 5; index++)
            {
                DoesFriendEqual(actual[index], expected[index]);
            }
        }

        [TestMethod]
        public void GetFriendsOrderedByDOBTest()
        {
            FriendsBusinessLogic friendsBusinessLogic = new FriendsBusinessLogic();

            Friend[] actual = friendsBusinessLogic.GetFriendsOrderedByGenderThenLastName();
            Friend[] expected = GetFriendsOrderedByDOBExpected();

            Assert.AreEqual(actual.Length, expected.Length);

            for (int index = 0; index < 5; index++)
            {
                DoesFriendEqual(actual[index], expected[index]);
            }
        }

        [TestMethod]
        public void GetFriendsOrderedByLastNameTest()
        {
            FriendsBusinessLogic friendsBusinessLogic = new FriendsBusinessLogic();

            Friend[] actual = friendsBusinessLogic.GetFriendsOrderedByGenderThenLastName();
            Friend[] expected = GetFriendsOrderedByLastNameExpected();

            Assert.AreEqual(actual.Length, expected.Length);

            for (int index = 0; index < 5; index++)
            {
                DoesFriendEqual(actual[index], expected[index]);
            }
        }

        private bool DoesFriendEqual(Friend expected, Friend actual)
        {
            return
                expected.firstName == actual.firstName &&
                expected.lastName == actual.lastName &&
                expected.gender == actual.gender &&
                expected.dateOfBirth == actual.dateOfBirth &&
                expected.favoriteColor == actual.favoriteColor;
        }

        private Friend[] GetFriendsOrderedByGenderThenLastNameExpected()
        {
            return new Friend[5]
            {
                new Friend()
                {
                    firstName = "Sarah",
                    lastName = "Example",
                    gender = "Female",
                    dateOfBirth = new DateTime(1984, 3, 7),
                    favoriteColor = "Blue"
                },

                new Friend()
                {
                    firstName = "Rebecca",
                    lastName = "Test",
                    gender = "Female",
                    dateOfBirth = new DateTime(1965, 5, 16),
                    favoriteColor = "Black"
                },

                new Friend()
                {
                    firstName = "Francisco",
                    lastName = "Correal",
                    gender = "Male",
                    dateOfBirth = new DateTime(1989, 1, 4),
                    favoriteColor = "Green"
                },

                new Friend()
                {
                    firstName = "Bob",
                    lastName = "Example",
                    gender = "Male",
                    dateOfBirth = new DateTime(1971, 11, 23),
                    favoriteColor = "Orange"
                },

                new Friend()
                {
                    firstName = "Johnny",
                    lastName = "Quest",
                    gender = "Male",
                    dateOfBirth = new DateTime(1991, 2, 28),
                    favoriteColor = "Yellow"
                },
            };
        }

        private Friend[] GetFriendsOrderedByDOBExpected()
        {
            return new Friend[5]
            {
                new Friend()
                {
                    firstName = "Rebecca",
                    lastName = "Test",
                    gender = "Female",
                    dateOfBirth = new DateTime(1965, 5, 16),
                    favoriteColor = "Black"
                },

                new Friend()
                {
                    firstName = "Bob",
                    lastName = "Example",
                    gender = "Male",
                    dateOfBirth = new DateTime(1971, 11, 23),
                    favoriteColor = "Orange"
                },

                new Friend()
                {
                    firstName = "Sarah",
                    lastName = "Example",
                    gender = "Female",
                    dateOfBirth = new DateTime(1984, 3, 7),
                    favoriteColor = "Blue"
                },

                new Friend()
                {
                    firstName = "Francisco",
                    lastName = "Correal",
                    gender = "Male",
                    dateOfBirth = new DateTime(1989, 1, 4),
                    favoriteColor = "Green"
                },
                                
                new Friend()
                {
                    firstName = "Johnny",
                    lastName = "Quest",
                    gender = "Male",
                    dateOfBirth = new DateTime(1991, 2, 28),
                    favoriteColor = "Yellow"
                },
            };
        }

        private Friend[] GetFriendsOrderedByLastNameExpected()
        {
            return new Friend[5]
            {
                
                new Friend()
                {
                    firstName = "Rebecca",
                    lastName = "Test",
                    gender = "Female",
                    dateOfBirth = new DateTime(1965, 5, 16),
                    favoriteColor = "Black"
                },

                new Friend()
                {
                    firstName = "Johnny",
                    lastName = "Quest",
                    gender = "Male",
                    dateOfBirth = new DateTime(1991, 2, 28),
                    favoriteColor = "Yellow"
                },

                new Friend()
                {
                    firstName = "Bob",
                    lastName = "Example",
                    gender = "Male",
                    dateOfBirth = new DateTime(1971, 11, 23),
                    favoriteColor = "Orange"
                },

                new Friend()
                {
                    firstName = "Sarah",
                    lastName = "Example",
                    gender = "Female",
                    dateOfBirth = new DateTime(1984, 3, 7),
                    favoriteColor = "Blue"
                },

                new Friend()
                {
                    firstName = "Francisco",
                    lastName = "Correal",
                    gender = "Male",
                    dateOfBirth = new DateTime(1989, 1, 4),
                    favoriteColor = "Green"
                },
            };
        }

        private Friend[] GetFriendsOrderedByGenderExpected()
        {
            return new Friend[5]
            {
                new Friend()
                {
                    firstName = "Sarah",
                    lastName = "Example",
                    gender = "Female",
                    dateOfBirth = new DateTime(1984, 3, 7),
                    favoriteColor = "Blue"
                },

                new Friend()
                {
                    firstName = "Rebecca",
                    lastName = "Test",
                    gender = "Female",
                    dateOfBirth = new DateTime(1965, 5, 16),
                    favoriteColor = "Black"
                },

                new Friend()
                {
                    firstName = "Bob",
                    lastName = "Example",
                    gender = "Male",
                    dateOfBirth = new DateTime(1971, 11, 23),
                    favoriteColor = "Orange"
                },

                new Friend()
                {
                    firstName = "Francisco",
                    lastName = "Correal",
                    gender = "Male",
                    dateOfBirth = new DateTime(1989, 1, 4),
                    favoriteColor = "Green"
                },

                new Friend()
                {
                    firstName = "Johnny",
                    lastName = "Quest",
                    gender = "Male",
                    dateOfBirth = new DateTime(1991, 2, 28),
                    favoriteColor = "Yellow"
                },
            };
        }
    }
}
