using System;
using System.Collections.Generic;

namespace Hogwartz_App.Models
{

    public enum MagicType
    {
        Attacking,
        Defensive,
        Healing
    }
    public partial class Wizard
    {
        public int WizardId { get; set; }

        public string Name { get; set; } = null!;

        public string House { get; set; } = null!;

        public string? BloodStatus { get; set; }

        public MagicType PrimaryMagicType { get; set; }

        public bool IsActive { get; set; }

        public int MagicLevel { get; set; }
        public virtual ICollection<HousePoint> HousePoints { get; set; } = new List<HousePoint>();

        public virtual Wand? Wand { get; set; }
    }
}