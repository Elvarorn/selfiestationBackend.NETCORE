using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using SelfieStationApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace SelfieStation.Repositories.data
{
    public class databaseContext : DbContext
    {

        public DbSet<imageInfoEntity> imageInfo { get; set; }

        public databaseContext(DbContextOptions<databaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<imageInfoEntity>().HasKey(t => t.ID);

        }


    }
}