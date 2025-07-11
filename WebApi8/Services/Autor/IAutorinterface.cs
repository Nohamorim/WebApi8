using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi8.Models;

namespace WebApi8.Services.Autor
{
    public interface IAutorInterface
    {
        Task<ResponseModel<List<AutorModel>>> ListarAutores();
        Task<ResponseModel<AutorModel>> BuscarAutorPorId(int idAutor);
        Task<ResponseModel<AutorModel>> BuscarAutorPorIdLivro(int idLivro);
    }
}