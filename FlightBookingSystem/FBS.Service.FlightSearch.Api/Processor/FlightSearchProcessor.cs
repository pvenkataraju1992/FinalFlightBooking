using FBS.Service.Common;
using FBS.Service.FlightSearch.Api.Models;
using FBS.Service.FlightSearch.Api.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FBS.Service.FlightSearch.Api.Processor
{
    public class FlightSearchProcessor : IFlightSearchProcessor
    {
        private readonly IFlightSearchRepository _flightSearchRepository;
        public FlightSearchProcessor(IFlightSearchRepository flightSearchRepository)
        {
            _flightSearchRepository = flightSearchRepository;
        }
        public Response<object> SearchResults(SearchFlight search)
        {
            return _flightSearchRepository.GetResults(search);
        }
    }
}
