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
    public class WonderService : SqlService, IWonderService
    {
        public WonderService(IServiceConfiguration serviceConfiguration) : base(serviceConfiguration)
        {
        }

        public ISet<Wonder> All()
        {
            using (var dbConnection = GetDbConnection())
            {
                return new HashSet<Wonder>(
                    dbConnection.Query<Wonder, Technology, Era, Wonder>(
                        "AllWonders",
                        (wonder, technology, era) =>
                        {
                            technology.Era = era;
                            wonder.Technology = technology;
                            return wonder;
                        },
                        commandType: CommandType.StoredProcedure));
            }
        }

        public ISet<Wonder> AllByEra(long eraId)
        {
            using (var dbConnection = GetDbConnection())
            {
                return new HashSet<Wonder>(
                    dbConnection.Query<Wonder>(
                        "SELECT Wonder.Id, Wonder.Name, Wonder.Tier, Wonder.Cost FROM Wonder JOIN TechnologyEra ON Wonder.TechnologyId = TechnologyEra.TechnologyId WHERE TechnologyEra.EraId = @EraId;",
                        new {EraId = eraId}));
            }
        }

        public ISet<Wonder> AllByTechnology(long technologyId)
        {
            using (var dbConnection = GetDbConnection())
            {
                return new HashSet<Wonder>(
                    dbConnection.Query<Wonder>(
                        "SELECT Wonder.Id, Wonder.Name, Wonder.Tier, Wonder.Cost FROM Wonder WHERE TechnologyId = @TechnologyId;",
                        new {TechnologyId = technologyId}));
            }
        }

        public ISet<Wonder> AllByTier(char tier)
        {
            using (var dbConnection = GetDbConnection())
            {
                return new HashSet<Wonder>(
                    dbConnection.Query<Wonder>(
                        "SELECT Wonder.Id, Wonder.Name, Wonder.Tier, Wonder.Cost FROM Wonder WHERE Tier = @Tier;",
                        new {Tier = tier}));
            }
        }

        public Wonder FindById(long id)
        {
            using (var dbConnection = GetDbConnection())
            {
                return dbConnection.Query<Wonder, Technology, Era, Wonder>(
                                       "FindWonderById",
                                       (wonder, technology, era) =>
                                       {
                                           technology.Era = era;
                                           wonder.Technology = technology;
                                           return wonder;
                                       },
                                       new {id},
                                       commandType: CommandType.StoredProcedure)
                                   .Distinct()
                                   .Single();
            }
        }

        public ISet<Wonder> OthersByEra(long id, long eraId)
        {
            using (var dbConnection = GetDbConnection())
            {
                return new HashSet<Wonder>(
                    dbConnection.Query<Wonder, Technology, Wonder>(
                        "OtherWondersByEra",
                        (wonder, technology) =>
                        {
                            wonder.Technology = technology;
                            return wonder;
                        },
                        new {Id = id, EraId = eraId},
                        commandType: CommandType.StoredProcedure));
            }
        }

        public ISet<Wonder> OthersByTechnology(long id, long technologyId)
        {
            using (var dbConnection = GetDbConnection())
            {
                return new HashSet<Wonder>(
                    dbConnection.Query<Wonder, Era, Wonder>(
                        "OtherWondersByTechnology",
                        (wonder, era) =>
                        {
                            wonder.Technology = new Technology
                            {
                                Id = technologyId,
                                Era = era
                            };

                            return wonder;
                        },
                        new {Id = id, TechnologyId = technologyId},
                        commandType: CommandType.StoredProcedure));
            }
        }

        public ISet<Wonder> OthersByTier(long id, char tier)
        {
            using (var dbConnection = GetDbConnection())
            {
                return new HashSet<Wonder>(
                    dbConnection.Query<Wonder, Technology, Era, Wonder>(
                        "OtherWondersByTier",
                        (wonder, technology, era) =>
                        {
                            technology.Era = era;
                            wonder.Technology = technology;
                            return wonder;
                        },
                        new {Id = id, Tier = tier},
                        commandType: CommandType.StoredProcedure));
            }
        }
    }
}
