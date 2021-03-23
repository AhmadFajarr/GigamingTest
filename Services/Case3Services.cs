using GigamingTest.Models;
using GigamingTest.Models.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace GigamingTest.Services
{
    public class Case3Services
    {
        public List<TitanicLifeBoat> GetListPassenger(int amountPass, int captainOld, int amountLifeBoat)
        {
            var filePath = @"C:\Fajar\Document\Test Gigaming\Case3.json";

            List<Person> model = JsonConvert.DeserializeObject<List<Person>>(File.ReadAllText(filePath));

            var oddModel = model.Where(x => x.age % 2 != 0)
                             .OrderBy(x => x.age)
                             .ThenBy(x => x.name)
                             .Take(8)
                             .ToList();

            var evenModel = model.Where(x => x.age % 2 == 0)
                               .OrderBy(x => x.age)
                               .ThenBy(x => x.name)
                               .Take(8)
                               .ToList();

            var oddModelExcept = model.Except(oddModel).ToList();
            var oddModel1 = oddModelExcept.Where(x => x.age % 2 != 0)
                            .OrderBy(x => x.age)
                            .ThenBy(x => x.name)
                            .Take(4)
                            .ToList();

            var evenModelExcept = model.Except(evenModel).ToList();
            var evenModel1 = evenModelExcept.Where(x => x.age % 2 == 0)
                               .OrderBy(x => x.age)
                               .ThenBy(x => x.name)
                               .Take(4)
                               .ToList();

            var unionFromModel = oddModel1.Union(evenModel1).ToList();

            var titanicLifeBoat = new List<TitanicLifeBoat>();
            for (int i = 1; i <= amountLifeBoat; i++)
            {
                var titanic = new TitanicLifeBoat();
                titanic.CaptainAge = captainOld;
                titanic.LifeBoatNumber = i;
                titanic.People = new List<PersonViewModel>();

                if (i == 1)
                {
                    foreach (var odd in oddModel)
                    {
                        var person = new PersonViewModel();
                        person.name = odd.name;

                        titanic.People.Add(person);
                    }
                }
                else if (i == 2)
                {
                    foreach (var even in evenModel)
                    {
                        var person = new PersonViewModel();
                        person.name = even.name;

                        titanic.People.Add(person);
                    }
                }
                else
                {
                    foreach (var union in unionFromModel)
                    {
                        var person = new PersonViewModel();
                        person.name = union.name;

                        titanic.People.Add(person);
                    }
                }

                titanicLifeBoat.Add(titanic);
            }

            return titanicLifeBoat;
        }
    }
}