using System;

namespace FacilityMgmt.Api.Interfaces
{
    public interface IAppSettings
    {
        string ServiceName { get; }
        string WebServerAddress { get; }

        string RedisServer { get; }
        byte RedisAiringsDbIndex { get; }
        string FacilityConnectionString { get; }

        void Validate();
    }
}
