using HotelListing.API.Data;

namespace HotelListing.API.Repository
{
    public interface ICountriesRepository : IGenericRepository<Country>
    {
        Task<Country> GetDetails(int id);
    }
}
