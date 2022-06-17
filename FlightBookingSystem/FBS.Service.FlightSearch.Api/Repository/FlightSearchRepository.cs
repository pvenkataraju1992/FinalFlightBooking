using FBS.Service.Common;
using FBS.Service.FlightSearch.Api.DataContext;
using FBS.Service.FlightSearch.Api.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FBS.Service.FlightSearch.Api.Repository
{
    public class FlightSearchRepository : IFlightSearchRepository
    {
        private readonly FlightSearchDbContext _dbContext;
        public FlightSearchRepository(FlightSearchDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Response<object> GetResults(SearchFlight search)
        {
            try
            {
                var result = from ar in _dbContext.Airlines
                             join inv in _dbContext.Inventories on ar.AirlineId equals inv.Airline.AirlineId
                             where ar.IsBlocked != true && ((inv.FromPlace == search.FromPlace && inv.ToPlace == search.ToPlace) && (inv.OneWay == search.OneWay || inv.TwoWay == search.TwoWay))
                             select new
                             {
                                 AirlineName = ar.AirlineName,
                                 AirlineLogo = ar.AirlineLogo,
                                 FlightNumber = inv.FlightNumber,
                                 PlaceFrom = inv.FromPlace,
                                 PlaceTo = inv.ToPlace,
                                 DepartureDate = inv.StartDate,
                                 ArraivalDate = inv.EndDate,
                                 Price = inv.TotalCost
                             };
                if (result.Count() >0)
                    return new Response<object>(result, StatusCodes.Status200OK.ToString());
                else
                    return new Response<object>(null, StatusCodes.Status404NotFound.ToString(), new[] { "Data Not Found" });

            }
            catch (Exception ex)
            {
                return new Response<object>(null, StatusCodes.Status400BadRequest.ToString(),new[] { ex.Message });
            }
        }
    }
}
