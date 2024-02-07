using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using Noleggi.Core.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Noleggi.Core.Configurations;

namespace Noleggi.Core.Services
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<Cliente> Clienti { get; set; }
        public virtual DbSet<Risorsa> Risorse { get; set; }
        public virtual DbSet<Noleggio> Noleggi { get; set; }
        public virtual DbSet<Periodicita> Periodi { get; set; }
        public virtual DbSet<PeriodicitaRisorsa> PeriodicitaRisorse { get; set; }
        public AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string dbName = "DBNoleggio";
                //string path = "F:\\SCHOOL\\Progetti\\Noleggi\\noleggi\\6_Database\\";
                string path = AppDomain.CurrentDomain.BaseDirectory + "../../../../";
                string connection = "Data Source=" + path + dbName + ".db";
                optionsBuilder.UseSqlite(connection);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());

            modelBuilder.ApplyConfiguration(new RisorsaConfiguration());

            modelBuilder.ApplyConfiguration(new PeriodicitaConfiguration());

            modelBuilder.ApplyConfiguration(new PeriodicitaRisorsaConfiguration());

            base.OnModelCreating(modelBuilder);
        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
