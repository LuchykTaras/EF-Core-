using System;
using System.Collections.Generic;

namespace Hogwartz_App.Models
{
    public partial class Subject
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Teacher { get; set; } = null!;
        public virtual ICollection<HousePoint> HousePoints { get; set; } = new List<HousePoint>();
    }
}