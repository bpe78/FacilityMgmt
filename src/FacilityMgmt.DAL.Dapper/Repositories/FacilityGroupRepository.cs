using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using FacilityMgmt.DAL.Common.Interfaces;
using FacilityMgmt.DAL.Common.Models;

namespace FacilityMgmt.DAL.Dapper.Repositories
{
    class FacilityGroupRepository : IFacilityGroupRepository
    {
        private readonly IDbConnection _connection;

        public FacilityGroupRepository(IDbConnection connection)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }

        public async Task<FacilityGroup[]> GetAll()
        {
            try
            {
                var results = await _connection.QueryAsync<FacilityGroup>("[dbo].[facility_group_get_all]", commandType: CommandType.StoredProcedure).ConfigureAwait(false);
                return results.ToArray();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<FacilityGroup> Get(int groupId)
        {
            try
            {
                var result = await _connection.QuerySingleOrDefaultAsync<FacilityGroup>("[dbo].[facility_group_get_by_id]", new { group_id = groupId }, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task<bool> Create(FacilityGroup model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(FacilityGroup model)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(int groupId)
        {
            try
            {
                var result = await _connection.ExecuteAsync("[dbo].[facility_group_delete_by_id]", new { group_id = groupId }, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
