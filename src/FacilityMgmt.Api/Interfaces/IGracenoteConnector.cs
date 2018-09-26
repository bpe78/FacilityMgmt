using System;
using System.Threading.Tasks;
using FacilityMgmt.Api.Contracts;

namespace FacilityMgmt.Api.Interfaces
{
    public interface IGracenoteConnector
    {
        Task<GeographicRegionDto[]> GetGeographicRegions();
        Task<CountryDto[]> GetCountries(string geographicRegion);
        Task<TvProviderMetadataDto[]> GetProviders(string geography, string country, string region);
        //Task<TvProviderMetadataDto[]> GetNorthAmericaProviders(string country, string postalCode);
        //Task<TvProviderMetadataDto[]> GetProviders(int tvRegion);
        Task<TvRegionDto[]> GetTvRegions(string country);
        //Task<TvChannelMetadataDto[]> GetTvLineup(string providerId);
        Task<IpgCategoryItemDto[]> GetIpgCategories(string categoryId);
    }
}
