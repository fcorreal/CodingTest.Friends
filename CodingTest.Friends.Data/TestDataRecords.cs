using CodingTest.Friends.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest.Friends.Data
{
    public class TestDataRecords
    {
        public static Friend[] Get()
        {
            return new Friend[5]
            {
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
            };
        }
    }
}
