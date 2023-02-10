using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using lab.classes;

namespace lab.db
{
    public class DBFamilyStatusContext: DbContext
    {
        public DbSet<FamilyStatus> familyStatuses { get; set; }


        public DBFamilyStatusContext() : base()
        {

        }
        public DBFamilyStatusContext(DbContextOptions<DBFamilyStatusContext> options) : base(options)
        {

        }

        #region Add Family status

        public async Task<bool> AddFamilyStatus(FamilyStatus familyStatus)
        {

            if (familyStatus == null)
                throw new ArgumentNullException(nameof(familyStatus));
            if (familyStatus.id == null)
                throw new ArgumentNullException(nameof(familyStatus));

            familyStatuses.Add(familyStatus);
            try
            {
                this.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
               //throw ; //new Exception(ex.Message);
            }
            catch (DbUpdateException ex)
            {
                
                throw new Exception(ex.InnerException.HResult.ToString()); //new Exception(ex.Message);*/
            }
            catch { }

            return true;

        }

        public async Task<bool> AddFamilyStatuses(List<FamilyStatus> FamilyStatuses)
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
            return true;

        }

        #endregion

        #region Delete Family Status

        public async Task<bool> DeleteFamilyStatus(FamilyStatus familyStatus)
        {
            try
            {
                familyStatuses.Remove(familyStatus);
                this.SaveChanges();
            }
            catch (Exception e)
            {

            }
            return true;
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

        public async Task<bool> UpdateFamilyStatus( FamilyStatus familyStatus)
        {
            FamilyStatus family=null;
            try
            {
                family = familyStatuses.FirstOrDefault(x => x.id  == familyStatus.id);

            }catch(Exception e)
            {

            }

            if(family!=null)
            {
                family.status_name=familyStatus.status_name;

                familyStatuses.Update(family);
                // SaveChanges should be put in the try catch
                this.SaveChanges();

            }
            else
            {
                throw new Exception();
            }

            return true;
        }

        #endregion

    }

}
