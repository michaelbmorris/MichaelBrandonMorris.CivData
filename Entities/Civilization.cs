using System.Collections.Generic;
using MichaelBrandonMorris.Entities.Long;

namespace MichaelBrandonMorris.CivData.Entities
{
    public class Civilization : Entity
    {
        public string Name { get; set; }

        public string Leader { get; set; }

        public ISet<Terrain> TerrainBiases { get; set; } = new HashSet<Terrain>();

        public ISet<Feature> FeatureBiases { get; set; } = new HashSet<Feature>();

        public bool InverseBiases { get; set; }

        public char Tier { get; set; }
    }
}
