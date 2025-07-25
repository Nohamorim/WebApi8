namespace WebApi8.Models
{
    public class LivroModel
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public int AutorId { get; set; }  // FK correta
        public AutorModel? Autor { get; set; }
    }
}