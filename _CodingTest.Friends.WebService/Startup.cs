using System;
using System.Collections.Generic;
using System.Linq;
using CodingTest.Friends.WebService.Controllers;
using CodingTest.Friends.WebService.Managers;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(CodingTest.Friends.WebService.Startup))]

namespace CodingTest.Friends.WebService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            LoggingManager.Initialize();
            FriendsController.friendsBusinessLogic = new BusinessLogic.ControllerLogic.FriendsBusinessLogic();
        }
    }
}
