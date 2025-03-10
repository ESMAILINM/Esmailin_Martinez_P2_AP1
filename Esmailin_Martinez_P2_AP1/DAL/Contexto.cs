using Esmailin_Martinez_P2_AP1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Esmailin_Martinez_P2_AP1.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Modelo> Modelo { get; set; }
    }
}
