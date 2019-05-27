using System.Collections.Generic;
using Dapper;
using MichaelBrandonMorris.CivData.Entities;
using MichaelBrandonMorris.CivData.Services.Interfaces;
using MichaelBrandonMorris.Services.Configuration;
using MichaelBrandonMorris.Services.Sql;

namespace MichaelBrandonMorris.CivData.Services
{
    public class CivilizationService : SqlService, ICivilizationService
    {
        public CivilizationService(IServiceConfiguration serviceConfiguration) : base(serviceConfiguration)
        {
        }

        public ISet<Civilization> All()
        {
            using (var dbConnection = GetDbConnection())
            {
                return new HashSet<Civilization>(dbConnection.Query<Civilization>("SELECT * FROM Civilization;"));
            }
        }

        public Civilization FindById(long id)
        {
            using (var dbConnection = GetDbConnection())
            {
                return dbConnection.QuerySingle<Civilization>("SELECT * FROM Civilization WHERE Id = @Id;", new {id});
            }
        }

        public void Update(Civilization civilization)
        {
            using (var dbConnection = GetDbConnection())
            {
                dbConnection.Execute(
                    "UPDATE Civilization SET Name = @Name, Leader = @Leader, Tier = @Tier WHERE Id = @Id;",
                    new {civilization.Name, civilization.Leader, civilization.Tier, civilization.Id});
            }
        }
    }
}
