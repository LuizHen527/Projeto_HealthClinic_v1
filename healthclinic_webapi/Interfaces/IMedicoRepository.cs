using healthclinic_webapi.Domains;

namespace healthclinic_webapi.Interfaces
{
    public interface IMedicoRepository
    {
        void Cadastrar(Medico medico);

        List<Medico> Listar();

        void Atualizar(Guid id, Medico medico);

        void Delete(Guid id);
    }
}
