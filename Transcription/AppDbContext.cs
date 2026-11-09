using Microsoft.EntityFrameworkCore;
using Transcription.Models;

namespace Transcription
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<TranscriptionRequest> TranscriptionRequests { get; set; }
        public DbSet<GlossaryRequest> GlossaryRequests { get; set; }
    }
}