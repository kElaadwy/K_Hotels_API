using System;
using System.Collections.Generic;

namespace K_Hotels_API.Models
{
    public partial class Hotel
    {
        public Hotel()
        {
            Bookings = new HashSet<Booking>();
            Rooms = new HashSet<Room>();
        }

        public int Id { get; set; }
        public string Location { get; set; } = null!;
        public double BasePrice { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
