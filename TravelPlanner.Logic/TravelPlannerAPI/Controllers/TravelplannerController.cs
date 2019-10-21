using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TravelPlanner.Logic;

namespace TravelPlannerAPI.Controllers
{
    [ApiController]
    [Route("api/travelPlan")]
    public class TravelplannerController : ControllerBase
    {
        private List<Schedule> Schedules;
        private readonly ITravelPlaner travelPlaner;

        private  HttpClient Client;
        public TravelplannerController(IHttpClientFactory factory, ITravelPlaner travelPlaner)
        {
            Client = factory.CreateClient();
            this.travelPlaner = travelPlaner;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string from, [FromQuery] string to, [FromQuery] string start)
        {
           
            var response = await Client
                .GetAsync("https://cddataexchange.blob.core.windows.net/data-exchange/htl-homework/travelPlan.json");

            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            Schedules = JsonSerializer.Deserialize<List<Schedule>>(responseBody);
            var plan = travelPlaner.GetResponseTrip(Schedules, from, to, start);
            if (plan == null)
            {
                return NotFound();
            }
            //return pokemons.Select;
            return Ok(plan);
        }


    }
}
