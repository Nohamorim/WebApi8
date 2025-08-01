using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi8.Models;
using WebApi8.Dto;
using WebApi8.Dto.Autor;
using WebApi8.Dto.Livro;
using Azure;
using Microsoft.EntityFrameworkCore;

namespace WebApi8.Dto.Autor
{
    public class AutorCriacaoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
    }
}