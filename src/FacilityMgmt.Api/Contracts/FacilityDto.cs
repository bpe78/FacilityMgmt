using System;
using Newtonsoft.Json;

namespace FacilityMgmt.Api.Contracts
{
    public class FacilityDto
    {
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "shortName", Required = Required.Always)]
        public string ShortName { get; set; }

        [JsonProperty(PropertyName = "groupId", Required = Required.Always)]
        public int GroupId { get; set; }

        [JsonProperty(PropertyName = "accessToken", Required = Required.Always)]
        public string AccessToken { get; set; }

        [JsonProperty(PropertyName = "geography", Required = Required.Always)]
        public string Geography { get; set; }

        [JsonProperty(PropertyName = "country", Required = Required.Always)]
        public string Country { get; set; }

        [JsonProperty(PropertyName = "areaCode", Required = Required.AllowNull)]
        public string AreaCode { get; set; }

        [JsonProperty(PropertyName = "tvRegionId", Required = Required.AllowNull)]
        public string TvRegionId { get; set; }

        [JsonProperty(PropertyName = "tvProviderId", Required = Required.Always)]
        public string TvProviderId { get; set; }

        [JsonProperty(PropertyName = "tvProviderName", Required = Required.Always)]
        public string TvProviderName { get; set; }

        [JsonProperty(PropertyName = "tvProviderType", Required = Required.Always)]
        public string TvProviderType { get; set; }

        [JsonProperty(PropertyName = "isActive", Required = Required.Always)]
        public bool IsActive { get; set; }

        [JsonProperty(PropertyName = "refreshTimestamp", Required = Required.Always)]
        public long RefreshTimestamp { get; set; }
    }
}
