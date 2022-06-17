using FBS.Service.FlightSearch.Api.Models;
using FBS.Service.FlightSearch.Api.Processor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FBS.Service.FlightSearch.Api.Controllers
{
    [Authorize(AuthenticationSchemes = "AuthenticationKey")]
    [Route("api/flight")]
    [ApiController]
    public class FlightSearchController : ControllerBase
    {
        private readonly IFlightSearchProcessor _flightSearchProcessor;
        public FlightSearchController(IFlightSearchProcessor flightSearchProcessor)
        {
            _flightSearchProcessor = flightSearchProcessor;
        }
        [HttpPost]
        [Route("search")]
        public IActionResult SearchFlight(SearchFlight search)
        {
            var response = _flightSearchProcessor.SearchResults(search);
            if(response.Model!=null)
            {
                return Ok(response);
            }
            return Ok(response);
        }
    }
}
