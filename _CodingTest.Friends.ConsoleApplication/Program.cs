using CodingTest.Friends.BusinessLogic.ControllerLogic;
using CodingTest.Friends.Common.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest.Friends.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            FriendsBusinessLogic friendsBusinessLogic = new FriendsBusinessLogic();

            Console.WriteLine("--- Friends By Gender Then Last Name---");
            PrintReport(friendsBusinessLogic.GetFriendsOrderedByGenderThenLastName());

            Console.WriteLine("--- Friends By Gender---");
            PrintReport(friendsBusinessLogic.GetFriendsOrderedByGender());

            Console.WriteLine("--- Friends By DOB ---");
            PrintReport(friendsBusinessLogic.GetFriendsOrderedByDOB());

            Console.WriteLine("--- Friends By Last Name ---");
            PrintReport(friendsBusinessLogic.GetFriendsOrderedByLastName());

            Console.WriteLine("Adding additional friends.");

            List<Friend> additionalFriends = new List<Friend>();
            additionalFriends.Add(friendsBusinessLogic.AddFriend("PipeDelimiter | Example | Male | Blue | 1/19/2000"));
            additionalFriends.Add(friendsBusinessLogic.AddFriend("CommaDelimiter, Example, Female, Green, 5/12/1980"));
            additionalFriends.Add(friendsBusinessLogic.AddFriend("SpaceDelimiter Example Female Red 12/4/1975"));

            Console.WriteLine("");
            Console.WriteLine("Pulling friends list with additional friends.");
            Console.WriteLine("");

            Console.WriteLine("--- Friends By Gender Then Last Name---");
            PrintReport(friendsBusinessLogic.GetFriendsOrderedByGenderThenLastName());

            Console.WriteLine("--- Friends By DOB ---");
            PrintReport(friendsBusinessLogic.GetFriendsOrderedByDOB());

            Console.WriteLine("--- Friends By Last Name ---");
            PrintReport(friendsBusinessLogic.GetFriendsOrderedByLastName());

            Console.ReadLine();
        }

        public static void PrintReport(Friend[] friends)
        {
            Console.WriteLine("Last Name,First Name,Gender,Date Of Birth,Favorite Color");

            foreach (Friend friend in friends)
            {
                Console.WriteLine($"{friend.lastName},{friend.firstName},{friend.gender},{friend.dateOfBirth.ToShortDateString()},{friend.favoriteColor}");
            }

            Console.WriteLine("");
        }
    }
}