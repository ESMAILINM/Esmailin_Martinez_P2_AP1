using System.Linq.Expressions;
using Esmailin_Martinez_P2_AP1.DAL;
using Esmailin_Martinez_P2_AP1.Models;
using Microsoft.EntityFrameworkCore;

namespace Esmailin_Martinez_P2_AP1.Services
{
    public class CiudadesService(IDbContextFactory<Contexto> DbFactory)
    {

        //1.Metodo Guardar
        public async Task<bool> Guardar(Ciudades ciudad)
        {

            if (!await Existe(ciudad.CiudadId))
            {
                return await Insertar(ciudad);
            }
            else
            {
                return await Modificar(ciudad);
            }
        }
        //2.Metodo Existe
        public async Task<bool> Existe(int Id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Ciudades
                .AnyAsync(T => T.CiudadId == Id);
        }
        //3.Insertar
        public async Task<bool> Insertar(Ciudades ciudades)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Ciudades.Add(ciudades);
            return await contexto.SaveChangesAsync() > 0;
        }
        //4.Metodo Modificar
        public async Task<bool> Modificar(Ciudades ciudades)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Update(ciudades);
            return await contexto
                .SaveChangesAsync() > 0;
        }
        //5.Buscar
        public async Task<Ciudades?> Buscar(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Ciudades
                .FirstOrDefaultAsync(c => c.CiudadId == id);

        }
        //6.Eliminar
        public async Task<bool> Eliminar(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Ciudades
                .Where(c => c.CiudadId == id)
                .ExecuteDeleteAsync() > 0;
        }
        //7.Metodo Listar
        public async Task<List<Ciudades>> Listar(Expression<Func<Ciudades, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Ciudades
                .Where(criterio)
                .ToListAsync();
        }
    }
}



