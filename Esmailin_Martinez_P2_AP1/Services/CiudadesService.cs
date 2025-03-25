using System.Linq.Expressions;
using Esmailin_Martinez_P2_AP1.DAL;
using Esmailin_Martinez_P2_AP1.Models;
using Microsoft.EntityFrameworkCore;

namespace Esmailin_Martinez_P2_AP1.Services
{
    public class CiudadesService(IDbContextFactory<Contexto> DbFactory)
    {

        public async Task<List<Ciudades>> Listar(Expression<Func<Ciudades, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Ciudades
                .Where(criterio)
                .AsNoTracking()
                .ToListAsync();
        }
        
    }
}



