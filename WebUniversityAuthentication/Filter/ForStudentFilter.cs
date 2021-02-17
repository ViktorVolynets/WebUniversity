using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUniversityAuthentication.Filter
{
    public class ForStudentFilter : IAuthorizationFilter
    {
     
            public void OnAuthorization(AuthorizationFilterContext context)
            {
                if (!context.HttpContext.User.Claims.Where(c=>c.Type == "Who").Any(a=>a.Value=="Student"))
                {
            
                context.Result = new ForbidResult();
                }
            }
      


    }
}
