using System.Collections.Generic;
using MichaelBrandonMorris.Entities.Long;

namespace MichaelBrandonMorris.CivData.Entities
{
    public class Terrain : Entity
    {
        public string Name { get; set; }
    }

    public class Feature : Entity
    {
        public string Name { get; set; }
    }

    public class Yield : Entity
    {
        public Resource Resource { get; set; }
        public int Quantity { get; set; }
    }

    public class Resource : Entity
    {
        public string Name { get; set; }
    }
}
