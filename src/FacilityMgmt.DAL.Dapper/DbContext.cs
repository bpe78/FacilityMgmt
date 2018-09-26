using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using FacilityMgmt.DAL.Common.Interfaces;
using FacilityMgmt.DAL.Dapper.Repositories;

namespace FacilityMgmt.DAL.Dapper
{
    public class DbContext : IDbContext
    {
        private readonly IDbConnection _connection;

        public DbContext(IDbConnection connection)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
            _connection.Open();

            Facilities = new FacilityRepository(_connection);
            FacilityGroups = new FacilityGroupRepository(_connection);
        }

        public IFacilityRepository Facilities { get; }
        public IFacilityGroupRepository FacilityGroups { get; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}
