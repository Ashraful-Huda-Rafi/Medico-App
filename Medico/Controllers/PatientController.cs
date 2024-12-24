using BLL.DTOs;
using BLL.Services;
using Medico.Controllers.ActionFilters;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Medico.Controllers
{
   
    public class PatientController : ApiController
    {

        [Route("api/patients")]
        [HttpGet]
        [IsAdmin]
        [IsDoctor]
        public HttpResponseMessage Get()
        {
            var data = PatientService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/patient/{id}")]
        [HttpGet]
        [IsAdmin]
        [IsDoctor]
        public HttpResponseMessage Get(int id)
        {
            var data = PatientService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/patients/add")]
        [HttpPost]
        [IsAdmin]
        
        public HttpResponseMessage Add(PatientDTO pat)
        {
            var data = PatientService.Add(pat);
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
        [IsPatient]
        [Route("api/patient/update")]
        [HttpPost]
        public HttpResponseMessage Update(PatientDTO pat)
        {
            var data = PatientService.Update(pat);
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

        [Route("api/patient/delete/{id}")]
        [HttpPost]
        [IsAdmin]
        public HttpResponseMessage Delete(int id)
        {
            var data = PatientService.Delete(id);
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
