using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using lab.db;
using lab.TransactionController;

namespace lab
{ 
    class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Configuration.AddJsonFile("appsettings.Development.json");
            var services = new ServiceCollection();

            // Add services to the container.

            builder.Services.AddDbContext<DBCityContext>(optoins => optoins.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));
            builder.Services.AddDbContext<DBClientContext>(optoins => optoins.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));
            builder.Services.AddDbContext<DBDisabilitiesContext>(optoins => optoins.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));
            builder.Services.AddDbContext<DBFamilyStatusContext>(optoins => optoins.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));
            builder.Services.AddDbContext<DBAccountCodeContext>(optoins => optoins.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));
            builder.Services.AddDbContext<DBCitezenshipContext>(optoins => optoins.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));

            builder.Services.AddDbContext<DBAccountContext>(optoins => optoins.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));
            builder.Services.AddDbContext<DBAccountTypeContext>(optoins => optoins.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));
            builder.Services.AddDbContext<DBBalanceContext>(optoins => optoins.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));
            builder.Services.AddDbContext<DBCreditContext>(optoins => optoins.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));
            builder.Services.AddDbContext<DBDebitContext>(optoins => optoins.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));


            builder.Services.AddTransient<AccountTransactionController>();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}

