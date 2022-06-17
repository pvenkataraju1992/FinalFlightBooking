using FBS.Service.Booking.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FBS.Service.Common;

namespace FBS.Service.Booking.Api.Repository
{
    public interface IBookingRespository
    {
        Response<bool> BookFlightTicket(Bookings bookingObj);
        Response<bool> CancelFlightTicketByPnrNo(string pnrNumber);
        Response<List<Bookings>> GetBookingHistoryByEmailId(string emailId);
        Response<Bookings> GetTicketDetailsByPnrNo(string pnrNumber);
    }
}
