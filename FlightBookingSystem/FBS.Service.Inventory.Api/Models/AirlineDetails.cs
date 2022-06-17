using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FBS.Service.Inventory.Api.Models
{
    public class AirlineDetails
    {
        [Key]
        public int AirlineId { get; set; }
        public string AirlineName { get; set; }
        public string AirlineLogo { get; set; }
        public string AirlineContactNumber { get; set; }
        public string AirlineContactAddress { get; set; }
        [DefaultValue(false)]
        public bool IsInventory { get; set; }
        [DefaultValue(false)]
        public bool IsBlocked { get; set; }
    }
}
