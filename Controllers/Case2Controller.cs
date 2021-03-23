using GigamingTest.Models;
using GigamingTest.Services;
using Nancy.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GigamingTest.Controllers
{
    public class Case2Controller : ApiController
    {
        Case2Services case2Services = new Case2Services();
        public IHttpActionResult Get()
        {
            List<TitanicLifeBoat> listPasengger = case2Services.GetListPassenger(54, 52, 4);

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
