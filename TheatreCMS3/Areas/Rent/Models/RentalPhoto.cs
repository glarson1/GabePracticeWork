﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Areas.Rent.Models
{
    public class RentalPhoto
    {
        public int RentalPhotoId { get; set; }
        public string RentalsName { get; set; }
        public bool Damaged { get; set; }
        public Byte[] RentalPhotos { get; set; }
        public string Details { get; set; }

    }
}