using healthclinic_webapi.Domains;

namespace healthclinic_webapi.Interfaces
{
    public interface IPacienteRepository
    {
        void Cadastrar(Paciente paciente);

        List<Paciente> ListarTodos();

        void Atualizar(Guid id, Paciente paciente);

        void Delete(Guid id);
    }
}
