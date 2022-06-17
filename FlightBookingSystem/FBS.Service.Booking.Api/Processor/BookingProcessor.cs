using FBS.Service.Booking.Api.Models;
using FBS.Service.Booking.Api.Repository;
using FBS.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FBS.Service.Booking.Api.Processor
{
    public class BookingProcessor : IBookingProcessor
    {
        private readonly IBookingRespository _bookingRepository;
        private static Random random = new Random();
        public BookingProcessor(IBookingRespository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        public Response<bool> BookFlightTicket(Bookings bookingObj)
        {
            bookingObj.PNRNumber = GetRandomString();
           return _bookingRepository.BookFlightTicket(bookingObj);
        }
        public Response<bool> CancelFlightTicketByPnrNo(string pnrNumber)
        {
            return _bookingRepository.CancelFlightTicketByPnrNo(pnrNumber);
        }
        public Response<List<Bookings>> GetBookingHistoryByEmailId(string emailId)
        {
            return _bookingRepository.GetBookingHistoryByEmailId(emailId);
        }
        public Response<Bookings> GetTicketDetailsByPnrNo(string pnrNumber)
        {
            return _bookingRepository.GetTicketDetailsByPnrNo(pnrNumber);
        }
        private static string GetRandomString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 6)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
