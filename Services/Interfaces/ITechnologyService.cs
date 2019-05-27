using System.Collections.Generic;
using MichaelBrandonMorris.CivData.Entities;

namespace MichaelBrandonMorris.CivData.Services.Interfaces
{
    public interface ITechnologyService
    {
        ISet<Era> AllByEras();
        Technology FindById(long id);
    }
}
