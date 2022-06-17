using FBS.Service.Inventory.Api.Models;
using FBS.Service.Inventory.Api.Processor;
using FBS.Service.Inventory.Api.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FBS.Service.Inventory.Api.Controllers
{
    //[Authorize(AuthenticationSchemes = "AuthenticationKey")]
    [Route("api/flight")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IAirlineProcessor _airlineProcessor;
        public InventoryController(IAirlineProcessor airlineProcessor)
        {
            _airlineProcessor = airlineProcessor;
        }
        [HttpGet]
        [Route("values")]
        public ActionResult<IEnumerable<string>> GetValues()
        {
            return new string[] { "value1", "value2" };
        }
        [HttpGet]
        [Route("airline/getallairlines")]
        public IActionResult GetAllAirlines()
        {
            var respose= _airlineProcessor.GetAllAirlines();
            if (respose.Model.Count()>0)
            {
                return Ok(respose);
            }
            return Ok(respose);
        }
        [HttpPost]
        [Route("airline/register")]
        public IActionResult RegisterAirline([FromBody] AirlineDetails airline)
        {
            var response=_airlineProcessor.RegisterAirline(airline);
            if (response.Model)
            {
                return Ok(response);
            }
            return Ok(response);
        }
        [HttpDelete]
        [Route("airline/remove/{airlineId}")]
        public IActionResult RemoveAirline(int airlineId)
        {
            var response=_airlineProcessor.RemoveAirlineByAirlineId(airlineId);
            if (response.Model)
            {
                return Ok(response);
            }
            return Ok(response);
        }
        [HttpGet]
        [Route("airline/block/{airlineId}")]
        public IActionResult BlockAirline(int airlineId)
        {
            var response=_airlineProcessor.BlockAirlineByAirlineId(airlineId);
            if (response.Model)
            {
                return Ok(response);
            }
            return Ok(response);

        }
        [HttpGet]
        [Route("airline/updateisinventory/{airlineId}")]
        public IActionResult UpdateIsInventoryByAirlineId(int airlineId)
        {
            var response = _airlineProcessor.UpdateIsInventoryByAirlineId(airlineId);
            if (response.Model)
            {
                return Ok(response);
            }
            return Ok(response);

        }
        [HttpPost]
        [Route("airline/inventory/add")]
        public IActionResult AddInventory([FromBody] InventoryDetails inventory)
        {
            var response = _airlineProcessor.AddInventory(inventory);
            if (response.Model)
            {
                return Ok(response);
            }
            return Ok(response);
        }
    }
}
