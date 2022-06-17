using FBS.Service.Common;
using FBS.Service.Inventory.Api.DataContext;
using FBS.Service.Inventory.Api.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FBS.Service.Inventory.Api.Repository
{
    public class AirlineRepository : IAirlineRepository
    {
        private readonly AirlinesDbContext _dbContext;
        public AirlineRepository(AirlinesDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Response<IEnumerable<AirlineDetails>> GetAllAirlines()
        {
            var airlineList = _dbContext.Airlines.Where(x => x.IsBlocked == false).ToList();
            if(airlineList.Count() > 0)
                return new Response<IEnumerable<AirlineDetails>>(airlineList, StatusCodes.Status200OK.ToString());

            return new Response<IEnumerable<AirlineDetails>>(null,StatusCodes.Status404NotFound.ToString(),new[] { "No Data Found" });
        }
        public Response<bool> AddAirline(AirlineDetails airline)
        {
            try
            {
                if (airline != null)
                {
                    _dbContext.Airlines.Add(airline);
                    SaveChanges();
                    return new Response<bool>(true, StatusCodes.Status200OK.ToString(), new[] { "New Airline Addedd Successfully" });
                }
            }
            catch (Exception ex)
            {
                return new Response<bool>(false, StatusCodes.Status400BadRequest.ToString(), new[] { ex.Message });
            }
            return new Response<bool>(false, StatusCodes.Status400BadRequest.ToString(), new[] { "Failed to Add New Airline" });
        }

        public Response<bool> BlockAirlineByAirlineId(int airlineId)
        {
            var airline = _dbContext.Airlines.Find(airlineId);
            if (airline != null)
            {
                airline.IsBlocked = true;
                SaveChanges();
                return new Response<bool>(true, StatusCodes.Status200OK.ToString(), new[] { "Airline Blocked Successfully" });
            }
            return new Response<bool>(false, StatusCodes.Status400BadRequest.ToString(), new[] { "Failed to Block Airline" });
        }
        public Response<bool> UpdateIsInventoryByAirlineId(int airlineId)
        {
            var airline = _dbContext.Airlines.Find(airlineId);
            if (airline != null)
            {
                airline.IsInventory = true;
                SaveChanges();
                return new Response<bool>(true, StatusCodes.Status200OK.ToString());
            }
            return new Response<bool>(false, StatusCodes.Status400BadRequest.ToString());
        }
        public Response<bool> RemoveAirlineByAirlineId(int airlineId)
        {
            var airline = _dbContext.Airlines.Find(airlineId);
            if (airline != null)
            {
                _dbContext.Airlines.Remove(airline);
                SaveChanges();
                return new Response<bool>(true,StatusCodes.Status200OK.ToString(),new[] {"Airline Removed Successfully" });
            }
            return new Response<bool>(false, StatusCodes.Status400BadRequest.ToString(),new[] {"Failed to Remove Airline"});
        }
        public Response<bool> AddInventory(InventoryDetails inventory)
        {
            try
            {
                if (inventory != null)
                {
                    _dbContext.Inventories.Add(inventory);
                    SaveChanges();
                    return new Response<bool>(true, StatusCodes.Status200OK.ToString(), new[] { "Inventory Addedd Successfully" });
                }
            }
            catch (Exception ex)
            {
                return new Response<bool>(false, StatusCodes.Status400BadRequest.ToString(), new[] { ex.Message });
            }
            return new Response<bool>(false, StatusCodes.Status400BadRequest.ToString(), new[] { "Failed to Add Inventory" });
        }
        private void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
