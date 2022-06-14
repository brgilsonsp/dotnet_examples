using System.ComponentModel.DataAnnotations;

namespace Filmes.Data.DTO
{
    public class CreateFilmeDTO
    {
        [Required(ErrorMessage = "Campo Titulo é obrigatório")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = ("Campo Diretor é obrigatório"))]
        public string Diretor { get; set; }

        [Required(AllowEmptyStrings = true)]
        [Range(1, 120, ErrorMessage = "Duracao deve ter entre 1 a 120 minutos")]
        public int Duracao { get; set; }

        public override string ToString()
        {
            return $"Titulo: {Titulo}, Diretor: {Diretor}, Duracao: {Duracao} minutos";
        }
    }
}
