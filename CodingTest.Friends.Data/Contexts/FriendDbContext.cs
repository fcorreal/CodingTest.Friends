using CodingTest.Friends.Common.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest.Friends.Data.Contexts
{
    public class FriendDbContext : DbContext
    {
        public DbSet<Friend> Friends { get; set; }
    }
}