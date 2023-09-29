using healthclinic_webapi.Domains;

namespace healthclinic_webapi.Interfaces
{
    public interface IConsultaRepository
    {
        /// <summary>
        /// Cadastra uma nova consulta 
        /// </summary>
        /// <param name="consulta">Nova consulta</param>
        void Cadastrar(Consulta consulta);

        /// <summary>
        /// Lista todas as consultas 
        /// </summary>
        /// <returns>retorna lista com as consultas</returns>
        List<Consulta> Listar();

        /// <summary>
        /// atualiza uma consulta
        /// </summary>
        /// <param name="id">Id da consulta que sera atualizada</param>
        /// <param name="consulta">Novos dados de consulta</param>
        void Atualizar(Guid id, Consulta consulta);

        /// <summary>
        /// Deleta uma consulta
        /// </summary>
        /// <param name="id">Id da consulta que sera deletada</param>
        void Delete(Guid id);

        /// <summary>
        /// Busca por todas as consultas de um medico
        /// </summary>
        /// <param name="id">Id do medico</param>
        /// <returns>Retorna lista com todas as consultas de um medico</returns>
        List<Consulta> BuscarPorIdMedico(Guid id);

        /// <summary>
        /// Busca por todas as consultas de um medico
        /// </summary>
        /// <param name="id">Id do paciente</param>
        /// <returns>Retorna lista com todas as consultas de um paciente</returns>
        List<Consulta> BuscarPorIdPaciente(Guid id);
    }
}
