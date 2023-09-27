using healthclinic_webapi.Contexts;
using healthclinic_webapi.Domains;
using healthclinic_webapi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace healthclinic_webapi.Repositories
{
    /// <summary>
    /// Classe com os metodos de usuario
    /// </summary>
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ClinicContext ctx;

        /// <summary>
        /// Chama a context
        /// </summary>
        public UsuarioRepository()
        {
            ctx = new ClinicContext();
        }

        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="usuario">Novo usuario</param>
        public void Cadastrar(Usuario usuario)
        {
            ctx.Usuario.Add(usuario);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um usuario
        /// </summary>
        /// <param name="id">Id do usuario que sera deletado</param>
        public void Deletar(Guid id)
        {
            ctx.Usuario.Where(u => u.IdUsuario == id)
                .ExecuteDeleteAsync();
        }
    }
}
