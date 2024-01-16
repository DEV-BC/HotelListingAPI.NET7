
using HotelListing.API.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.API.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly HotelListingDbContext hotelListingDbContext;

        public GenericRepository(HotelListingDbContext hotelListingDbContext)
        {
            this.hotelListingDbContext = hotelListingDbContext;
        }
        public async Task<T> AddAsync(T entity)
        {
            await hotelListingDbContext.AddAsync(entity);
            await hotelListingDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetAsync(id);
            hotelListingDbContext.Set<T>().Remove(entity);
            await hotelListingDbContext.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            var entity = await GetAsync(id);
            return entity != null;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await hotelListingDbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(int? id)
        {
            if (id == null)
            {
                return null;
            }

            return await hotelListingDbContext.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            hotelListingDbContext.Update(entity);
            await hotelListingDbContext.SaveChangesAsync();
        }
    }
}
