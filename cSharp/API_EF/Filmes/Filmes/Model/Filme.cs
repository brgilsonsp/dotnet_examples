using Filmes.Data.DTO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Filmes.Model
{
    [Table("FilmesNosso")]
    public class Filme
    {
        [Key]
        [Required]
        [Column("Id")]
        public int Id { get; set; }

        [Column("FilmName")]
        [Required(ErrorMessage = "Campo Titulo é obrigatório")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = ("Campo Diretor é obrigatório"))]
        [Column("Director")]
        public string Diretor { get; set; }

        [Required(AllowEmptyStrings = true)]
        [Range(1, 120, ErrorMessage = "Duracao deve ter entre 1 a 120 minutos")]
        [Column("Duration")]
        public int Duracao { get; set; }

        public override string ToString()
        {
            return $"Titulo: {Titulo}, Diretor: {Diretor}, Duracao: {Duracao} minutos";
        }

        public static Filme BuildFilmeByDto(CreateFilmeDTO dto)
        {
            return new()
            {
                Diretor = dto.Diretor,
                Duracao = dto.Duracao,
                Titulo = dto.Titulo
            };
        }

    }
}
