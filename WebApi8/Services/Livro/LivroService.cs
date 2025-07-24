using WebApi8.Models;
using WebApi8.Dto.Livro;
using Microsoft.EntityFrameworkCore;

namespace WebApi8.Services.Livro
{
    public class LivroService : ILivroInterface
    {
        private readonly AppDbContext _context;

        public LivroService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel<LivroModel>> BuscarLivroPorId(int idLivro)
        {
            ResponseModel<LivroModel> response = new ResponseModel<LivroModel>();
            try
            {
                var livro = await _context.Livros
                .FirstOrDefaultAsync(livroBanco => livroBanco.Id == idLivro);

                if(livro == null)
                {
                    response.Mensagem = "Nenhum registro localizado.";
                    return response;
                }

                response.Dados = livro;
                response.Mensagem = "Livro localizado com sucesso!";
                return response;

            } catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> BuscarLivroPorIdAutor(int idAutor)
        {
            ResponseModel<List<LivroModel>> response = new ResponseModel<List<LivroModel>>();
            try
            {
                var livro = await _context.Livros
                .Include(a => a.Autor)
                .Where(LivroBanco => LivroBanco.Id == idAutor)
                .ToListAsync();

                if (livro == null)
                {
                    response.Mensagem = "Nenhum autor localizado para o livro informado.";
                    return response;
                }
                
                response.Dados = livro;
                response.Mensagem = "Livro(s) localizado(s) com sucesso.";
                return response;

            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> CriarLivro(LivroCriacaoDto livroCriacaoDto)
        {
            ResponseModel<List<LivroModel>> response = new ResponseModel<List<LivroModel>>();

            try
            {
                var autor = await _context.Autores
                .FirstOrDefaultAsync(autorBanco => autorBanco.Id == livroCriacaoDto.Autor.Id);

                if (autor == null)
                {
                    response.Mensagem = "Nenhum registro de autor localizado!";
                    return response;
                }

                var livro = new LivroModel()
                {
                    Titulo = livroCriacaoDto.Titulo,
                    Autor = autor,
                };

                _context.Add(livro);
                await _context.SaveChangesAsync();

                response.Dados = await _context.Livros.Include(a => a.Autor).ToListAsync();
                return response;
            }

            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
            }

            return response;
        }

        public async Task<ResponseModel<List<LivroModel>>> EditarLivro(LivroCriacaoDto livroCriacaoDto)
        {
            ResponseModel<List<LivroModel>> response = new ResponseModel<List<LivroModel>>();

            try
            {
                var livro = await _context.Livros
                .Include(a => a.Autor)
                .FirstOrDefaultAsync(livroBanco => livroBanco.Id == livroCriacaoDto.Id);
                var autor = await _context.Autores
                .FirstOrDefaultAsync(autorBanco => autorBanco.Id == livroCriacaoDto.Autor.Id);

                if (autor == null)
                {
                    response.Mensagem = "Nenhum registro de autor localizado!";
                    return response;
                }

                if (livro == null)
                {
                    response.Mensagem = "Nenhum registro de livro localizado!";
                    return response;
                }

                livro.Titulo = livroCriacaoDto.Titulo;
                livro.Autor = autor;

                _context.Update(livro);
                await _context.SaveChangesAsync();

                response.Dados = await _context.Livros.ToListAsync();

                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
            }

            return response;
        }

        public async Task<ResponseModel<List<LivroModel>>> ExcluirLivro(int idLivro)
        {
            ResponseModel<List<LivroModel>> response = new ResponseModel<List<LivroModel>>();

            try
            {
                var livro = await _context.Livros
                    .FirstOrDefaultAsync(livroBanco => livroBanco.Id == idLivro);
                if (livro == null)
                {
                    response.Mensagem = "Livro não encontrado!";
                    return response;
                }

                _context.Remove(livro);
                await _context.SaveChangesAsync();

                response.Dados = await _context.Livros.ToListAsync();
                response.Mensagem = "Livro removido com sucesso!";
                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
            }

            return response;
        }

        public async Task<ResponseModel<List<LivroModel>>> ListarLivros()
        {
            ResponseModel<List<LivroModel>> response = new ResponseModel<List<LivroModel>>();
            try
            {
                var livros = await _context.Livros.ToListAsync();

                response.Dados = livros;
                response.Mensagem = "Todos os livros foram coletados!";
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