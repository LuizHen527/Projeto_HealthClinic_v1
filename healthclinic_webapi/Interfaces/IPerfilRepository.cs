using healthclinic_webapi.Domains;

namespace healthclinic_webapi.Interfaces
{
    public interface IPerfilRepository
    {
        /// <summary>
        /// Cadastra um novo perfil
        /// </summary>
        /// <param name="perfil">Novo perfil</param>
        void Cadastrar(Perfil perfil);

        /// <summary>
        /// Deleta um perfil
        /// </summary>
        /// <param name="id">Id do perfil que sera deletado</param>
        void Deletar(Guid id);

        /// <summary>
        /// Atualiza um perfil
        /// </summary>
        /// <param name="id">Id do perfil que sera atualizado</param>
        /// <param name="perfil">Novos dados de perfil</param>
        void Atualizar(Guid id, Perfil perfil);
    }
}
