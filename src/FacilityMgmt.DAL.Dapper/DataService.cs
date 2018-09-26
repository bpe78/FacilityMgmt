using System;
using System.Data;
using System.Data.SqlClient;
using FacilityMgmt.DAL.Common.Interfaces;

namespace FacilityMgmt.DAL.Dapper
{
    public class DataService : IDataService
    {
        public DataService(IDbConfiguration dbConfiguration)
        {
            global::Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
            DbConfiguration = dbConfiguration ?? throw new ArgumentNullException(nameof(dbConfiguration));
        }

        public IDbConfiguration DbConfiguration { get; }

        public IDbContext BeginTransaction()
        {
            return new DbContext(new SqlConnection(DbConfiguration.ConnectionString));
        }
    }
}
