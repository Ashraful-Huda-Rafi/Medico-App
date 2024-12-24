using BLL.DTOs;
using BLL.Services;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Medico.Controllers
{
    public class LoginController : ApiController
    {
        [Route("api/login")]
        [HttpPost]
        public HttpResponseMessage Login([FromBody] LoginUserDTO obj)
        {
            var user = UserService.Get(obj.UserName, obj.Password, obj.UserType);
            if (user != null)
            {
                var token = new TokenDTO();
                token.UserId = user.Id;
                var _token = TokenService.Add(token);
                return Request.CreateResponse(HttpStatusCode.OK, new
                {
                    Message = "Successfully Logged In",
                    Token = _token
                });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, new
                {
                    Message = "Unsuccessfully Logged In"
                });
            }
        }
    }
}
