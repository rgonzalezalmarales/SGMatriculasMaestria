using AppPagination.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppPagination.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        IEnumerable<Person> persons = new List<Person>()
        {
            new Person(){ Name = "Nancy Davolio", DOB = DateTime.Parse("1948-12-08"), Email="nancy.davolio@test.com" },
            new Person(){ Name = "Andrew Fuller", DOB = DateTime.Parse("1952-02-19"), Email="andrew.fuller@test.com" },
            new Person(){ Name = "Janet Leverling", DOB = DateTime.Parse("1963-08-30"), Email="janet.leverling@test.com" },
            new Person(){ Name = "Margaret Peacock", DOB = DateTime.Parse("1937-09-19"), Email="margaretpeacock@test.com" },
            new Person(){ Name = "Steven Buchanan", DOB = DateTime.Parse("1955-03-04"), Email="steven.buchanan@test.com" },
            new Person(){ Name = "Michael Suyama", DOB = DateTime.Parse("1963-07-02"), Email="michael.suyama@test.com" },
            new Person(){ Name = "Robert King", DOB = DateTime.Parse("1960-05-29"), Email="robert.king@test.com" },
            new Person(){ Name = "Laura Callahan", DOB = DateTime.Parse("1958-01-09"), Email="laura.callahan@test.com" },
            new Person(){ Name = "Anne Dodsworth", DOB = DateTime.Parse("1966-01-27"), Email="anne.ddodsworth@test.com" },
            new Person(){ Name = "Nicole S. González", DOB = DateTime.Parse("2016-07-24"), Email="nicole.gonzalez@test.com" },
            new Person(){ Name = "Fabio González", DOB = DateTime.Parse("2021-06-22"), Email="fabio.gonzalez@test.com" },
            new Person(){ Name = "Ileana Salsegames", DOB = DateTime.Parse("1989-02-09"), Email="ileana.salsegames@test.com" },
            new Person(){ Name = "Virgen Almarles", DOB = DateTime.Parse("1967-12-14"), Email="virgen.almarales@test.com" },
            new Person(){ Name = "Ramiro García", DOB = DateTime.Parse("1967-05-05"), Email="ramiro.garcia@test.com" },
            new Person(){ Name = "Yailix Vernal", DOB = DateTime.Parse("1979-08-24"), Email="yailix.vernal@test.com" },
            new Person(){ Name = "Yaibel Venero", DOB = DateTime.Parse("2004-05-08"), Email="yaibel.venero@test.com" },
            new Person(){ Name = "Yonar M. Contrera", DOB = DateTime.Parse("2006-01-01"), Email="yonar.conterar@test.com" },
            new Person(){ Name = "Raimir González", DOB = DateTime.Parse("2000-01-04"), Email="raimir.gonzalez@test.com" },
            new Person(){ Name = "Ramiro González", DOB = DateTime.Parse("1988-06-22"), Email="ramiro.gonzalez@test.com" }
        };
        // GET: api/<ValuesController>
        [HttpGet]
       public PageColectionResponse<Person> Get([FromQuery] SampleFilterModel filter)
       {
            Func<SampleFilterModel, IEnumerable<Person>> filterData = (filterModel) => {
                //string _value = null;
                //var prueba = _value ?? "vacia"; 
                //var tempo = filterModel.Term ?? String.Empty;
                //var tempo1 = StringComparison.InvariantCultureIgnoreCase;
                return persons.Where(p => p.Name.StartsWith(filterModel.Term ?? String.Empty, StringComparison.InvariantCultureIgnoreCase))
                                    .Skip((filterModel.Page - 1)*filterModel.Limit)
                                    .Take(filterModel.Limit);
            };

            //var result = new PageColectionResponse<Person>();
            //result.Items = filterData(filter);

            var result = new PageColectionResponse<Person>() 
            { 
                Items = filterData(filter),
                Query = filter
            };
            
            //Get next page URL string
            SampleFilterModel nextFilter = filter.Clone() as SampleFilterModel;
            nextFilter.Page ++ ;
            //Action("Get", null, nextFilter, Request.Scheme)
            //string newUry = this.Url.Action("Get","Values",nextFilter,Request.Scheme);
            string nextUrl = filterData(nextFilter).Count() <= 0 ? null : this.Url.Action("Get", null, nextFilter, Request.Scheme);


            //Get previous page URL string
            SampleFilterModel previousFilter = filter.Clone() as SampleFilterModel;
            previousFilter.Page --;
            string previousUrl = previousFilter.Page <= 0 ? null : this.Url.Action("Get", null, previousFilter, Request.Scheme);

            result.NextPage = !string.IsNullOrWhiteSpace(nextUrl) ? new Uri(nextUrl) : null;
            result.PreviousPage = !String.IsNullOrWhiteSpace(previousUrl) ? new Uri(previousUrl) : null;
           

            return result;
       }
        /*public IActionResult Get([FromQuery] FilterModel filter)
        {
            //filter.MinDate = DateTime.Parse("13/06/2021");
            return Ok(filter);
        }*/

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
