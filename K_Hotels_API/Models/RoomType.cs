using System;
using System.Collections.Generic;

namespace K_Hotels_API.Models
{
    public partial class RoomType
    {
        public RoomType()
        {
            Bookings = new HashSet<Booking>();
            Rooms = new HashSet<Room>();
        }

        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public double Price { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
