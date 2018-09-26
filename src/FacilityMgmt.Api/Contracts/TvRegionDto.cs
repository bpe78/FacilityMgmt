using System;
using Newtonsoft.Json;

namespace FacilityMgmt.Api.Contracts
{
    public class TvRegionDto
    {
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        public string Name { get; set; }
    }
}
