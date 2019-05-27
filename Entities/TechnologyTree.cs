using MichaelBrandonMorris.Entities.Long;

namespace MichaelBrandonMorris.CivData.Entities
{
    public class TechnologyTree : Entity
    {
        public long StartVertex { get; set; }
        public long EndVertex { get; set; }
    }
}
