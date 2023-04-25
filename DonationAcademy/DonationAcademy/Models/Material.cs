using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DonationAcademy.Models
{
    [Table("Material")]
    public class Material
    {
        [Key]
        public int MaterialId { get; set; }

        [Required(ErrorMessage = "Informe o nome do material!")]
        [Display(Name = "Nome do Material")]
        [StringLength(80, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 80 caracteres!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A descrição do material deve ser informada!")]
        [Display(Name = "Descrição breve do Material")]
        [MinLength(20, ErrorMessage = "Descrição deve ter no mínimo {1} caracteres")]
        [MaxLength(200, ErrorMessage = "Descrição pode exceder (1) caracteres")]
        public string DescricaoCurta { get; set; }

        [Required(ErrorMessage = "A descrição do material deve ser informada!")]
        [Display(Name = "Descrição detalhada do Material")]
        [MinLength(20, ErrorMessage = "Descrição deve ter no mínimo {1} caracteres")]
        [MaxLength(200, ErrorMessage = "Descrição não pode exceder (1) caracteres")]
        public string DescricaoDetalhada { get; set; }

        [Required(ErrorMessage = "Informe o preço do Material!")]
        [Display(Name = "Preço")]
        [Column(TypeName = "decimal(10, 2)")]
        [Range(0, 85, ErrorMessage = "O preço deve estar entre 0,00 e 85,00")]
        public decimal Preco { get; set; }

        [Display(Name = "Caminho Imagem Normal")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string ImagemUrl { get; set; }


        [Display(Name = "Caminho Imagem Miniatura")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string ImagemThumbnailUrl { get; set; }

        [Display(Name = "Estoque")]
        public bool EmEstoque { get; set; }

        [Display(Name = "Tornar esse material pago")]
        public bool IsMaterialPago { get; set; }

        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
