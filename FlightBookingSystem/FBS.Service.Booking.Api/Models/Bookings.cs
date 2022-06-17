using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FBS.Service.Booking.Api.Models
{
    public class Bookings
    {
        [Key]
        public int BookingId { get; set; }
        public string FlightNumber { get; set; }
        public double Price { get; set; }
        public string PNRNumber { get; set; }
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string EmailId { get; set; }
        public int NumberOfSeats { get; set; }
        public string MealType { get; set; }
        [DefaultValue(false)]
        public bool IsBookingCancel { get; set; }
        public List<Passengers> Passengers { get; set; }
    }
    
}
