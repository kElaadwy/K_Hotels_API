using System;
using System.Collections.Generic;

namespace K_Hotels_API.Models
{
    public partial class Room
    {
        public int Id { get; set; }
        public int Location { get; set; }
        public int RoomType { get; set; }
        public bool Empty { get; set; }

        public virtual Hotel LocationNavigation { get; set; } = null!;
        public virtual RoomType RoomTypeNavigation { get; set; } = null!;
    }
}
