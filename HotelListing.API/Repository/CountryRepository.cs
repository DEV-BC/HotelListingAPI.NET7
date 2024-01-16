using HotelListing.API.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.API.Repository
{
    public class CountryRepository : GenericRepository<Country>, ICountriesRepository
    {
        private readonly HotelListingDbContext hotelListingDbContext;

        public CountryRepository(HotelListingDbContext hotelListingDbContext) : base(hotelListingDbContext)
        {
            this.hotelListingDbContext = hotelListingDbContext;
        }

        public async Task<Country> GetDetails(int id)
        {
           return await hotelListingDbContext.Countries.Include(x => x.Hotels).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
