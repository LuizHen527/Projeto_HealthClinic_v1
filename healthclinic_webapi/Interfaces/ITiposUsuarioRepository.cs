using healthclinic_webapi.Domains;

namespace healthclinic_webapi.Interfaces
{
    public interface ITiposUsuarioRepository
    {
        /// <summary>
        /// Cadastra um tipo de usuario
        /// </summary>
        /// <param name="tiposUsuario">Novo tipo de usuario</param>
        void Cadastrar(TiposUsuario tiposUsuario);

        /// <summary>
        /// Deleta um tipo de usuario
        /// </summary>
        /// <param name="id">Id do tipo de usuario</param>
        void Deletar(Guid id);
    }
}
