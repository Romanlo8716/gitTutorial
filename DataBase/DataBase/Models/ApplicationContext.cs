using Microsoft.EntityFrameworkCore;

namespace DataBase.Models
{
    public class ApplicationContext : DbContext //класс контекст
    {
        public DbSet<User> Users { get; set; } //Свойство DbSet представляет собой коллекцию объектов, которая сопоставляется с определенной таблицей в базе данных.
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) //options - настройки контекста
        {
            Database.EnsureCreated(); // создаем базу данных при первом обращении
        }
    }
}
