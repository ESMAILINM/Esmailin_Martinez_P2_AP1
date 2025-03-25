using Esmailin_Martinez_P2_AP1.DAL;
using Esmailin_Martinez_P2_AP1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Esmailin_Martinez_P2_AP1.Services
{
    public class EncuestaService(IDbContextFactory<Contexto> DbFactory)
    {
        public async Task<bool> Existe(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Encuesta.AnyAsync(c => c.EncuestaId == id);
        }

        private async Task<bool> Insertar(Encuesta encuesta)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();

            // Agregar la encuesta
            contexto.Encuesta.Add(encuesta);

            // Asegurarse de que las ciudades no se inserten, solo se referencien
            foreach (var detalle in encuesta.Detalle)
            {
                if (detalle.Ciudades != null && detalle.Ciudades.CiudadId > 0)
                {
                    contexto.Entry(detalle.Ciudades).State = EntityState.Unchanged;
                }
                else if (detalle.CiudadId <= 0)
                {
                    throw new InvalidOperationException($"El CiudadId {detalle.CiudadId} no es válido para el detalle.");
                }
            }
            await AfectarMontoCiudad(encuesta.Detalle, true);
            return await contexto.SaveChangesAsync() > 0;

        }

        private async Task<bool> Modificar(Encuesta encuesta)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();

            // Actualizar la encuesta
            contexto.Entry(encuesta).State = EntityState.Modified;

            // Manejar los detalles
            foreach (var detalle in encuesta.Detalle)
            {
                if (detalle.DestallesId == 0) // Nuevo detalle
                {
                    contexto.Entry(detalle).State = EntityState.Added;
                }
                else // Detalle existente
                {
                    contexto.Entry(detalle).State = EntityState.Modified;
                }

                // Verificar que CiudadId sea válido
                if (detalle.CiudadId <= 0)
                {
                    throw new InvalidOperationException($"El CiudadId {detalle.CiudadId} no es válido para el detalle.");
                }

                // Si hay una propiedad Ciudad, marcarla como no modificada
                if (detalle.Ciudades != null && detalle.Ciudades.CiudadId > 0)
                {
                    contexto.Entry(detalle.Ciudades).State = EntityState.Unchanged;
                }
            }

            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(Encuesta encuesta)
        {
            if (!await Existe(encuesta.EncuestaId))
                return await Insertar(encuesta);
            else
                return await Modificar(encuesta);
        }

        public async Task Eliminar(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            var encuesta = await contexto.Encuesta.FindAsync(id);
            if (encuesta != null)
            {
                await AfectarMontoCiudad(encuesta.Detalle, false);
                contexto.Encuesta.Remove(encuesta);
                await contexto.SaveChangesAsync();
            }
        }
        public async Task EliminarDetalle(int detalleId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            var detalle = await contexto.Detalle.FindAsync(detalleId);
            if (detalle != null)
            {
                contexto.Detalle.Remove(detalle);
                await contexto.SaveChangesAsync();
                
            }
        }

        public async Task<Encuesta?> Buscar(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Encuesta
                .Include(e => e.Detalle)
                .AsNoTracking()
                .FirstOrDefaultAsync(i => i.EncuestaId == id);
        }

        public async Task<List<Encuesta>> Listar(Expression<Func<Encuesta, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Encuesta
                .Include(e => e.Detalle)
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
        private async Task AfectarMontoCiudad(IEnumerable<Detalle> detalles, bool suma)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            foreach (var detalle in detalles)
            {
                var ciudad = await contexto.Ciudades.FindAsync(detalle.CiudadId);
                if (ciudad != null)
                {
                    ciudad.Monto += suma ? detalle.MontoEncuesta : -detalle.MontoEncuesta;
                }
            }
            await contexto.SaveChangesAsync();
        }
    }
}

