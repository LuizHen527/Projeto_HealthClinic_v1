using healthclinic_webapi.Contexts;
using healthclinic_webapi.Domains;
using healthclinic_webapi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace healthclinic_webapi.Repositories
{
    /// <summary>
    /// Classe com metodos de feedback
    /// </summary>
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly ClinicContext ctx;

        /// <summary>
        /// Chama o contexto
        /// </summary>
        public FeedbackRepository()
        {
            ctx = new ClinicContext();
        }

        /// <summary>
        /// Atualiza um feedback
        /// </summary>
        /// <param name="id">Id do feedback que sera atualizado</param>
        /// <param name="feedback">Novos dados</param>
        public void Atualizar(Guid id, Feedback feedback)
        {
            ctx.Feedback.Where(f => f.IdFeedback == id)
                .ExecuteUpdateAsync(updates =>
                    updates.SetProperty(f => f.Comentario, feedback.Comentario));
        }

        /// <summary>
        /// Cadastra novo feedback
        /// </summary>
        /// <param name="feedback">Novo feedback</param>
        public void Cadastrar(Feedback feedback)
        {
            ctx.Feedback.Add(feedback);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um feedback
        /// </summary>
        /// <param name="id">Id do feedback que sera deletado</param>
        public void Deletar(Guid id)
        {
            ctx.Feedback.Where(f => f.IdFeedback == id)
                .ExecuteDeleteAsync();
        }
    }
}
