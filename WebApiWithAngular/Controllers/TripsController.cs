using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Web.Http;
using WebApiWithAngular.Models;

namespace WebApiWithAngular.Controllers
{
    [Authorize]
    public class TripsController : ApiController
    {
        public IHttpActionResult Get()
        {
            var trips = new List<Trip>()
            {
                new Trip() {Id= Guid.NewGuid(),Name = "Trip 1", Description = "Trip 1",IsPublic = true},
                new Trip() {Id= Guid.NewGuid(),Name = "Trip 2", Description = "Trip 2",IsPublic = true}

            };

            var claims = (User as ClaimsPrincipal).Claims;

            return Ok<IEnumerable<Trip>>(trips);
        }
    }
}
