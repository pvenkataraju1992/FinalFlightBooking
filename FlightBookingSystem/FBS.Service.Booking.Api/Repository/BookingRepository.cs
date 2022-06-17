using FBS.Service.Booking.Api.DataContext;
using FBS.Service.Booking.Api.Models;
using FBS.Service.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FBS.Service.Booking.Api.Repository
{
    public class BookingRepository : IBookingRespository
    {
        private readonly BookingDbContext _dbContext;
        
        public BookingRepository(BookingDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Response<bool> BookFlightTicket(Bookings bookingObj)
        {
            try
            {
                if (bookingObj != null)
                {
                    _dbContext.Bookings.Add(bookingObj);
                    SaveChanges();
                    return new Response<bool>(true, StatusCodes.Status200OK.ToString(),new[]{"Flight Ticket Booked Successfully!" });
                }
                
            }
            catch (Exception ex)
            {
                return new Response<bool>(false, StatusCodes.Status400BadRequest.ToString(), new[] { ex.Message });
            }
            return new Response<bool>(false, StatusCodes.Status400BadRequest.ToString(), new[] { "Flight Ticket Booking Failed" });
        }
        public Response<bool> CancelFlightTicketByPnrNo(string pnrNumber)
        {
            var booking = _dbContext.Bookings.Where(p=>p.PNRNumber==pnrNumber).SingleOrDefault();
            if (booking != null)
            {
                booking.IsBookingCancel = true;
                SaveChanges();
                return new Response<bool>(true,StatusCodes.Status200OK.ToString(),new[] { "Flight Ticket Cancelled" });
            }
            return new Response<bool>(false,StatusCodes.Status404NotFound.ToString(),new[] { "Failed to Cancel Flight Ticket " });
        }
        public Response<List<Bookings>> GetBookingHistoryByEmailId(string emailId)
        {
            var history= _dbContext.Bookings.Where(x => x.EmailId == emailId).ToList();
            if(history.Count()> 0)
            {
                return new Response<List<Bookings>>(history, StatusCodes.Status200OK.ToString(), new[] { "Fetched Booking History" });
            }
            return new Response<List<Bookings>>(null, StatusCodes.Status404NotFound.ToString(),new[] { "No Data Found" });
        }
        public Response<Bookings> GetTicketDetailsByPnrNo(string pnrNumber)
        {
            var booking= _dbContext.Bookings.Find(pnrNumber);
            if (booking != null)
            {
                return new Response<Bookings>(booking, StatusCodes.Status200OK.ToString());
            }
            return new Response<Bookings>(null,StatusCodes.Status404NotFound.ToString());
        }
        private void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
        
    }
}
