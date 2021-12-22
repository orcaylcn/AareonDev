using AareonTechnicalTest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AareonTechnicalTest
{
    public class ApplicationContext : DbContext
    {
        private readonly ILogger<ApplicationContext> _logger;

        public ApplicationContext(
            DbContextOptions<ApplicationContext> options,
            ILogger<ApplicationContext> logger)
                : base(options)
        {
            _logger = logger;

            var envDir = Environment.CurrentDirectory;

            DatabasePath = $"{envDir}{System.IO.Path.DirectorySeparatorChar}Ticketing.db";
        }

        public virtual DbSet<Person> Persons { get; set; }

        public virtual DbSet<Ticket> Tickets { get; set; }

        public virtual DbSet<Note> Notes { get; set; }

        public string DatabasePath { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={DatabasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            PersonConfig.Configure(modelBuilder);
            TicketConfig.Configure(modelBuilder);
            NoteConfig.Configure(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            ChangeTracker.DetectChanges();
            _logger.LogInformation(ChangeTracker.DebugView.LongView);
            return await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
