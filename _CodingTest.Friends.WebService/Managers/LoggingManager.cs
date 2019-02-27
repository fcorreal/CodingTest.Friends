using Newtonsoft.Json;
using NLog;
using NLog.Config;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodingTest.Friends.WebService.Managers
{
    public class LoggingManager
    {
        private static Logger Instance { get; set; }
        public static void Initialize()
        {
            Instance = LogManager.GetCurrentClassLogger();
        }

        public static void LogInfo(string message)
        {
            Instance.Log(LogLevel.Info, message);
        }

        public static void LogWarning(string message, Exception exception = null)
        {
            if(exception == null)
                Instance.Log(LogLevel.Warn, message);
            else
                Instance.Log(LogLevel.Warn, message, exception);
        }

        public static void LogError(string message, Exception exception)
        {
            Instance.Log(LogLevel.Error, message, exception);
        }

        public static void LogBadRequest(string logId, string userId, string exceptionTypeName, object request)
        {
            LogInfo($"LogID:{logId}, Bad request from user {userId}, ExceptionType: {exceptionTypeName}, Request:{JsonConvert.SerializeObject(request)}");
        }

        public static void LogInternalError(string logId, string userId, string endpointName, object request, Exception exception)
        {
            LogError($"LogID:{logId}, Error occured for user {userId}, Endpoint Name:{endpointName}, Request:{JsonConvert.SerializeObject(request)}", exception);
        }
    }
}