using System;
using System.Collections.Generic;

#nullable disable

namespace efDataBase.Models
{
    public partial class Track
    {
        public Track()
        {
            Musician_Tracks = new HashSet<Musician_Track>();
        }

        public int IdTrack { get; set; }
        public string TrackName { get; set; }
        public float Duration { get; set; }
        public int? IdMusicAlbum { get; set; }


        public virtual Album? Album { get; set; }
        public virtual ICollection<Musician_Track> Musician_Tracks { get; set; }
    }
}
