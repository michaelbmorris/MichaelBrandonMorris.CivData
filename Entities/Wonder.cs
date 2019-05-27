using System.Collections.Generic;
using MichaelBrandonMorris.Entities.Long;

namespace MichaelBrandonMorris.CivData.Entities
{
    public class Wonder : Entity
    {
        public string Name { get; set; }

        public int Cost { get; set; }

        public Technology Technology { get; set; }

        public ISet<Yield> Yields { get; set; } = new HashSet<Yield>();

        public Terrain RequiredTerrain { get; set; }

        //public int RequiredTerrainRadius { get; set; }

        public char Tier { get; set; }
    }
}
