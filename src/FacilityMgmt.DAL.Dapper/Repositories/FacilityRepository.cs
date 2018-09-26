using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using FacilityMgmt.DAL.Common.Interfaces;
using FacilityMgmt.DAL.Common.Models;

namespace FacilityMgmt.DAL.Dapper.Repositories
{
    class FacilityRepository : IFacilityRepository
    {
        private readonly IDbConnection _connection;

        public FacilityRepository(IDbConnection connection)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }

        public async Task<Facility[]> GetAll()
        {
            try
            {
                var results = await _connection.QueryAsync<Facility>("[dbo].[facility_get_all]", commandType: CommandType.StoredProcedure).ConfigureAwait(false);
                return results.ToArray();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Facility> Get(Guid facilityId)
        {
            try
            {
                var result = await _connection.QuerySingleOrDefaultAsync<Facility>("[dbo].[facility_get_by_id]", new { facility_id = facilityId }, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task<bool> Create(Facility model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Facility model)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(Guid facilityId)
        {
            try
            {
                var result = await _connection.ExecuteAsync("[dbo].[facility_delete_by_id]", new { facility_id = facilityId }, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
