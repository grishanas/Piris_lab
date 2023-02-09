using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using lab.classes;

namespace lab.db
{
    public class DBDisabilitiesContext:DbContext
    {
        DbSet<Disabilities> Disabilities { get; set; }

        #region Add Disabilities

        public async void AddDisability(Disabilities disability)
        {
            try
            {
                Disabilities.Add(disability);
                this.SaveChanges();
            }catch(Exception e)
            {

            }

        }
        #endregion

        #region Get Disability

        public async Task<Disabilities> GetDisability(int id)
        {
            Disabilities disabilities = await Disabilities.FindAsync(id);
            if (disabilities == null)
                throw new Exception();
            else
                return disabilities;
        }

        public async Task<List<Disabilities>> GetDisabilities()
        {
            var disabilities= await Disabilities.ToListAsync();
            if (disabilities == null)
                throw new Exception();
            else
                return disabilities;
        }
        #endregion

        #region Delete disability

        public async void DeleteDisability(Disabilities disability)
        {
            try
            {
                var delete = Disabilities.Remove(disability);
                this.SaveChanges();

            }catch(Exception e)
            {

            }
        }
        #endregion

        #region Update Disability
        public async void UpdateDisability(Disabilities disability)
        {
            try
            {
                Disabilities.Update(disability);
                SaveChanges();
            }catch(Exception e)
            {

            }
        }
        #endregion
    }
}
