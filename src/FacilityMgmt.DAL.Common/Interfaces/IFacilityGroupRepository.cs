using System;
using System.Threading.Tasks;
using FacilityMgmt.DAL.Common.Models;

namespace FacilityMgmt.DAL.Common.Interfaces
{
    public interface IFacilityGroupRepository
    {
        Task<FacilityGroup[]> GetAll();
        Task<FacilityGroup> Get(int groupId);

        Task<int> Create(FacilityGroup model);
        Task<bool> Update(FacilityGroup model);
        Task<bool> Delete(int groupId);
    }
}
