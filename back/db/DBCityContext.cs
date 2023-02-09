using Microsoft.EntityFrameworkCore;
using lab.classes;
using Microsoft.EntityFrameworkCore.Metadata;

namespace lab.db
{
    public class DBCityContext : DbContext 
    {
        public DbSet<City> Cities { get; set; }


        #region Add City

        public async void AddCity(City city)
        {
            try
            {
                Cities.Add(city);
                this.SaveChanges();

            }
            catch (Exception e)
            {

            }

        }

        public async void AddCity(List<City> cities)
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

            }

        }

        #endregion

        #region Delete City

        public async void DeleteCity(City city)
        {
            try
            {
                Cities.Remove(city);
                this.SaveChanges();
            }
            catch (Exception e)
            {

            }
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

        public void UpdateCity(City familyStatus)
        {
            City city = null;
            try
            {
                city = Cities.First(x => x.id == familyStatus.id);

            }
            catch (Exception e)
            {

            }

            if (city != null)
            {
                Cities.Update(familyStatus);
                // SaveChanges should be put in the try catch
                this.SaveChanges();

            }
            else
            {
                throw new Exception();
            }

        }

        #endregion       



    }
}
