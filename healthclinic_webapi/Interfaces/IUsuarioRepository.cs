using healthclinic_webapi.Domains;

namespace healthclinic_webapi.Interfaces
{
    public interface IUsuarioRepository
    {
        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="usuario">Novo usuario</param>
        void Cadastrar(Usuario usuario);

        /// <summary>
        /// Deleta um usuario
        /// </summary>
        /// <param name="id">Id do usuario que sera deletado</param>
        void Deletar(Guid id);
    }
}
