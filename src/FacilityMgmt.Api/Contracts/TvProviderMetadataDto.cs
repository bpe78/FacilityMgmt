using System;
using Newtonsoft.Json;

namespace FacilityMgmt.Api.Contracts
{
    public class TvProviderMetadataDto
    {
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public string GnId { get; set; }

        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        public string ProviderType { get; set; }

        [JsonProperty(PropertyName = "place", Required = Required.AllowNull)]
        public string Place { get; set; }
    }
}
