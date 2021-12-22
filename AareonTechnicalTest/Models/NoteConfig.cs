using Microsoft.EntityFrameworkCore;

namespace AareonTechnicalTest.Models
{
    public static class NoteConfig
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>(
                entity =>
                {
                    entity.HasKey(e => e.Id);

                    entity.HasOne<Ticket>()
                        .WithMany(t => t.Notes)
                        .HasForeignKey(n => n.TicketId)
                        .OnDelete(DeleteBehavior.ClientCascade);

                    entity.HasOne<Person>()
                        .WithMany()
                        .HasForeignKey(n => n.PersonId)
                        .OnDelete(DeleteBehavior.ClientCascade);
                });
        }
    }
}