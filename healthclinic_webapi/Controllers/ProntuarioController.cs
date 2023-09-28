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
    public class ProntuarioController : ControllerBase
    {
        private readonly IProntuarioRepository _prontuarioRepository;

        public ProntuarioController()
        {
            _prontuarioRepository = new ProntuarioRepository();
        }

        /// <summary>
        /// Cadastra um novo prontuario
        /// </summary>
        /// <param name="prontuario">Novo prontuario</param>

        [HttpPost]

        public IActionResult Cadastrar(Prontuario prontuario)
        {
            try
            {
                _prontuarioRepository.Cadastrar(prontuario);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Atualiza um prontuario
        /// </summary>
        /// <param name="id">Id do prontuario que sera atualizado</param>
        /// <param name="prontuario">Novos dados de prontuario</param>

        [HttpPut]

        public IActionResult Atualizar(Guid id, Prontuario prontuario)
        {
            try
            {
                _prontuarioRepository.Atualizar(id, prontuario);
                return StatusCode(200);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Deleta um prontuario
        /// </summary>
        /// <param name="id">Id do prontuario que sera deletado</param>

        [HttpDelete("{id}")]

        public IActionResult Deletar(Guid id)
        {
            try
            {
                _prontuarioRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
    }
}
