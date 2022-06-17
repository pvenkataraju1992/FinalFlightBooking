using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FBS.Service.Booking.Api.Models
{
    public class SearchBookingHistory
    {
        public string PNRNumber { get; set; }
        public string EmailId { get; set; }
    }
}
