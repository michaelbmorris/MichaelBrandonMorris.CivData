using System.Collections.Generic;
using MichaelBrandonMorris.CivData.Entities;

namespace MichaelBrandonMorris.CivData.Services.Interfaces
{
    public interface IWonderService
    {
        ISet<Wonder> All();
        ISet<Wonder> AllByEra(long eraId);
        ISet<Wonder> AllByTechnology(long technologyId);
        ISet<Wonder> AllByTier(char tier);
        Wonder FindById(long id);
        ISet<Wonder> OthersByEra(long id, long eraId);
        ISet<Wonder> OthersByTechnology(long id, long technologyId);
        ISet<Wonder> OthersByTier(long id, char tier);
    }
}
