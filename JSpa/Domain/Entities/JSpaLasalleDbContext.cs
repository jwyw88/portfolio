using System.Data.Entity;

namespace Domain.Entities
{
    public class JSpaLasalleDbContext : DbContext
    {
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<PersonelByKathy.Models.PersonelByKathyContext>());

        public JSpaLasalleDbContext() : base("name=JSpaLasalleDbContext")
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
