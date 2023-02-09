using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using lab.classes;

namespace lab.db
{
    public class DBFamilyStatusContext: DbContext
    {
        public DbSet<FamilyStatus> familyStatuses { get; set; }


        #region Add Family status

        public async void AddFamilyStatus(FamilyStatus familyStatus)
        {
            try
            {
                familyStatuses.Add(familyStatus);
                this.SaveChanges();

            }
            catch(Exception e)
            {

            }

        }

        public async void AddFamilyStatuses(List<FamilyStatus> FamilyStatuses)
        {
            try
            {
                foreach(var i in FamilyStatuses)
                {
                    familyStatuses.Add(i);
                }
                this.SaveChanges();
            }
            catch (Exception e)
            {

            }

        }

        #endregion

        #region Delete Family Status

        public async void DeleteFamilyStatus(FamilyStatus familyStatus)
        {
            try
            {
                familyStatuses.Remove(familyStatus);
                this.SaveChanges();
            }
            catch (Exception e)
            {

            }
        }
        #endregion


        #region Get Family Status

        public async Task<List<FamilyStatus>> GetFamilyStatuses()
        {
            return await familyStatuses.ToListAsync();
        }

        public async Task<FamilyStatus> GetFamilyStatus(int id)
        {
            return await familyStatuses.FirstAsync(x => x.id == id);
        }

        #endregion

        #region Update Family Status

        public void UpdateFamilyStatus( FamilyStatus familyStatus)
        {
            FamilyStatus family=null;
            try
            {
                family = familyStatuses.First(x => x.id  == familyStatus.id);

            }catch(Exception e)
            {

            }

            if (family != null)
            {
                familyStatuses.Update(familyStatus);
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
