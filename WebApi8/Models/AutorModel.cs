using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace WebApi8.Models
{
    public class AutorModel
    {
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Sobrenome { get; set; }
    [JsonIgnore]
    public ICollection<LivroModel> Livros { get; set; } = new List<LivroModel>();
}
}
