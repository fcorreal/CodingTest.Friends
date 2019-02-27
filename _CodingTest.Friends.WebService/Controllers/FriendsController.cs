using CodingTest.Friends.BusinessLogic.ControllerLogic;
using CodingTest.Friends.BusinessLogic.Exceptions;
using CodingTest.Friends.Common.Requests;
using CodingTest.Friends.Common.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CodingTest.Friends.WebService.Managers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet;
using Newtonsoft.Json;
using CodingTest.Friends.Common.Models;

namespace CodingTest.Friends.WebService.Controllers
{
    [Authorize]
    [RoutePrefix("api/friends")]
    public class FriendsController : ApiController
    {
        public static FriendsBusinessLogic friendsBusinessLogic;

        // post
        [HttpPost]
        public IHttpActionResult AddFriend([FromBody] CreateFriendRequest createFriendRequest)
        {
            string logId = "";
            try
            {
                logId = Guid.NewGuid().ToString();
                string id = friendsBusinessLogic.AddFriend(createFriendRequest.friendRawRecord).id;

                CreateFriendResponse response = new CreateFriendResponse();
                response.id = id;

                return Ok(response);
            }

            catch(InvalidDateOfBirthException idob)
            {
                LoggingManager.LogBadRequest(logId, User.Identity.GetUserId(), "InvalidDateOfBirthException", createFriendRequest);
                return BadRequest(idob.Message);
            }

            catch (InvalidPropertiesCountException ipce)
            {
                LoggingManager.LogBadRequest(logId, User.Identity.GetUserId(), "InvalidPropertiesCountException", createFriendRequest);
                return BadRequest(ipce.Message);
            }

            catch (InvalidRecordFormatException irfe)
            {
                LoggingManager.LogBadRequest(logId, User.Identity.GetUserId(), "InvalidRecordFormatException", createFriendRequest);
                return BadRequest(irfe.Message);
            }

            catch(Exception ex)
            {
                LoggingManager.LogInternalError(logId, User.Identity.GetUserId(), "AddFriend", createFriendRequest, ex);

                return InternalServerError(new Exception(
                    $"An internal server error has occurred. Please reach out to customer support with the following ticket ID: {logId}"));
            }
        }

        // get
        [HttpGet]
        [Route("records/gender")]
        public IHttpActionResult GetFriendsOrderedByGender()
        {
            string logId = "";
            try
            {
                logId = Guid.NewGuid().ToString();
                Friend[] friends = friendsBusinessLogic.GetFriendsOrderedByGender();

                return Ok(friends);
            }

            catch (Exception ex)
            {
                string userId = User.Identity.GetUserId();
                LoggingManager.LogInternalError(logId, userId, "GetFriendsOrderedByGenderThenLastName", "", ex);

                return InternalServerError(new Exception(
                    $"An internal server error has occurred. Please reach out to customer support with the following ticket ID: {logId}"));
            }
        }

        [HttpGet]
        [Route("records/birthday")]
        public IHttpActionResult GetFriendsOrderedByDOB()
        {
            string logId = "";
            try
            {
                logId = Guid.NewGuid().ToString();
                Friend[] friends = friendsBusinessLogic.GetFriendsOrderedByDOB();

                return Ok(friends);
            }

            catch (Exception ex)
            {
                string userId = User.Identity.GetUserId();
                LoggingManager.LogInternalError(logId, userId, "GetFriendsOrderedByDOB", "", ex);

                return InternalServerError(new Exception(
                    $"An internal server error has occurred. Please reach out to customer support with the following ticket ID: {logId}"));
            }
        }

        [HttpGet]
        [Route("records/name")]
        public IHttpActionResult GetFriendsOrderedByLastName()
        {
            string logId = "";
            try
            {
                logId = Guid.NewGuid().ToString();
                Friend[] friends = friendsBusinessLogic.GetFriendsOrderedByLastName();

                return Ok(friends);
            }

            catch (Exception ex)
            {
                string userId = User.Identity.GetUserId();
                LoggingManager.LogInternalError(logId, userId, "GetFriendsOrderedByLastName", "", ex);

                return InternalServerError(new Exception(
                    $"An internal server error has occurred. Please reach out to customer support with the following ticket ID: {logId}"));
            }
        }
    }
}
