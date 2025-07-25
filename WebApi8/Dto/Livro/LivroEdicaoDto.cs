using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi8.Models;
using WebApi8.Dto.Autor;
using Azure;
using Microsoft.EntityFrameworkCore;
using WebApi8.Dto.Livro;
using WebApi8.Dto.Vinculo;


namespace WebApi8.Dto.Livro
{
    public class LivroEdicaoDto
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public AutorVinculoDto Autor { get; set; }
    }
}