using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi8.Dto.Livro
{
    public class LivroEdicaoDto
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public AutorModel? Autor { get; set; }
    }
}