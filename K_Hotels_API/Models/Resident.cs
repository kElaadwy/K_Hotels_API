using System;
using System.Collections.Generic;

namespace K_Hotels_API.Models
{
    public partial class Resident
    {
        public Resident()
        {
            ResidentBookings = new HashSet<ResidentBooking>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int NationalId { get; set; }

        public virtual ICollection<ResidentBooking> ResidentBookings { get; set; }
    }
}
