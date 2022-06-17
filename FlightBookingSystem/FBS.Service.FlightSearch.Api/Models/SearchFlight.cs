using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FBS.Service.FlightSearch.Api.Models
{
    public class SearchFlight
    {
        public bool OneWay { get; set; }
        public bool TwoWay { get; set; }
        public string FromPlace { get; set; }
        public string ToPlace { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
