using System.Collections.Generic;
using MichaelBrandonMorris.Entities.Long;

namespace MichaelBrandonMorris.CivData.Entities
{
    public class Technology : Entity
    {
        public string Name { get; set; }

        public int PositionX { get; set; }

        public int PositionY { get; set; }

        public Era Era { get; set; }

        public long EraId { get; set; }

        public int Cost { get; set; }

        public int CumulativeCost { get; set; }

        public ISet<Technology> RequiredTechnologies { get; set; } = new HashSet<Technology>();

        public ISet<Technology> UnlockedTechnologies { get; set; } = new HashSet<Technology>();

        public ISet<Wonder> Wonders { get; set; } = new HashSet<Wonder>();
    }
}