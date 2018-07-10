using System;
using System.Data.Entity;

namespace kaf.dal
{
    // https://msdn.microsoft.com/en-us/data/jj591621 code first migrations
    //Add-Migration migrationStepName
    //Update-Database
    class PubContext : DbContext
    {
        private static PubContext instance;

        public static PubContext getInstance()
        {
           if(instance == null) {
                instance = new PubContext();
            }
            return instance;
        }
        public PubContext(){

        }
        public class SystemInitializer : DropCreateDatabaseIfModelChanges<PubContext>
        {
            protected override void Seed(PubContext context)
            {
                try {
/*                    context.measureUnits.Add(new MeasureUnit() { name = "lit" });
                    context.measureUnits.Add(new MeasureUnit() { name = "kom" });
                    context.measureUnits.Add(new MeasureUnit() { name = "kg" });
                    context.measureUnits.Add(new MeasureUnit() { name = "dan" });
                    context.measureUnits.Add(new MeasureUnit() { name = "por" });
                    context.SaveChanges();*/
                }
                catch (Exception ex) { Console.Error.WriteLine(ex.Message); }
                base.Seed(context);
            }
        }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<MeasureUnit> MeasureUnits { get; set; }
        public DbSet<ItemGroup> ItemGroups { get; set; }
        public DbSet<ItemType> ItemTypes { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Normativ> Normativi { get; set; }
    }
}
