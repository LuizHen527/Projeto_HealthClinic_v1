using healthclinic_webapi.Domains;

namespace healthclinic_webapi.Interfaces
{
    /// <summary>
    /// Interface de feedback
    /// </summary>
    public interface IFeedbackRepository
    {

        /// <summary>
        /// Cadastra novo feedback
        /// </summary>
        /// <param name="feedback">Novo feedback</param>
        void Cadastrar(Feedback feedback);

        /// <summary>
        /// Deleta um feedback
        /// </summary>
        /// <param name="id">Id do feedback que sera deletado</param>
        void Deletar(Guid id);

        /// <summary>
        /// Atualiza um feedback
        /// </summary>
        /// <param name="id">Id do feedback que sera atualizado</param>
        /// <param name="feedback">Novos dados</param>
        void Atualizar(Guid id, Feedback feedback);
    }
}
