using healthclinic_webapi.Domains;

namespace healthclinic_webapi.Interfaces
{
    public interface IFeedbackRepository
    {
        void Cadastrar(Feedback feedback);

        void Deletar(Guid id);
        
        void Atualizar(Guid id, Feedback feedback);
    }
}
