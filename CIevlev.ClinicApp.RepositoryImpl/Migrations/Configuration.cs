
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace CIevlev.ClinicApp.RepositoryImpl.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<CIevlev.ClinicApp.RepositoryImpl.ClinicAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
    } 
}