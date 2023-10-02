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
    public class ConsultaController : ControllerBase
    {
        private readonly IConsultaRepository _consultaRepository;

        public ConsultaController()
        {
            _consultaRepository = new ConsultaRepository();
        }

        /// <summary>
        /// Cadastra uma consulta
        /// </summary>
        /// <param name="consulta">Nova consulta</param>
        /// <returns>Retorna status code 200</returns>

        [HttpPost]

        public IActionResult Cadastrar(Consulta consulta)
        {
            try
            {
                consulta.IdConsulta = Guid.NewGuid();

                _consultaRepository.Cadastrar(consulta);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Lista todas as consultas
        /// </summary>
        /// <returns>Retorna lista com as consultas</returns>
        [HttpGet]

        public IActionResult ListarTodos()
        {
            try
            {
                
                return Ok(_consultaRepository.Listar());
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Lista todas as consultas de um paciente
        /// </summary>
        /// <param name="idPaciente">Id do paciente</param>
        /// <returns>Retorna lista com as consultas do paciente</returns>
        [HttpGet("paciente/{idPaciente}")]

        public IActionResult ListarPorPaciente(Guid idPaciente)
        {
            try
            {
                return Ok(_consultaRepository.BuscarPorIdPaciente(idPaciente));
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Lista todas as consultas de um medico
        /// </summary>
        /// <param name="idMedico">Id do medico</param>
        /// <returns>Retorna lista com as consultas do medico</returns>
        [HttpGet("medico/{idMedico}")]

        public IActionResult ListarPorMedico(Guid idMedico)
        {
            try
            {
                return Ok(_consultaRepository.BuscarPorIdMedico(idMedico));
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Deleta uma consulta
        /// </summary>
        /// <param name="id">Id da consulta</param>
        /// <returns>Retorna status code 204</returns>
        [HttpDelete("{id}")]

        public IActionResult Deletar(Guid id)
        {
            try
            {
                _consultaRepository.Delete(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Atualiza uma consulta
        /// </summary>
        /// <param name="id">Is da consulta</param>
        /// <param name="consulta">Novos dados</param>
        /// <returns>Retorna status code 204</returns>
        [HttpPut]

        public IActionResult Atualizar(Guid id, Consulta consulta)
        {
            try
            {
                _consultaRepository.Atualizar(id, consulta);

                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
    }
}
