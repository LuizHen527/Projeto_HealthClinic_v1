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
    public class MedicoController : ControllerBase
    {
        private readonly IMedicoRepository _medicoRepository;

        public MedicoController()
        {
            _medicoRepository = new MedicoRepository();
        }

        /// <summary>
        /// Cadastra um novo medico
        /// </summary>
        /// <param name="medico">Novo medico</param>
        /// <returns>Status code 200</returns>
        [HttpPost]

        public IActionResult Cadastrar(Medico medico)
        {
            try
            {
                medico.IdMedico = Guid.NewGuid();

                _medicoRepository.Cadastrar(medico);

                return Ok();
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Lista todos os medicos
        /// </summary>
        /// <returns>Retorna status code 200 com a lista de medicos</returns>
        [HttpGet]

        public IActionResult Listar()
        {
            try
            {
                List<Medico> medicos = _medicoRepository.Listar();

                return Ok(medicos);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Atualiza um medico
        /// </summary>
        /// <param name="id">Id do medico</param>
        /// <param name="medico">Novos dados</param>
        /// <returns>Retorna status code 200</returns>
        [HttpPut]

        public IActionResult Atualizar(Guid id, Medico medico)
        {
            try
            {
                _medicoRepository.Atualizar(id, medico);
                return Ok();
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Deleta um medico
        /// </summary>
        /// <param name="id">Id do novo medico</param>
        /// <returns>Retorna status code 204</returns>
        [HttpDelete]

        public IActionResult Deletar(Guid id)
        {
            try
            {
                _medicoRepository.Delete(id);
                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
    }
}
