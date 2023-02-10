using Microsoft.EntityFrameworkCore;
using lab.classes;
using Microsoft.EntityFrameworkCore.Metadata;

namespace lab.db
{
    public class DBCityContext : DbContext 
    {
        public DbSet<City> Cities { get; set; }
        public DBCityContext() : base()
        {

        }
        public DBCityContext(DbContextOptions<DBCityContext> options) : base(options)
        {

        }


        #region Add City

        public async Task<bool> AddCity(City city)
        {
            try
            {
                Cities.Add(city);
                this.SaveChanges();

            }
            catch (Exception e)
            {
                throw;
            }
            return true;

        }

        public async Task<bool> AddCity(List<City> cities)
        {
            try
            {
                foreach (var i in cities)
                {
                    Cities.Add(i);
                }
                this.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
            return true;

        }

        #endregion

        #region Delete City

        public async Task<bool> DeleteCity(City city)
        {
            try
            {
                Cities.Remove(city);
                this.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
            return true;
        }
        #endregion


        #region Get Family Status

        public async Task<List<City>> GetCities()
        {
            return await Cities.ToListAsync();
        }

        public async Task<City> GetCity(int id)
        {
            return await Cities.FirstAsync(x => x.id == id);
        }

        #endregion

        #region Update City

        public async Task<bool> UpdateCity(City familyStatus)
        {


            try
            {
                Cities.Update(familyStatus);
                // SaveChanges should be put in the try catch
                this.SaveChanges();

            }
            catch(Exception e)
            {
                throw;
            }
            return true;
        }

        #endregion       



    }
}
