using healthclinic_webapi.Domains;

namespace healthclinic_webapi.Interfaces
{
    public interface IEspecialidadeRepository
    {
        void Cadastrar(Especialidade especialidade);

        void Deletar(Guid id);
    }
}
