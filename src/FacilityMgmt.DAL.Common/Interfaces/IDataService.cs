using System;

namespace FacilityMgmt.DAL.Common.Interfaces
{
    public interface IDataService
    {
        IDbContext BeginTransaction();
    }
}
