using Microsoft.EntityFrameworkCore;
using lab.classes.client;
using lab.classes;

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
        public DBClientContext(DbContextOptions<DBCityContext> options) : base(options)
        {

        }
        #endregion
        #region Get client
        public List<Disabilities> GetDisabilities(string id)
        {
            var dis = m2mDis.Where(m2m => m2m.id == id).Join(Disabilities, 
                m2m => m2m.dis_id, 
                dis => dis.id, 
                (m2m, dis) => new Disabilities { id=dis.id,name=dis.name}).ToList();
            return dis;
        }


        public List<Citizenship> GetCitizenships(string id)
        {
            var citizenship = m2mCitezenship.Where(m2m => m2m.id == id).Join(citizenships,
                m2m => m2m.citizenship_id,
                ctz => ctz.id,
                (m2m, ctz) => new Citizenship { id = ctz.id, nationality = ctz.nationality }).ToList();
            return citizenship;
        }

        public List<FamilyStatus> GetFamilyStatus(string id)
        {
            var status = m2mClients.Where(m2m => m2m.id == id).Join(familyStatuses, 
                m2m => m2m.id_family_status, 
                fms => fms.id, 
                (m2m, fms) => new FamilyStatus { id = fms.id, status_name = fms.status_name }).ToList();
            return status;
        }

        public List<City> GetCitiesOfResidences(string id)
        {
            return m2mResidences.Where(m2m=>m2m.id==id)
                .Join(cities,m2m=>m2m.city_id,cities=>cities.id,(m2m,cities)=> new City {id=cities.id,name=cities.name} ).ToList();
        }

        public List<City> GetCitiesOfLive(string id)
        {
            return m2mLives.Where(m2m => m2m.id == id)
                .Join(cities, m2m => m2m.city_id, cities => cities.id, (m2m, cities) => new City { id = cities.id, name = cities.name }).ToList();
        }

        public async Task<DBClient> GetClientFromDB(string id)
        {
            return await dbClients.FirstAsync(cl => cl.id == id);
        }

        public async Task<Client> GetClient(string id)
        {
            Client client =(Client)await GetClientFromDB(id);
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
                clients.Add((Client)client);
            });

            clients.ForEach(client =>
            {
                client.live = GetCitiesOfLive(client.id);
                client.residence = GetCitiesOfResidences(client.id);
                client.disabilities = GetDisabilities(client.id);
                client.familyStatus = GetFamilyStatus(client.id);
                client.citizenships = GetCitizenships(client.id);
            });
            return clients;
        }
        #endregion 

        #region Add Client

        public async void AddDBClient(DBClient client)
        {
            try
            {
                dbClients.Add(client);
                this.SaveChanges();
            }
            catch (Exception e)
            {

            }
        }

        public async void AddCitiesOfLive(Client client)
        {
            foreach(var city in client.live)
            {
                await m2mLives.AddAsync(new m2m_client_live { city_id = city.id, id = client.id });
            }
            this.SaveChanges();
        }

        public async void AddCitiesOfResidence(Client client)
        {
            foreach (var city in client.residence)
            {
                m2mResidences.Add(new m2m_client_residence {  city_id = city.id, id = client.id });
            }
            this.SaveChanges();
        }

        public async void AddDisabilities(Client client)
        {
            foreach (var dis in client.disabilities)
            {
                m2mDis.Add(new m2m_client_Disabilities { dis_id = dis.id, id = client.id });
            }
            this.SaveChanges();
        }

        public async void AddCitizenships(Client client)
        {
            foreach(var i in client.citizenships)
            {
                m2mCitezenship.Add(new m2m_client_citezenship { citizenship_id = i.id, id = client.id });
            }
            this.SaveChanges();
        }

        public async void AddFamilyStatus(Client client)
        {
            foreach (var i in client.familyStatus)
            {
                m2mClients.Add(new m2m_client_family { id_family_status = i.id, id = client.id });
            }
            this.SaveChanges();
        }

        public async void AddClient(Client client)
        {
            try
            {
                AddDBClient((DBClient)client);
                AddFamilyStatus(client);
                AddCitiesOfLive(client);
                AddCitiesOfResidence(client);
                AddCitizenships(client);
                AddDisabilities(client);
            }
            catch (Exception e)
            {

            }
        }

        #endregion 
    

    }
}
