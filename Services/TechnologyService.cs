using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using MichaelBrandonMorris.CivData.Entities;
using MichaelBrandonMorris.CivData.Services.Interfaces;
using MichaelBrandonMorris.Services.Configuration;
using MichaelBrandonMorris.Services.Sql;

namespace MichaelBrandonMorris.CivData.Services
{
    public class TechnologyService : SqlService, ITechnologyService
    {
        public TechnologyService(IServiceConfiguration serviceConfiguration) : base(serviceConfiguration)
        {
        }

        public ISet<Era> AllByEras()
        {
            using (var dbConnection = GetDbConnection())
            using (var gridReader = dbConnection.QueryMultiple("AllTechnologiesByEra", commandType: CommandType.StoredProcedure))
            {
                var eras = gridReader.Read<Era>().ToDictionary(x => x.Id);
                var technologies = gridReader.Read<Technology>();

                foreach (var technology in technologies)
                {
                    eras[technology.EraId].Technologies.Add(technology);
                }

                return new HashSet<Era>(eras.Values);
            }
        }

        public Technology FindById(long id)
        {
            using (var dbConnection = GetDbConnection())
            using (var gridReader = dbConnection.QueryMultiple("FindTechnologyById", new {Id = id}, commandType: CommandType.StoredProcedure))
            {
                var technology = gridReader.ReadSingle<Technology>();
                technology.Era = gridReader.ReadSingle<Era>();
                technology.RequiredTechnologies = new HashSet<Technology>(gridReader.Read<Technology>());
                technology.UnlockedTechnologies = new HashSet<Technology>(gridReader.Read<Technology>());
                technology.Wonders = new HashSet<Wonder>(gridReader.Read<Wonder>());
                return technology;
            }
        }
    }
}
