using healthclinic_webapi.Domains;

namespace healthclinic_webapi.Interfaces
{
    /// <summary>
    /// Interface de perfil
    /// </summary>
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

        /// <summary>
        /// Busca um perfil por email e senha
        /// </summary>
        /// <param name="email">email digitado</param>
        /// <param name="senha">senha digitada</param>
        /// <returns>retorna o perfil buscado</returns>
        Perfil BuscarPorEmailSenha(string email, string senha);
    }
}
