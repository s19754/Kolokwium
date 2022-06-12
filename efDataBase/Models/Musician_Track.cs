using System;
using System.Collections.Generic;

#nullable disable

namespace efDataBase.Models
{
    public partial class Musician_Track
    {
        public int IdMusician { get; set; }
        public int IdTrack { get; set; }
        

        public virtual Track Tracks { get; set; }
        public virtual Musician Musicians { get; set; }
    }
}
