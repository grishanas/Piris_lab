using Microsoft.EntityFrameworkCore;
using lab.classes.client;
using lab.classes;
using lab.MyException.DbException;
using System.Text.RegularExpressions;

namespace lab.db
{
    public class DBClientContext: DbContext
    {
        #region
        public DbSet<DBClient> dbClients { get; set; }
        
        public DbSet<FamilyStatus> familyStatuses { get; set; }
        public DbSet<Citizenship> citizenships { get; set; }
        public DbSet<Disabilities> Disabilities { get; set; }
        public DbSet<City> cities { get; set; }

        #endregion

        #region
        private DbSet<m2m_client_family> m2mClients { get; set; }
        private DbSet<m2m_client_citezenship> m2mCitezenship { get; set; }
        private DbSet<m2m_client_Disabilities> m2mDis { get; set; }

        private DbSet<m2m_client_live> m2mLives { get; set; }
        private DbSet<m2m_client_residence> m2mResidences { get; set; }
        #endregion

        #region  constructor
        public DBClientContext() : base()
        {

        }
        public DBClientContext(DbContextOptions<DBClientContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<m2m_client_family>().HasKey(m => new { m.id, m.id_family_status });
            modelBuilder.Entity<m2m_client_citezenship>().HasKey(m => new { m.id, m.citizenship_id });
            modelBuilder.Entity<m2m_client_Disabilities>().HasKey(m => new { m.id, m.dis_id });
            modelBuilder.Entity<m2m_client_live>().HasKey(m => new { m.id, m.city_id });
            modelBuilder.Entity<m2m_client_residence>().HasKey(m => new { m.id, m.city_id });

        }
        #endregion
        #region Get client
        public List<Disabilities>? GetDisabilities(string id)
        {
            var dis = m2mDis.Where(m2m => m2m.id == id).Join(Disabilities, 
                m2m => m2m.dis_id, 
                dis => dis.id, 
                (m2m, dis) => new Disabilities { id=dis.id,name=dis.name}).ToList();
            return dis;
        }


        public List<Citizenship>? GetCitizenships(string id)
        {
            var citizenship = m2mCitezenship.Where(m2m => m2m.id == id).Join(citizenships,
                m2m => m2m.citizenship_id,
                ctz => ctz.id,
                (m2m, ctz) => new Citizenship { id = ctz.id, nationality = ctz.nationality }).ToList();
            return citizenship;
        }

        public List<FamilyStatus>? GetFamilyStatus(string id)
        {
            var status = m2mClients.Where(m2m => m2m.id == id).Join(familyStatuses, 
                m2m => m2m.id_family_status, 
                fms => fms.id, 
                (m2m, fms) => new FamilyStatus { id = fms.id, status_name = fms.status_name }).ToList();
            return status;
        }

        public List<City>? GetCitiesOfResidences(string id)
        {
            return m2mResidences.Where(m2m=>m2m.id==id)
                .Join(cities,m2m=>m2m.city_id,cities=>cities.id,(m2m,cities)=> new City {id=cities.id,name=cities.name} ).ToList();
        }

        public List<City>? GetCitiesOfLive(string id)
        {
            var tmp = m2mLives.Where(m2m => m2m.id == id)
                .Join(cities, m2m => m2m.city_id, cities => cities.id, (m2m, cities) => new City { id = cities.id, name = cities.name }).ToList();
            return tmp;
        }

        public async Task<DBClient> GetClientFromDB(string id)
        {
            return await dbClients.FirstAsync(cl => cl.id == id);
        }

        public async Task<Client> GetClient(string id)
        {
            Client client = new Client(await GetClientFromDB(id));
            client.live = GetCitiesOfLive(id);
            client.residence = GetCitiesOfResidences(id);
            client.disabilities = GetDisabilities(id);
            client.familyStatus = GetFamilyStatus(id);
            client.citizenships = GetCitizenships(id);
            return client;
        }

        public async Task<List<Client>> GetClients()
        {
            List<Client> clients = new List<Client>();
            dbClients.ToList().ForEach(client =>
            {
                Client client1 = new Client(client);
                clients.Add(client1);
            });

           clients.ForEach(client =>
           {
               client.familyStatus = GetFamilyStatus(client.id);
               client.live = GetCitiesOfLive(client.id);
                client.residence = GetCitiesOfResidences(client.id);
                client.disabilities = GetDisabilities(client.id);
                client.citizenships = GetCitizenships(client.id);
            });
            return clients;
        }
        #endregion 

        #region Add Client

        public async void AddDBClient(DBClient client)
        {
            if(client == null)
                throw new ArgumentNullException("client");
            if ((client.id == null) || (client.id.Length != 11))
                throw new InappropriateFormatException("client.id", "Length != 11");
            if ((client.first_name == null) || (client.first_name.Length <= 0)||(client.first_name.Length>50))
                throw new InappropriateFormatException("client.first_name", "wrong lentgh");
            else
            {
                var reg = new Regex(@"[a-zA-zа-яА-я-]");
                if (!reg.IsMatch(client.first_name))
                    throw new InappropriateFormatException("client.first_name", "invalid character");
                if (!reg.IsMatch(client.second_name))
                    throw new InappropriateFormatException("client.second_name", "invalid character");
                if (!reg.IsMatch(client.midle_name))
                    throw new InappropriateFormatException("client.midle_name", "invalid character");
            }
            if (client.passport_series.Length != 2)
                throw new InappropriateFormatException("client.passport_series","wrong length");
            

            if (dbClients.FirstAsync(x=>x.passport_series==client.passport_series && x.passport_number==client.passport_number)!=null)
            {
                throw new DublicateException("dublicate client pasport series and pasport number","client pasport");
            }
            






            dbClients.Add(client);
            try
            {
                this.SaveChanges();
            }
            catch (Exception e)
            {

            }
        }

        public async Task<bool> AddCitiesOfLive(m2m_client_live client)
        {
            m2mLives.Add(client);

            try
            {
                this.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
            return true;
        }

        public async Task<bool> AddCitiesOfResidence(m2m_client_residence client)
        {
            m2mResidences.Add(client);

            try
            {
                this.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
            return true;
        }

        public async Task<bool> AddDisabilities(m2m_client_Disabilities client)
        {

            m2mDis.Add(client);

            try
            {
                this.SaveChanges();
            }catch(Exception e)
            {
                throw;
            }
            return true;

            
        }

        public async Task<bool> AddCitizenships(m2m_client_citezenship client)
        {
            m2mCitezenship.Add(client);

            try
            {
                this.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
            return true;
        }

        public async Task<bool> AddFamilyStatus(m2m_client_family client)
        {
            m2mClients.Add(client);

            try
            {
                this.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
            return true;
        }

        public async Task<bool> AddClient(DBClient client)
        {
            AddDBClient(client);
            try
            {
                this.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
            return true;
        }

        #endregion

        #region Delete Client

        public async Task<bool> DeleteM2MClientResidences(string id)
        {
            var client= m2mResidences.Where(x => x.id == id).ToList();
            if (client == null)
                throw new NotExistException("","");
            client.ForEach(i =>
            {
                m2mResidences.Remove(i);
            });
            try
            {
                this.SaveChanges();
            }catch(Exception e)
            {
                throw;
            }
            return true;
        }
        public async Task<bool> DeleteM2MLives(string id)
        {
            var client = m2mLives.Where(x => x.id == id).ToList();
            if (client == null)
                throw new NotExistException("", "");
            client.ForEach(i =>
            {
                m2mLives.Remove(i);
            });
            try
            {
                this.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
            return true;
        }

        public async Task<bool> DeleteM2MDiss(string id)
        {
            var client = m2mDis.Where(x => x.id == id).ToList();
            if (client == null)
                throw new NotExistException("", "");
            client.ForEach(i =>
            {
                m2mDis.Remove(i);
            });
            try
            {
                this.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
            return true;
        }

        public async Task<bool> DeleteM2MCitezenships(string id)
        {
            var client = m2mCitezenship.Where(x => x.id == id).ToList();
            if (client == null)
                throw new NotExistException("", "");
            client.ForEach(i =>
            {
                m2mCitezenship.Remove(i);
            });
            try
            {
                this.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
            return true;
        }
        public async Task<bool> DeleteM2MClients(string id)
        {
            var client = m2mClients.Where(x => x.id == id).ToList();
            if (client == null)
                throw new NotExistException("", "");
            client.ForEach(i =>
            {
                m2mClients.Remove(i);
            });
            try
            {
                this.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
            return true;
        }


        private async Task<bool> DeleteDBClient(string id)
        {
            var client = await dbClients.FirstAsync(x => x.id == id);
            if (client == null)
                throw new NotExistException("client don't exist", @"id={id}");
            dbClients.Remove(client);
            try
            {
                this.SaveChanges();
            }catch(Exception e)
            {
                throw;
            }
            return true;
        }
        public async Task<bool> DeleteClient(string id)
        {
            DeleteDBClient(id);
            return true;
        }
        #endregion

        #region Delete Client information
        public async Task<bool> Deletem2mClientResidence(m2m_client_residence m2M_Client_Residence)
        {
            m2mResidences.Remove(m2M_Client_Residence);
            try
            {
                this.SaveChanges();
            }catch(Exception e)
            {
                throw new NotExistException("", "");
            }
            return true;
        }

        public async Task<bool> Deletem2mLives(m2m_client_live m2M_client_live)
        {
            m2mLives.Remove(m2M_client_live);
            try
            {
                this.SaveChanges();
            }
            catch (Exception e)
            {
                throw new NotExistException("","");
            }
            return true;
        }

        public async Task<bool> Deletem2mDis(m2m_client_Disabilities x)
        {
            m2mDis.Remove(x);
            try
            {
                this.SaveChanges();
            }
            catch (Exception e)
            {
                throw new NotExistException("", "");
            }
            return true;
        }


        public async Task<bool> Deletem2mCitezenship(m2m_client_citezenship x)
        {
            m2mCitezenship.Remove(x);
            try
            {
                this.SaveChanges();
            }
            catch (Exception e)
            {
                throw new NotExistException("", "");
            }
            return true;
        }


        public async Task<bool> Deletem2mClients(m2m_client_family x)
        {
            m2mClients.Remove(x);
            try
            {
                this.SaveChanges();
            }
            catch (Exception e)
            {
                throw new NotExistException("", "");
            }
            return true;
        }


        #endregion

        #region Update Client
        public async Task<bool> UpdateClient(DBClient Client)
        {
            var client = await dbClients.FirstAsync(x=>x.id== Client.id);
            if(client == null)
                throw new NotExistException("client don't exisy", @"id={id}");

            client.first_name = Client.first_name;
            client.second_name = Client.second_name;
            client.midle_name = Client.midle_name;
            client.birthday = Client.birthday;
            client.sex = Client.sex;
            client.passport_series = Client.passport_series;
            client.passport_number = Client.passport_number;
            client.authority = Client.authority;
            client.date_of_issue = Client.date_of_issue;
            client.place_of_birth = Client.place_of_birth;
            client.mobile_phone = Client.mobile_phone;
            client.home_phone = Client.home_phone;
            client.e_mail = Client.e_mail;
            client.work_place = Client.work_place;
            client.work_position = Client.work_position;
            client.address_of_registration = Client.address_of_registration;
            client.retired = Client.retired;
            client.monthly_income = Client.monthly_income;
            client.military_conscription = Client.military_conscription;

            dbClients.Update(client);
            try
            {
                this.SaveChanges();

            }catch(Exception e)
            {
                throw;
            }
            return true;
        }
        #endregion

    }
}
