using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi8.Models;
using WebApi8.Dto.Autor;
using WebApi8.Dto.Livro;
using Azure;

namespace WebApi8.Services.Livro
{
    public interface ILivroInterface
    {
        Task<ResponseModel<List<LivroModel>>> ListarLivros();
        Task<ResponseModel<LivroModel>> BuscarLivroPorId(int idLivro);
        Task<ResponseModel<List<LivroModel>>> BuscarLivroPorIdAutor(int idAutor);
        Task<ResponseModel<List<LivroModel>>> CriarLivro(LivroCriacaoDto livroCriacaoDto);
        Task<ResponseModel<List<LivroModel>>> EditarLivro(LivroCriacaoDto livroCriacaoDto);
        Task<ResponseModel<List<LivroModel>>> ExcluirLivro(int idLivro);
    }
}