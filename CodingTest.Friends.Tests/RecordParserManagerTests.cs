using System;
using CodingTest.Friends.BusinessLogic.Exceptions;
using CodingTest.Friends.BusinessLogic.Managers;
using CodingTest.Friends.Common.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingTest.Friends.Tests
{
    [TestClass]
    public class RecordParserManagerTests
    {
        [TestMethod]
        public void ParseRecordLineDelimited()
        {
            string rawRecord = "Correal | Francisco | Male | Green | 1/4/89";
            Friend actual = RecordParserManager.ParseRecordFromString(rawRecord);

            Friend expected = GetExpected();
            Assert.AreEqual(expected.dateOfBirth, actual.dateOfBirth);
            Assert.AreEqual(expected.firstName.ToLower(), actual.firstName.ToLower());
            Assert.AreEqual(expected.lastName.ToLower(), actual.lastName.ToLower());
            Assert.AreEqual(expected.favoriteColor.ToLower(), actual.favoriteColor.ToLower());
            Assert.AreEqual(expected.gender.ToLower(), actual.gender.ToLower());
        }

        [TestMethod]
        public void ParseRecordLineDelimitedFailInvalidDOB()
        {
            string rawRecord = "Correal | Francisco | Male | Green | 1/4/TEST89";
            try
            {
                Friend actual = RecordParserManager.ParseRecordFromString(rawRecord);
            }

            catch (InvalidDateOfBirthException)
            {
                Assert.IsTrue(true);
                return;
            }

            Assert.Fail();
        }

        [TestMethod]
        public void ParseRecordCommaDelimited()
        {
            string rawRecord = "Correal, Francisco, male, Green, 1/4/1989";
            Friend actual = RecordParserManager.ParseRecordFromString(rawRecord);

            Friend expected = GetExpected();
            Assert.AreEqual(expected.dateOfBirth, actual.dateOfBirth);
            Assert.AreEqual(expected.firstName.ToLower(), actual.firstName.ToLower());
            Assert.AreEqual(expected.lastName.ToLower(), actual.lastName.ToLower());
            Assert.AreEqual(expected.favoriteColor.ToLower(), actual.favoriteColor.ToLower());
            Assert.AreEqual(expected.gender.ToLower(), actual.gender.ToLower());
        }

        [TestMethod]
        public void ParseRecordCommaDelimitedFailInvalidGender()
        {
            string rawRecord = "correal, francisco, Female, green, 1/4/1989";
            Friend actual = RecordParserManager.ParseRecordFromString(rawRecord);

            Friend expected = GetExpected();
            Assert.AreEqual(expected.dateOfBirth, actual.dateOfBirth);
            Assert.AreEqual(expected.firstName.ToLower(), actual.firstName.ToLower());
            Assert.AreEqual(expected.lastName.ToLower(), actual.lastName.ToLower());
            Assert.AreEqual(expected.favoriteColor.ToLower(), actual.favoriteColor.ToLower());
            Assert.AreNotEqual(expected.gender.ToLower(), actual.gender.ToLower());
        }

        [TestMethod]
        public void ParseRecordSpaceDelimited()
        {
            string rawRecord = "correal francisco male green 1/4/1989";
            Friend actual = RecordParserManager.ParseRecordFromString(rawRecord);

            Friend expected = GetExpected();
            Assert.AreEqual(expected.dateOfBirth, actual.dateOfBirth);
            Assert.AreEqual(expected.firstName.ToLower(), actual.firstName.ToLower());
            Assert.AreEqual(expected.lastName.ToLower(), actual.lastName.ToLower());
            Assert.AreEqual(expected.favoriteColor.ToLower(), actual.favoriteColor.ToLower());
            Assert.AreEqual(expected.gender.ToLower(), actual.gender.ToLower());
        }

        [TestMethod]
        public void ParseRecordSpaceDelimitedFailInvalidFormat()
        {
            string rawRecord = "correal francisco Blue m 1989/1/4";
            Friend actual = RecordParserManager.ParseRecordFromString(rawRecord);

            Friend expected = GetExpected();
            Assert.AreEqual(expected.dateOfBirth, actual.dateOfBirth);
            Assert.AreEqual(expected.firstName.ToLower(), actual.firstName.ToLower());
            Assert.AreEqual(expected.lastName.ToLower(), actual.lastName.ToLower());
            Assert.AreNotEqual(expected.favoriteColor.ToLower(), actual.favoriteColor.ToLower());
            Assert.AreNotEqual(expected.gender.ToLower(), actual.gender.ToLower());
        }

        private Friend GetExpected()
        {
            Friend expected = new Friend()
            {
                lastName = "Correal",
                firstName = "Francisco",
                gender = "Male",
                favoriteColor = "Green",
                dateOfBirth = new DateTime(1989, 1, 4),
            };

            return expected;
        }
    }
}
