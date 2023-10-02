using healthclinic_webapi.Domains;

namespace healthclinic_webapi.Interfaces
{
    public interface IMedicoRepository
    {

        /// <summary>
        /// Cadastra um novo medico
        /// </summary>
        /// <param name="medico">Novo medico</param>
        void Cadastrar(Medico medico);

        /// <summary>
        /// Lista todos os medicos
        /// </summary>
        /// <returns>Retorna lista com os medicos</returns>
        List<Medico> Listar();

        /// <summary>
        /// Atualiza um medico
        /// </summary>
        /// <param name="id">Id do medico</param>
        /// <param name="medico">Novos dados</param>
        void Atualizar(Guid id, Medico medico);

        /// <summary>
        /// Deleta um medico
        /// </summary>
        /// <param name="id">Id do medico</param>
        void Delete(Guid id);
    }
}
