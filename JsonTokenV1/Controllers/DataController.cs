using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace JsonTokenV1.Controllers
{
    public class DataController : ApiController
    {
        [Authorize]
        [HttpGet]
        [Route("api/data/forall")]
        public IHttpActionResult Get()
        {
            return Ok("La hora del servidor es: " + DateTime.Now.ToString());
        }
        [Authorize]
        [HttpGet]
        [Route("api/data/autentificacion")]
        public IHttpActionResult GetForAuthenticate()
        {
            var identity = (ClaimsIdentity)User.Identity;
            return Ok("Ola " + identity.Name);
        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        [Route("api/data/autorizacion")]
        public IHttpActionResult GetForAdmin()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var roles = identity.Claims
                .Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value);
            return Ok("Hola  " + identity.Name + " Rol " + string.Join(",", roles.ToList()));
        }
    }
}
