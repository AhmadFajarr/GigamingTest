using GigamingTest.Models;
using GigamingTest.Services;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GigamingTest.Controllers
{
    public class Case3Controller : ApiController
    {
        Case3Services case3Services = new Case3Services();
        public IHttpActionResult Get()
        {
            List<TitanicLifeBoat> listPasengger = case3Services.GetListPassenger(35, 27, 3);

            var jsonSerialiser = new JavaScriptSerializer();
            var jsonResult = jsonSerialiser.Serialize(listPasengger);

            if (jsonResult != null)
            {
                return Ok(jsonResult);
            }
            return NotFound();

        }
    }
}
