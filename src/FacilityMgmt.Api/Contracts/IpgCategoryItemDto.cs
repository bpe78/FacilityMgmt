using System;
using Newtonsoft.Json;

namespace FacilityMgmt.Api.Contracts
{
    public class IpgCategoryItemDto
    {
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "value", Required = Required.Always)]
        public string Value { get; set; }

    }
}
