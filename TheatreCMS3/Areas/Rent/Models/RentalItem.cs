using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Areas.Rent.Models
{
    public class RentalItem
    {
        public int RentalItemId { get; set; }
        public string Item { get; set; }

        [DisplayName("Item Description")]
        public string ItemDescription { get; set; }

        [DisplayName("Pickup Date")]
        public DateTime PickupDate { get; set; }

        [DisplayName("Return Date")]
        public DateTime? ReturnDate { get; set; }

        [DisplayName("Item Photo")]
        public byte[] ItemPhoto { get; set; }

    }
}