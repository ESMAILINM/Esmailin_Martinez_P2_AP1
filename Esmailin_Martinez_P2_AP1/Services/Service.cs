using Esmailin_Martinez_P2_AP1.DAL;
using Microsoft.EntityFrameworkCore;

namespace Esmailin_Martinez_P2_AP1.Services
{
    public class Service(IDbContextFactory<Contexto> DbFactory)
    {
               
    //1.Metodo Guardar
    public async Task<bool> Guardar()
    {
        return true;
    }
    //2.Metodo Existe
    public async Task<bool> Existe()
    {
        return true;
    }
    //3.Insertar
    public async Task<bool> Insertar()
    {
        return false;
    }
    //4.Metodo Modificar
    public async Task<bool> Modificar()
    {
        return true;
    }
       
    public async Task<bool> Buscar(int id)
    {

        return true;
    }
    //6.Eliminar
    public async Task<bool> Eliminar()
    {
        return true;
    }
    //7.Metodo Listar
    public async Task<bool> Listar()
    {
        return true;
    }
 }
}
