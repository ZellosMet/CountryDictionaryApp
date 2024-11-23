using CountryDictionaryApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace CountryDictionaryApp.Services
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        // Настройка модели базы DBContext
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {  
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            string useConnection = configuration.GetSection("UseDbConnection").Value ?? "DefaultConnection";
            optionsBuilder.UseNpgsql(configuration.GetConnectionString(useConnection));
        }

        // Инициализация базы данных начальными данными
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Country>().HasData
                (
                    new Country { Id = 1, Name = "Россия", ISO31661Alpha2Code = "ru", ISO31661Alpha3Code = "rus", ISO31661NumericCode = "643" },
                    new Country { Id = 2, Name = "Соединённые Штаты Америки", ISO31661Alpha2Code = "us", ISO31661Alpha3Code = "usa", ISO31661NumericCode = "840" },
                    new Country { Id = 3, Name = "Китай", ISO31661Alpha2Code = "cn", ISO31661Alpha3Code = "chn", ISO31661NumericCode = "156" }
                );
        }
    }
}
