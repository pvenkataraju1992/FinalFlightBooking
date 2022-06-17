using FBS.Service.Common;
using FBS.Service.FlightSearch.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FBS.Service.FlightSearch.Api.Repository
{
    public interface IFlightSearchRepository
    {
        Response<object> GetResults(SearchFlight search);
    }
}
