using healthclinic_webapi.Domains;

namespace healthclinic_webapi.Interfaces
{
    /// <summary>
    /// Interface de prontuario
    /// </summary>
    public interface IProntuarioRepository
    {

        /// <summary>
        /// Cadastra um novo prontuario
        /// </summary>
        /// <param name="prontuario">Novo prontuario</param>
        void Cadastrar(Prontuario prontuario);

        /// <summary>
        /// Deleta um prontuario
        /// </summary>
        /// <param name="id">Id do prontuario que sera deletado</param>
        void Deletar(Guid id);

        /// <summary>
        /// Atualiza um prontuario
        /// </summary>
        /// <param name="id">Id do prontuario que sera atualizado</param>
        /// <param name="prontuario">Novos dados de prontuario</param>
        void Atualizar(Guid id, Prontuario prontuario);
    }
}
