using healthclinic_webapi.Domains;

namespace healthclinic_webapi.Interfaces
{
    /// <summary>
    /// Interface de paciente
    /// </summary>
    public interface IPacienteRepository
    {
        /// <summary>
        /// Cadastra um novo paciente
        /// </summary>
        /// <param name="paciente">Novo paciente</param>
        void Cadastrar(Paciente paciente);

        /// <summary>
        /// Lista todos os pacientes
        /// </summary>
        /// <returns>Retorna lista com os pacientes</returns>
        List<Paciente> ListarTodos();

        /// <summary>
        /// Atualiza um paciente
        /// </summary>
        /// <param name="id">Id do paciente que sera atualizado</param>
        /// <param name="paciente">Novos dados de paciente</param>
        void Atualizar(Guid id, Paciente paciente);

        /// <summary>
        /// Deleta um paciente
        /// </summary>
        /// <param name="id">Id do paciente que sera deletado</param>
        void Delete(Guid id);
    }
}
