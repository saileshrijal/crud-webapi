using CandidateApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CandidateApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Candidate>? Candidates { get; set; }
    }
}