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
    public class LivroService : ILivroInterface
    {
        public Task<ResponseModel<LivroModel>> BuscarLivroPorId(int idLivro)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<LivroModel>> BuscarLivroPorIdAutor(int idAutor)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<AutorModel>>> CriarAutor(AutorCriacaoDto autorCriacaoDto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<AutorModel>>> EditarAutor(AutorEdicaoDto autorEdicaoDto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<AutorModel>>> ExcluirAutor(int idAutor)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<LivroModel>>> ListarLivros()
        {
            throw new NotImplementedException();
        }
    }
}