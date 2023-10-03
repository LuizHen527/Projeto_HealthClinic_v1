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
    public class TiposUsuarioController : ControllerBase
    {
        public ITiposUsuarioRepository _tiposUsuario;

        public TiposUsuarioController()
        {
            _tiposUsuario = new TiposUsuarioRepository();
        }

        /// <summary>
        /// Cadastra um tipo de usuario
        /// </summary>
        /// <param name="tiposUsuario">Novo tipo de usuario</param>
        /// <returns>Status code 200</returns>
        [HttpPost]

        public IActionResult Cadastrar(TiposUsuario tiposUsuario)
        {
            try
            {
                tiposUsuario.IdTiposUsuario = Guid.NewGuid();

                _tiposUsuario.Cadastrar(tiposUsuario);
                return Ok();
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Deleta um tipo de usuario
        /// </summary>
        /// <param name="id">Id do tipo de usuario</param>
        /// <returns>Retona status code 204</returns>
        [HttpDelete]

        public IActionResult Deletar(Guid id)
        {
            try
            {
                _tiposUsuario.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
    }
}
