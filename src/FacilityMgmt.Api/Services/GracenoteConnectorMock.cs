using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FacilityMgmt.Api.Contracts;
using FacilityMgmt.Api.Interfaces;

namespace FacilityMgmt.Api.Services
{
    class GracenoteConnectorMock : IGracenoteConnector
    {
        private readonly Serilog.ILogger _logger;
        private readonly GeographicRegionDto[] _geoRegions;

        public GracenoteConnectorMock(Serilog.ILogger logger)
        {
            _logger = logger.ForContext(typeof(GracenoteConnectorMock));

            _geoRegions = new[]
            {
                new GeographicRegionDto { Id = "NA", Name = "North America" },
                new GeographicRegionDto { Id = "APAC", Name = "Asia-Pacific" },
                new GeographicRegionDto { Id = "EU", Name = "Europe" },
                new GeographicRegionDto { Id = "SA", Name = "South America" },
                new GeographicRegionDto { Id = "JP", Name = "Japan" }
            };
        }

        public Task<GeographicRegionDto[]> GetGeographicRegions()
        {
            return Task.FromResult(_geoRegions);
        }

        public Task<CountryDto[]> GetCountries(string geographyId)
        {
            switch (geographyId.ToUpperInvariant())
            {
                case "NA":
                    return Task.FromResult(new[]
                    {
                        new CountryDto { Id = "USA", Name = "United States" },
                        new CountryDto { Id = "CAN", Name = "Canada" },
                        new CountryDto { Id = "MEX", Name = "Mexico" },
                    });
                case "APAC":
                    return Task.FromResult(new[]
                    {
                        new CountryDto { Id = "AUS", Name = "Australia" },
                        new CountryDto { Id = "NZL", Name = "New Zealand" }
                    });
                case "EU":
                    return Task.FromResult(new[]
                    {
                        new CountryDto { Id = "GER", Name = "Germany" },
                        new CountryDto { Id = "GBR", Name = "United Kingdom" }
                    });
                case "SA":
                    return Task.FromResult(new[]
                    {
                        new CountryDto { Id = "ARG", Name = "Argentina" },
                        new CountryDto { Id = "BRA", Name = "Brasil" }
                    });
                case "JP":
                    return Task.FromResult(new[]
                    {
                        new CountryDto { Id = "JPN", Name = "Japan" },
                    });
                default:
                    throw new NotImplementedException($"Unknown geography: {geographyId}");
            }
        }

        public async Task<TvProviderMetadataDto[]> GetProviders(string geography, string country, string region)
        {
            if (string.IsNullOrWhiteSpace(geography))
                throw new ArgumentNullException(nameof(geography));
            if (string.IsNullOrWhiteSpace(country))
                throw new ArgumentNullException(nameof(country));
            if (string.IsNullOrWhiteSpace(region))
                throw new ArgumentNullException(nameof(region));

            var countries = await GetCountries(geography).ConfigureAwait(false);
            if (!countries.Any(c => c.Id.ToUpper() == country.ToUpper()))
                throw new ArgumentException($"{country} is not valid in {geography}");

            switch (geography.ToUpperInvariant())
            {
                case "NA": return await GetNorthAmericaProviders(country, region).ConfigureAwait(false);
                case "APAC":
                case "EU":
                case "SA":
                case "JP":
                    if (int.TryParse(region, out int tvRegion))
                        return await GetProviders(tvRegion).ConfigureAwait(false);
                    else
                        throw new ArgumentException(nameof(region));
                default:
                    throw new NotImplementedException();
            }
        }

        public async Task<TvProviderMetadataDto[]> GetNorthAmericaProviders(string country, string postalCode)
        {
            if (string.IsNullOrWhiteSpace(country))
                throw new ArgumentNullException(nameof(country));
            if (string.IsNullOrWhiteSpace(postalCode))
                throw new ArgumentNullException(nameof(postalCode));

            //TODO

            return null;
        }

        public async Task<TvProviderMetadataDto[]> GetProviders(int tvRegion)
        {
            if (tvRegion <= 0)
                throw new ArgumentNullException(nameof(tvRegion));

            //TODO

            return null;
        }

        public async Task<TvRegionDto[]> GetTvRegions(string country)
        {
            //TODO

            return null;
        }

        public Task<IpgCategoryItemDto[]> GetIpgCategories(string categoryId)
        {
            if (string.IsNullOrWhiteSpace(categoryId))
                throw new ArgumentNullException(nameof(categoryId));

            switch (categoryId.ToUpperInvariant())
            {
                case "IPGCATEGORY_L1":
                    return Task.FromResult(new[]
                    {
                        new IpgCategoryItemDto { Id = 67856, Value = "Movie" },
                        new IpgCategoryItemDto { Id = 67857, Value = "TV Series" },
                        new IpgCategoryItemDto { Id = 67858, Value = "Sports" },
                        new IpgCategoryItemDto { Id = 67859, Value = "News / Info" },
                        new IpgCategoryItemDto { Id = 67860, Value = "Entertainment" },
                        new IpgCategoryItemDto { Id = 67861, Value = "Music" },
                        new IpgCategoryItemDto { Id = 67862, Value = "Kids" },
                        new IpgCategoryItemDto { Id = 67863, Value = "Topics / Documentary" }
                    });

                case "IPGCATEGORY_L2":
                    return Task.FromResult(new[]
                    {
                        new IpgCategoryItemDto { Id = 67864, Value = "Other" },
                        new IpgCategoryItemDto { Id = 67865, Value = "Action" },
                        new IpgCategoryItemDto { Id = 67866, Value = "Adult" },
                        new IpgCategoryItemDto { Id = 67867, Value = "Adventure" },
                        new IpgCategoryItemDto { Id = 67868, Value = "Animation" },
                        new IpgCategoryItemDto { Id = 67869, Value = "Art / Experimental" },
                        new IpgCategoryItemDto { Id = 67870, Value = "Biopics" },
                        new IpgCategoryItemDto { Id = 67871, Value = "Classic / Literature" }
                    });

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
