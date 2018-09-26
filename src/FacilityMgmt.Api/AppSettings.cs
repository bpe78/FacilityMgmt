using System;
using FacilityMgmt.Api.Interfaces;
using Microsoft.Extensions.Configuration;

namespace FacilityMgmt.Api
{
    class AppSettings : IAppSettings
    {
        private readonly IConfiguration _configuration;

        public AppSettings(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public string ServiceName { get; } = "TvListingsWebApi";

        public string WebServerAddress
        {
            get
            {
                const string key = "listeningPort";
                var value = _configuration.GetValue(key, string.Empty);

                if (string.IsNullOrEmpty(value))
                    throw new InvalidOperationException($"Could not read setting [{key}].");
                var port = ushort.Parse(value);

                return $"http://+:{port}/";
            }
        }

        public string RedisServer
        {
            get
            {
                const string key = "redis:serverAddress";
                var value = _configuration.GetValue(key, string.Empty);

                if (string.IsNullOrEmpty(value))
                    throw new InvalidOperationException($"Could not read setting [{key}]");
                return value;
            }
        }

        public byte RedisAiringsDbIndex
        {
            get
            {
                const string key = "redis:airingsDbIdx";
                var value = _configuration.GetValue(key, string.Empty);
                if (string.IsNullOrWhiteSpace(value))
                    return 0;
                var dbId = byte.Parse(value);
                if (dbId > 15)
                    throw new InvalidOperationException($"[redis:airingsDbIdx] index out of bounds: {dbId}");

                return dbId;
            }
        }

        public string FacilityConnectionString => _configuration.GetConnectionString("FacilityConnectionString");

        public void Validate()
        {
            //TODO: validate each setting
        }
    }
}
