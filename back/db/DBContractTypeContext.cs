using Microsoft.EntityFrameworkCore;
using lab.classes;
using Microsoft.EntityFrameworkCore.Metadata;

namespace lab.db
{
    public class DBContractTypeContext:DbContext
    {
        public DbSet<contract_type> _context { get; }

        public DBContractTypeContext() : base()
        {

        }
        public DBContractTypeContext(DbContextOptions<DBContractTypeContext> options) : base(options)
        {

        }


        public async Task<bool> AddContractType(contract_type contract)
        {
            if(await _context.FindAsync(x => x.id == contract.id)!=null)
            {
                throw new Exception();
            }
            _context.Add(contract);
            try
            {
                this.SaveChanges();
            }catch(Exception e)
            {
                throw;
            }
            return true;
        }

        public async Task<List<contract_type>> GetContractTypes()
        {
            try
            {
                return _context.ToList();
            }catch(Exception e)
            {
                throw new Exception();
            }
        }

        public async Task<bool> DeleteContractType(int id)
        {
            var item = await _context.FindAsync(x => x.id == id);
            if (item ==null)
            {
                throw new Exception();
            }
            await _context.Remove(item);

            try
            {
                this.SaveChanges();
            }catch(Exception e)
            {
                throw;
            }
            return true;
        }

    }
}
