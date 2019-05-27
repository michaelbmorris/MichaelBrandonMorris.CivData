using System.Collections.Generic;
using MichaelBrandonMorris.Entities.Long;

namespace MichaelBrandonMorris.CivData.Entities
{
    public class Era : Entity
    {
        public string Name { get; set; }
        public int Position { get; set; }
        public ISet<Technology> Technologies { get; set; } = new HashSet<Technology>();
    }
}