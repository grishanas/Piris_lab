using Microsoft.EntityFrameworkCore;
using lab.classes;
using Microsoft.EntityFrameworkCore.Metadata;

namespace lab.db
{
    public class DBContractContext:DbContext
    {
        public DbSet<ClientContract> _context { get; }

        public DBContractContext() : base()
        {

        }
        public DBContractContext(DbContextOptions<DBContractContext> options) : base(options)
        {

        }
    }
}
