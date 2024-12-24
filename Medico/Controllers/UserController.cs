using BLL.DTOs;
using BLL.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Medico.Controllers
{
    public class UserController : ApiController
    {
        [Route("api/users")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = UserService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/user/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = UserService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/user/add")]
        [HttpPost]
        public HttpResponseMessage Add(UserDTO obj)
        {
            var data = UserService.Add(obj);
            if (data)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new
                {
                    Message = "Successfully created"
                });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, new
                {
                    Message = "Unsuccessfully created"
                });
            }
        }

        [Route("api/user/update")]
        [HttpPost]
        public HttpResponseMessage Update(UserDTO obj)
        {
            var data = UserService.Update(obj);
            if (data)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new
                {
                    Message = "Successfully updated"
                });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, new
                {
                    Message = "Unsuccessfully updated"
                });
            }
        }

        [Route("api/user/delete/{id}")]
        [HttpPost]
        public HttpResponseMessage Delete(int id)
        {
            var data = UserService.Delete(id);
            if (data)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new
                {
                    Message = "Successfully deleted"
                });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, new
                {
                    Message = "Unsuccessfully deleted"
                });
            }
        }
    }
}
