using FBS.Service.Common;
using FBS.Service.FlightSearch.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FBS.Service.FlightSearch.Api.Processor
{
    public interface IFlightSearchProcessor
    {
        Response<object> SearchResults(SearchFlight search);
    }
}
