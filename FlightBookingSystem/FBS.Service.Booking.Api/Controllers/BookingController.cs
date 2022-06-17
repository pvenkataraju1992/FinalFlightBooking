using FBS.Service.Booking.Api.Models;
using FBS.Service.Booking.Api.Processor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FBS.Service.Booking.Api.Controllers
{
    //[Authorize(AuthenticationSchemes = "AuthenticationKey")]
    [Route("api/flight")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingProcessor _bookingProcessor;
        public BookingController(IBookingProcessor bookingProcessor)
        {
            _bookingProcessor = bookingProcessor;
        }
        [HttpPost]
        [Route("booking")]
        public IActionResult BookTicket([FromBody] Bookings bookingObj)
        {
            var response= _bookingProcessor.BookFlightTicket(bookingObj);
            if (response.Model)
            {
                return Ok(response);
            }
            return Ok(response);
        }
        [HttpPost]
        [Route("booking/history")]
        public IActionResult GetBookingHistory([FromBody] SearchBookingHistory bookingHistory)
        {
            var response = _bookingProcessor.GetBookingHistoryByEmailId(bookingHistory.EmailId);
            if (response.Model.Count() >0)
            {
                return Ok(response);
            }
            return Ok(response);
        }
        [HttpGet]
        [Route("booking/details/{pnrNumber}")]
        public IActionResult GetTicketDetials(string pnrNumber)
        {
            var response = _bookingProcessor.GetTicketDetailsByPnrNo(pnrNumber);
            if (response.Model != null)
            {
                return Ok(response);
            }
            return Ok(response);
        }
        [HttpPost]
        [Route("booking/cancle")]
        public IActionResult CancelTicket([FromBody] SearchBookingHistory bookingHistory)
        {
            var response=_bookingProcessor.CancelFlightTicketByPnrNo(bookingHistory.PNRNumber);
            if (response.Model)
            {
                return Ok(response);
            }
            return Ok(response);
        }
    }
}
