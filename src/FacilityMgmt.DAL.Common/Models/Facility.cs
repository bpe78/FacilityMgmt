using System;

namespace FacilityMgmt.DAL.Common.Models
{
    public class Facility
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string ShortName { get; set; }
        public int GroupId { get; set; }
        public string AccessToken { get; set; }
        public string Geography { get; set; }
        public string Country { get; set; }
        public string AreaCode { get; set; }
        public int TvRegionId { get; set; }
        public string TvProviderId { get; set; }
        public string TvProviderName { get; set; }
        public string TvProviderType { get; set; }
        public bool IsActive { get; set; }
        public long RefreshTimestamp { get; set; }

        public bool IsValid =>
            (Id != Guid.Empty) &&
            !string.IsNullOrWhiteSpace(Name) &&
            !string.IsNullOrWhiteSpace(ShortName) &&
            (GroupId > 0) &&
            !string.IsNullOrWhiteSpace(Geography) &&
            !string.IsNullOrWhiteSpace(Country) &&
            !string.IsNullOrWhiteSpace(TvProviderId);
    }
}
