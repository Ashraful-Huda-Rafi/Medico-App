using BLL.DTOs;
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
    public class IsAuthorizedAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var headers = actionContext.Request.Headers;

            var token = headers.Authorization != null ? headers.Authorization.ToString() : "";
            var _user_id = headers.GetValues("AuthId").Count() > 0 ? headers.GetValues("AuthId").FirstOrDefault() : null;
            var user_id = Convert.ToInt32(_user_id);
            //int user_id = actionContext.ActionArguments.Count > 0 ? ((AuthIdDTO)actionContext.ActionArguments.FirstOrDefault().Value).AuthId : -1;
            if (user_id == 0)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Invalid Auth Id");

                return;
            }

            if (token.Length < 0 || token == null)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Invalid Token");

                return;
            }

            var _token = TokenService.GetByTokenKeyUserIdExpiredNull(user_id, token);

            if (_token == null)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Invalid Token");

                return;
            }
        }
    }
}

