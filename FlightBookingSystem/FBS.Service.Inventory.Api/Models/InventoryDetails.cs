using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FBS.Service.Inventory.Api.Models
{
    public class InventoryDetails
    {
        [Key]
        public int InventoryId { get; set; }
        public string FlightNumber { get; set; }
        public int AirlineId { get; set; }
        public string FromPlace { get; set; }
        public string ToPlace { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ScheduledDays { get; set; }
        public string InstumentUsed { get; set; }
        public int NoOfBusinessClassSeats { get; set; }
        public int NoOfNonBusinessClassSeats { get; set; }
        public double TotalCost { get; set; }
        public int NumberOfRows { get; set; }
        public string MealType { get; set; }
        [DefaultValue(false)]
        public bool OneWay { get; set; }
        [DefaultValue(false)]
        public bool TwoWay { get; set; }
        [ForeignKey("AirlineId")]
        public virtual AirlineDetails Airline { get; set; }

    }
}
