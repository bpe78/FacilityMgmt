using System;
using System.Threading;
using System.Threading.Tasks;

namespace FacilityMgmt.DAL.Common.Interfaces
{
    public interface IDbContext : IDisposable
    {
        IFacilityRepository Facilities { get; }
        IFacilityGroupRepository FacilityGroups { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}