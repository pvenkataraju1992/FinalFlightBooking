using FBS.Service.Booking.Api.Models;
using FBS.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FBS.Service.Booking.Api.Processor
{
    public interface IBookingProcessor
    {
        Response<bool> BookFlightTicket(Bookings bookingObj);
        Response<bool> CancelFlightTicketByPnrNo(string pnrNumber);
        Response<List<Bookings>> GetBookingHistoryByEmailId(string emailId);
        Response<Bookings> GetTicketDetailsByPnrNo(string pnrNumber);
    }
}
