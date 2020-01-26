using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using SIevlev.ClinicApp.Models;

namespace CIevlev.ClinicApp.RepositoryImpl
{
    public class ClinicAppContext :DbContext
    {
        public ClinicAppContext() :base("ClinicApp")
        {
        }
        
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDoctor> OrderDoctors { get; set; }
        public DbSet<PayStory> PayStories { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}