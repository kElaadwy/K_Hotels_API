using System;
using System.Collections.Generic;

namespace K_Hotels_API.Models
{
    public partial class Booking
    {
        public Booking()
        {
            ResidentBookings = new HashSet<ResidentBooking>();
        }

        public int Id { get; set; }
        public int Location { get; set; }
        public int RoomType { get; set; }
        public double Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual Hotel LocationNavigation { get; set; } = null!;
        public virtual RoomType RoomTypeNavigation { get; set; } = null!;
        public virtual ICollection<ResidentBooking> ResidentBookings { get; set; }
    }
}
