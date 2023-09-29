using healthclinic_webapi.Domains;
using healthclinic_webapi.Interfaces;
using healthclinic_webapi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace healthclinic_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackRepository _feedbackRepository;

        /// <summary>
        /// Chama os metodos
        /// </summary>
        public FeedbackController()
        {
            _feedbackRepository = new FeedbackRepository();
        }

        /// <summary>
        /// Cadastra um novo feedback
        /// </summary>
        /// <param name="feedback">Novo feedback</param>
        /// <returns>Retorna status code 201</returns>
        [HttpPost]

        public IActionResult Cadastrar(Feedback feedback)
        {
            try
            {
                feedback.IdFeedback = Guid.NewGuid();

                _feedbackRepository.Cadastrar(feedback);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Atualiza um feedback
        /// </summary>
        /// <param name="id">Id do feedback que sera atualizado</param>
        /// <param name="feedback">Novos dados</param>
        /// <returns>Retorna status code 200</returns>
        [HttpPut("{id}")]

        public IActionResult Atualizar(Guid id, Feedback feedback)
        {
            try
            {
                _feedbackRepository.Atualizar(id, feedback);
                return StatusCode(200);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Deleta um feedback
        /// </summary>
        /// <param name="id">Id do feedback que sera deletado</param>
        /// <returns>Retorna status code 204</returns>
        [HttpDelete("{id}")]

        public IActionResult Deletar(Guid id)
        {
            try
            {
                _feedbackRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
    }
}
