using BLL.DTOs;
using BLL.Services;
using Medico.Controllers.ActionFilters;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Medico.Controllers
{

    public class DoctorController : ApiController
    {

        [Route("api/doctors")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = DoctorService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/doctor/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = DoctorService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [IsAdmin]
        [Route("api/doctor/add")]
        [HttpPost]
        public HttpResponseMessage Add(DoctorDTO doc)
        {
            var data = DoctorService.Add(doc);
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

        [Route("api/doctor/update")]
        [HttpPost]
        [IsDoctor]
        public HttpResponseMessage Update(DoctorDTO doc)
        {
            var data = DoctorService.Update(doc);
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

        [Route("api/doctor/delete/{id}")]
        [HttpPost]
        [IsAdmin]
        public HttpResponseMessage Delete(int id)
        {
            var data = DoctorService.Delete(id);
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

        [Route("api/doctor/search")]
        [HttpGet]
        public HttpResponseMessage Search([FromBody] SearchDTO search)
        {
            var data = DoctorService.Search(search.SearchValue);
            if (data != null && data.Count > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, new
                {
                    Message = "No data found"
                });
            }
        }
    }
}
