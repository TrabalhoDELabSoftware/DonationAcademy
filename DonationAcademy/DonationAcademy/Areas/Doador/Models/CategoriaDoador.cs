using System.ComponentModel.DataAnnotations;

using DonationAcademy.Models;

namespace DonationAcademy.Areas.Doador.Models
{
    public class CategoriaDoador
    {
        [Key]
        public int CategoriaDoadorId { get; set; }

        [StringLength(50, ErrorMessage = "Nome da categoria deve ter no máximo 50 caracteres!")]
        [Required(ErrorMessage = "Informe o nome da categoria!")]
        [Display(Name = "Categoria")]
        public string CategoriaDoadorNome { get; set; }

        [StringLength(maximumLength: 200, MinimumLength = 20, ErrorMessage = "Descrição da categoria deve ter entre 20 e 200 caracteres!")]
        [Required(ErrorMessage = "Informe a descrição da categoria!")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public List<DoadorM> Doadores { get; set; }
    }
}
