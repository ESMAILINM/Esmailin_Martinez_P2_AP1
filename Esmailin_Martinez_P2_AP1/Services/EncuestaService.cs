using Esmailin_Martinez_P2_AP1.DAL;
using Esmailin_Martinez_P2_AP1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Esmailin_Martinez_P2_AP1.Services
{
        public class EncuestaService(IDbContextFactory<Contexto> DbFactory)
        {

            //1.Metodo Guardar
            public async Task<bool> Guardar(Encuesta encuesta)
            {
                if (!await Existe(encuesta.EncuestaId))
                {
                    return await Insertar(encuesta);
                }
                else
                {
                    return await Modificar(encuesta);
                }
            }

            //2.Metodo Existe
            public async Task<bool> Existe(int Id)
            {
                await using var contexto = await DbFactory.CreateDbContextAsync();
                return await contexto.Encuesta
                    .AnyAsync(E => E.EncuestaId == Id);
            }

            //3.Insertar
            public async Task<bool> Insertar(Encuesta encuesta)
            {
                await using var contexto = await DbFactory.CreateDbContextAsync();
                contexto.Encuesta.Add(encuesta);
                return await contexto.SaveChangesAsync() > 0;
            }

            //4.Metodo Modificar
            public async Task<bool> Modificar(Encuesta encuesta)
            {
                await using var contexto = await DbFactory.CreateDbContextAsync();
                contexto.Update(encuesta);
                return await contexto
                    .SaveChangesAsync() > 0;
            }

            //5.Buscar
            public async Task<Encuesta?> Buscar(int id)
            {
                await using var contexto = await DbFactory.CreateDbContextAsync();
                return await contexto.Encuesta
                    .FirstOrDefaultAsync(e => e.EncuestaId == id);
            }

            //6.Eliminar
            public async Task<bool> Eliminar(int id)
            {
                await using var contexto = await DbFactory.CreateDbContextAsync();
                return await contexto.Encuesta
                    .Where(e => e.EncuestaId == id)
                    .ExecuteDeleteAsync() > 0;
            }

            //7.Metodo Listar
            public async Task<List<Encuesta>> Listar(Expression<Func<Encuesta, bool>> criterio)
            {
                await using var contexto = await DbFactory.CreateDbContextAsync();
                return await contexto.Encuesta
                    .Where(criterio)
                    .ToListAsync();
            }
        }
    }

