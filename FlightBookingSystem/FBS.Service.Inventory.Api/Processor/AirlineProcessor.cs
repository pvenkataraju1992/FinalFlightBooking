using FBS.Service.Inventory.Api.Models;
using FBS.Service.Inventory.Api.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FBS.Service.Common;

namespace FBS.Service.Inventory.Api.Processor
{
    public class AirlineProcessor : IAirlineProcessor
    {
        private readonly IAirlineRepository _airlineRepository;
        public AirlineProcessor(IAirlineRepository airlineRepository)
        {
            _airlineRepository = airlineRepository;
        }
        public Response<bool> BlockAirlineByAirlineId(int airlineId)
        {
            return _airlineRepository.BlockAirlineByAirlineId(airlineId);
        }
        public Response<bool> UpdateIsInventoryByAirlineId(int airlineId)
        {
            return _airlineRepository.UpdateIsInventoryByAirlineId(airlineId);
        }

        public Response<IEnumerable<AirlineDetails>> GetAllAirlines()
        {
            return _airlineRepository.GetAllAirlines();
        }

        public Response<bool> RegisterAirline(AirlineDetails airline)
        {
            return _airlineRepository.AddAirline(airline);
        }

        public Response<bool> RemoveAirlineByAirlineId(int airlineId)
        {
           return _airlineRepository.RemoveAirlineByAirlineId(airlineId);
        }
        public Response<bool> AddInventory(InventoryDetails inventory)
        {
            return _airlineRepository.AddInventory(inventory);
        }
    }
}
