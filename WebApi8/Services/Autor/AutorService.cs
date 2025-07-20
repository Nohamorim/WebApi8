using Microsoft.EntityFrameworkCore;
using WebApi8.Models;
using WebApi8.Dto.Autor;
using Azure;

namespace WebApi8.Services.Autor
{
    public class AutorService : IAutorInterface
    {
        private readonly AppDbContext _context;
        public AutorService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel<AutorModel>> BuscarAutorPorId(int idAutor)
        {
            ResponseModel<AutorModel> response = new ResponseModel<AutorModel>();
            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id == idAutor);

                if(autor == null)
                {
                    response.Mensagem = "Nenhum registro localizado.";
                    return response;
                }

                response.Dados = autor;
                response.Mensagem = "Autor localizado com sucesso.";
                return response;

            } catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<AutorModel>> BuscarAutorPorIdLivro(int idLivro)
        {
            ResponseModel<AutorModel> response = new ResponseModel<AutorModel>();
            try
            {
                var livro = await _context.Livros
                .Include(a => a.Autor)
                .FirstOrDefaultAsync(LivroBanco => LivroBanco.Id == idLivro);

                if (livro == null)
                {
                    response.Mensagem = "Nenhum autor localizado para o livro informado.";
                    return response;
                }
                
                response.Dados = livro.Autor;
                response.Mensagem = "Autor do livro localizado com sucesso.";
                return response;

            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> CriarAutor(AutorCriacaoDto autorCriacaoDto)
        {
            ResponseModel<List<AutorModel>> response = new ResponseModel<List<AutorModel>>();

            try
            {
                var autor = new AutorModel
                {
                    Nome = autorCriacaoDto.Nome,
                    Sobrenome = autorCriacaoDto.Sobrenome
                };
                _context.Add(autor);
                await _context.SaveChangesAsync();

                response.Dados = await _context.Autores.ToListAsync();
                response.Mensagem = "Autor criado com sucesso!";
            }catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
            }

            return response;
        }

        public async Task<ResponseModel<List<AutorModel>>> EditarAutor(AutorEdicaoDto autorEdicaoDto)
        {
            ResponseModel<List<AutorModel>> response = new ResponseModel<List<AutorModel>>();

            try
            {
                var autor = await _context.Autores
                .FirstOrDefaultAsync(autorBanco => autorBanco.Id == autorEdicaoDto.Id);
                if (autor == null)
                {
                    response.Mensagem = "Autor não encontrado.";
                    return response;
                }

                autor.Nome = autorEdicaoDto.Nome;
                autor.Sobrenome = autorEdicaoDto.Sobrenome;

                _context.Update(autor);
                await _context.SaveChangesAsync();

                response.Dados = await _context.Autores.ToListAsync();
                response.Mensagem = "Autor editado com sucesso!";
                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
            }

            return response;
        }        

        public async Task<ResponseModel<List<AutorModel>>> ExcluirAutor(int idAutor)
        {
            ResponseModel<List<AutorModel>> response = new ResponseModel<List<AutorModel>>();

            try
            {
                var autor = await _context.Autores
                    .FirstOrDefaultAsync(autorBanco => autorBanco.Id == idAutor);
                if (autor == null)
                {
                    response.Mensagem = "Autor não encontrado!";
                    return response;
                }

                _context.Remove(autor);
                await _context.SaveChangesAsync();

                response.Dados = await _context.Autores.ToListAsync();
                response.Mensagem = "Autor removido com sucesso!";
                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
            }

            return response;
        }

        public async Task<ResponseModel<List<AutorModel>>> ListarAutores()
        {
            ResponseModel<List<AutorModel>> response = new ResponseModel<List<AutorModel>>();
            try
            {
                var autores = await _context.Autores.ToListAsync();

                response.Dados = autores;
                response.Mensagem = "Todos os autores foram coletados.";
                return response;

            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }
    }
}