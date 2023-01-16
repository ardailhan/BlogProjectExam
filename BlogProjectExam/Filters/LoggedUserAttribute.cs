﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BlogProjectExam.Filters
{
    public class LoggedUserAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string userId = context.HttpContext.Session.GetString("userId");
            
            if(string.IsNullOrEmpty(userId))
            {
                string rPath = context.HttpContext.Request.Path;
                context.Result = new RedirectToActionResult("Login", "Auth", new { aktar = rPath });
            }
        }
    }
}
