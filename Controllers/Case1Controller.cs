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
    public class Case1Controller : ApiController
    {
        Case1Services case1Services = new Case1Services();
        public IHttpActionResult Get()
        {
            List<TitanicLifeBoat> listPasengger = case1Services.GetListPassenger(30, 47, 2);

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
