using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Medico.Controllers.ActionFilters
{
    public class IsAdminAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var headers = actionContext.Request.Headers;

            var _user_id = headers.GetValues("AuthId").Count() > 0 ? headers.GetValues("AuthId").FirstOrDefault() : null;
            var user_id = Convert.ToInt32(_user_id);
            if (user_id == 0)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Invalid Auth Id");

                return;
            }

            var isUserAdmin = UserService.GetByUserIdType(user_id, "Admin");

            if (!isUserAdmin)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "User not Admin");
                return;
            }
        }
    }
}
