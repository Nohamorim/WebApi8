using Microsoft.AspNetCore.Mvc;
using WebApi8.Models;
using WebApi8.Services.Autor;
using WebApi8.Dto.Autor;
using Azure;


namespace WebApi8.Controllers
{
    [Route("api/[controller]")]
    public class LivroController : ControllerBase
    {
        private readonly ILivroInterface _livroInterface;
        public LivroController(ILivroInterface livroInterface)
        {
            _livroInterface = livroInterface;
        }

        [HttpGet("ListarLivros")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> ListarLivros()
        {
            var livros = await _livroInterface.ListarLivros();
            return Ok(livros);
        }

        [HttpGet("BuscarLivroPorId/{idLivro}")]

        public async Task<ActionResult<ResponseModel<LivroModel>>> BuscarLivroPorId(int idLivro)
        {
            var livro = await _autorInterface.BuscarLivroPorId(idLivro);
            return Ok(livro);
        }

        [HttpGet("BuscarLivroPorIdLivro/{idLivro}")]

        public async Task<ActionResult<ResponseModel<LivroModel>>> BuscarLivroPorIdLivro(int idLivro)
        {
            ResponseModel<LivroModel> response = new ResponseModel<LivroModel>();
            try
            {
                var autor = await _autorInterface.BuscarAutorPorIdLivro(idLivro);
                return Ok(autor);
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        [HttpPost("CriarLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> CriarAutor(AutorCriacaoDto autorCriacaoDto)
        {
            var autores = await _autorInterface.CriarAutor(autorCriacaoDto);
            return Ok(autores);
        }

        [HttpPut("EditarLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> EditarAutor(AutorEdicaoDto autorEdicaoDto)
        {
            var autores = await _autorInterface.EditarAutor(autorEdicaoDto);
            return Ok(autores);
        }

        [HttpDelete("ExcluirLivro")]

        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> ExcluirAutor(int idAutor)
        {
            var autores = await _autorInterface.ExcluirAutor(idAutor);
            return Ok(autores);
        }
    }
}