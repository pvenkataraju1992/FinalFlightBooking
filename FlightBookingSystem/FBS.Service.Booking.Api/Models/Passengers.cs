using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FBS.Service.Booking.Api.Models
{
    public class Passengers
    {
        [Key]
        public int PassengerId { get; set; }
        public string PassengerName { get; set; }
        public int PassengerAge { get; set; }
        public string PassengerGender { get; set; }
        public int PassengerSeatNumber { get; set; }
        [ForeignKey("BookingId")]
        public virtual Bookings Booking { get; set; }
    }
}
