using GigamingTest.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigamingTest.Models
{
    public class TitanicLifeBoat
    {
        public int CaptainAge { get; set; }
        public int LifeBoatNumber { get; set; }
        public List<PersonViewModel> People { get; set; }
    }
}