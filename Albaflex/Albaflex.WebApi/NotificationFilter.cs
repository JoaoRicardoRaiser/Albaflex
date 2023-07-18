﻿using Albaflex.CrossCutting.Notification;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Net;

namespace Albaflex.WebApi
{
    public class NotificationFilter : IAsyncResultFilter
    {
        private readonly NotificationContext _notificationContext;

        public NotificationFilter(NotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            context.HttpContext.Response.StatusCode = (int)(_notificationContext.HasErrorNotifications ? HttpStatusCode.BadRequest : HttpStatusCode.OK);
            context.HttpContext.Response.ContentType = "application/json";

            var notifications = JsonConvert.SerializeObject(_notificationContext.Notifications);
            await context.HttpContext.Response.WriteAsync(notifications);

            await next();
        }
    }
}
