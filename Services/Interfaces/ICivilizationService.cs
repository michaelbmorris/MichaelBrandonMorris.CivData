using System.Collections.Generic;
using MichaelBrandonMorris.CivData.Entities;

namespace MichaelBrandonMorris.CivData.Services.Interfaces
{
    public interface ICivilizationService
    {
        ISet<Civilization> All();
        Civilization FindById(long id);
        void Update(Civilization civilization);
    }
}
