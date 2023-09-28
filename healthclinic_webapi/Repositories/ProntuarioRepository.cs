using healthclinic_webapi.Contexts;
using healthclinic_webapi.Domains;
using healthclinic_webapi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace healthclinic_webapi.Repositories
{
    /// <summary>
    /// Classe com metodos de prontuario
    /// </summary>
    public class ProntuarioRepository : IProntuarioRepository
    {
        private ClinicContext ctx;

        /// <summary>
        /// Chama o contexto
        /// </summary>
        public ProntuarioRepository()
        {
            ctx = new ClinicContext();
        }

        /// <summary>
        /// Atualiza um prontuario
        /// </summary>
        /// <param name="id">Id do prontuario que sera atualizado</param>
        /// <param name="prontuario">Novos dados de prontuario</param>
        public void Atualizar(Guid id, Prontuario prontuario)
        {
            ctx.Prontuario.Where(p => p.IdProntuario == id)
                .ExecuteUpdateAsync(updates =>
                    updates.SetProperty(p => p.Descricao, prontuario.Descricao));
        }

        /// <summary>
        /// Cadastra um novo prontuario
        /// </summary>
        /// <param name="prontuario">Novo prontuario</param>
        public void Cadastrar(Prontuario prontuario)
        {
            ctx.Prontuario.Add(prontuario);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um prontuario
        /// </summary>
        /// <param name="id">Id do prontuario que sera deletado</param>
        public void Deletar(Guid id)
        {
            ctx.Prontuario.Where(p => p.IdProntuario == id)
                .ExecuteDeleteAsync();
        }
    }
}
