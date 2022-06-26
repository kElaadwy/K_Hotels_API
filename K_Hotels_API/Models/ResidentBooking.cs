using System;
using System.Collections.Generic;

namespace K_Hotels_API.Models
{
    public partial class ResidentBooking
    {
        public int Id { get; set; }
        public int Resident { get; set; }
        public int Booking { get; set; }

        public virtual Booking BookingNavigation { get; set; } = null!;
        public virtual Resident ResidentNavigation { get; set; } = null!;
    }
}
