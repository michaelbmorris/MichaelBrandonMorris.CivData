using MichaelBrandonMorris.Entities.Long;

namespace MichaelBrandonMorris.CivData.Entities
{
    public class Policy : Entity
    {
        public string Name { get; set; }
        public Era Era { get; set; }
    }
}
