using healthclinic_webapi.Domains;

namespace healthclinic_webapi.Interfaces
{
    public interface IConsultaRepository
    {
        //teste
        void Cadastrar(Consulta consulta);
        List<Consulta> Listar();
        void Atualizar(Guid id, Consulta consulta);
        void Delete(Guid id);

        List<Consulta> BuscarPorIdMedico(Guid id);

        List<Consulta> BuscarPorIdPaciente(Guid id);
    }
}
