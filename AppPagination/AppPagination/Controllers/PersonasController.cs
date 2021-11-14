using AppPagination.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppPagination.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        public AppDbContext context { get; set; }
        public PersonasController(AppDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] SampleFilterModel filter)
        {
            int TotalRegistros = context.Person.Count(),
                TotalPages = TotalRegistros / filter.Limit;

            Func<SampleFilterModel, IEnumerable<Person>> filterData = (filterModel) => {

                //StartsWith | Contains
                return context.Person.Where(p => p.Name.Contains(filterModel.Term ?? string.Empty))
                                    .Skip((filterModel.Page - 1) * filterModel.Limit)
                                    .Take(filterModel.Limit);
            };

            var result = new PageColectionResponse<Person>()
            {
                Items = filterData(filter),
                Query = filter
            };

            //Get next page URL string
            SampleFilterModel nextFilter = filter.Clone() as SampleFilterModel;
            nextFilter.Page++;
            string nextUrl = nextFilter.Page >= TotalPages ? null : this.Url.Action("Get", null, nextFilter, Request.Scheme);

            //Get previous page URL string
            SampleFilterModel previousFilter = filter.Clone() as SampleFilterModel;
            previousFilter.Page--;
            string previousUrl = previousFilter.Page <= 0 ? null : this.Url.Action("Get", null, previousFilter, Request.Scheme);

            result.NextPage = !string.IsNullOrWhiteSpace(nextUrl) ? new Uri(nextUrl) : null;
            result.PreviousPage = !String.IsNullOrWhiteSpace(previousUrl) ? new Uri(previousUrl) : null;
                        
            return Ok(result);
        }
    }
}
