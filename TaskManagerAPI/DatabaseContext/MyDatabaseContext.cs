using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.DataModel;

namespace TaskManagerAPI.DatabaseContext
{
    public class MyDatabaseContext:DbContext
    {
        protected override void OnConfiguring
        (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "TaskDb");
        }



        public DbSet<TodoDataModel> Todos { get; set; }
    }
}
