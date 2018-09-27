using System;
using System.Threading.Tasks;
using FacilityMgmt.DAL.Common.Models;

namespace FacilityMgmt.DAL.Common.Interfaces
{
    public interface IFacilityRepository
    {
        Task<Facility[]> GetAll(int groupId);
        Task<Facility> Get(Guid facilityId);

        Task<bool> Create(Facility model);
        Task<bool> Update(Facility model);
        Task<bool> Delete(Guid facilityId);
    }
}
