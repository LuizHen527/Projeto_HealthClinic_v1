using healthclinic_webapi.Contexts;
using healthclinic_webapi.Domains;
using healthclinic_webapi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace healthclinic_webapi.Repositories
{
    public class TiposUsuarioRepository : ITiposUsuarioRepository 
    {
        public ClinicContext ctx;

        public TiposUsuarioRepository()
        {
            ctx = new ClinicContext();
        }

        /// <summary>
        /// Cadastra um tipo de usuario
        /// </summary>
        /// <param name="tiposUsuario">Novo tipo de usuario</param>
        public void Cadastrar(TiposUsuario tiposUsuario)
        {
            ctx.TiposUsuario.Add(tiposUsuario);
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um tipo de usuario
        /// </summary>
        /// <param name="id">Id do tipo de usuario</param>
        public void Deletar(Guid id)
        {
            ctx.TiposUsuario.Where(t => t.IdTiposUsuario == id)
                .ExecuteDeleteAsync();
        }
    }
}
