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
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoRepository _enderecoRepository;

        /// <summary>
        /// Chama um endereco repository
        /// </summary>
     
        public EnderecoController()
        {
            _enderecoRepository = new EnderecoRepository();
        }

        /// <summary>
        /// Cadastra um  novo endereco
        /// </summary>
        /// <param name="endereco">Novo endereco</param>
        /// <returns>Retorna status code 201</returns>

        [HttpPost]

        public IActionResult Cadastrar(Endereco endereco)
        {
            try
            {
                endereco.IdEndereco= Guid.NewGuid();

                _enderecoRepository.Cadastrar(endereco);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Deleta um enderco
        /// </summary>
        /// <param name="id">Id do endereco que sera deletado</param>
        /// <returns>Retorna status code 204</returns>

        [HttpDelete("{id}")]

        public IActionResult Deletar(Guid id)
        {
            try
            {
                _enderecoRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
    }
}
