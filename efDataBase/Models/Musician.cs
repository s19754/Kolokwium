using System;
using System.Collections.Generic;

#nullable disable

namespace efDataBase.Models
{
    public partial class Musician
    {
        public Musician()
        {
            Musician_Tracks = new HashSet<Musician_Track>();
        }

        public int IdMusician { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? NickName { get; set; }


        public virtual ICollection<Musician_Track> Musician_Tracks { get; set; }
    }
}
