using healthclinic_webapi.Contexts;
using healthclinic_webapi.Domains;
using healthclinic_webapi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace healthclinic_webapi.Repositories
{

    /// <summary>
    /// Classe com os metodos de especialidade
    /// </summary>
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        private readonly ClinicContext ctx;

        /// <summary>
        /// Chama a context
        /// </summary>
        public EspecialidadeRepository()
        {
            ctx = new ClinicContext();
        }

        /// <summary>
        /// Cadastra uma nova especialidade
        /// </summary>
        /// <param name="especialidade">Nova especialidade</param>
        public void Cadastrar(Especialidade especialidade)
        {
            ctx.Especialidade.Add(especialidade);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta uma especialidade
        /// </summary>
        /// <param name="id">Id da especialidade que sera deletada</param>
        public void Deletar(Guid id)
        {
            ctx.Especialidade.Where(e => e.IdEspecialidade == id)
                .ExecuteDeleteAsync();
        }
    }
}
