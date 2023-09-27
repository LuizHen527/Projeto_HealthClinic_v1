using healthclinic_webapi.Domains;

namespace healthclinic_webapi.Interfaces
{
    /// <summary>
    /// Interface de especialidade
    /// </summary>
    public interface IEspecialidadeRepository
    {
        /// <summary>
        /// Cadastra uma nova especialidade
        /// </summary>
        /// <param name="especialidade">Nova especialidade</param>
        void Cadastrar(Especialidade especialidade);

        /// <summary>
        /// Deleta uma especialidade
        /// </summary>
        /// <param name="id">Id da especialidade que sera deletada</param>
        void Deletar(Guid id);
    }
}
