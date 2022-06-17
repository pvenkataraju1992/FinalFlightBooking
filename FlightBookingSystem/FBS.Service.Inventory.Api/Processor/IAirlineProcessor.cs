using FBS.Service.Inventory.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FBS.Service.Common;

namespace FBS.Service.Inventory.Api.Processor
{
    public interface IAirlineProcessor
    {
        Response<IEnumerable<AirlineDetails>> GetAllAirlines();
        Response<bool> RegisterAirline(AirlineDetails airline);
        Response<bool> RemoveAirlineByAirlineId(int airlineId);
        Response<bool> BlockAirlineByAirlineId(int airlineId);
        Response<bool> UpdateIsInventoryByAirlineId(int airlineId);
        Response<bool> AddInventory(InventoryDetails inventory);
    }
}
