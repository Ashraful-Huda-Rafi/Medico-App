using BLL.DTOs;
using BLL.Services;
using Medico.Controllers.ActionFilters;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Medico.Controllers
{
    
    public class BloodDonorController : ApiController
    {
        [Route("api/bloods")]
        [HttpGet]
        
        public HttpResponseMessage Get()
        {
            var data = BloodDonorService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/blood/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = BloodDonorService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [IsAdmin]
        [Route("api/blood/add")]
        [HttpPost]
        public HttpResponseMessage Add(BloodDonorDTO bld)
        {
            var data = BloodDonorService.Add(bld);
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
        [IsAdmin]
        [Route("api/blood/update")]
        [HttpPost]
        public HttpResponseMessage Update(BloodDonorDTO obj)
        {
            var data = BloodDonorService.Update(obj);
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
        [IsAdmin]
        [Route("api/blood/delete/{id}")]
        [HttpPost]
        public HttpResponseMessage Delete(int id)
        {
            var data = BloodDonorService.Delete(id);
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
