using System.ComponentModel.DataAnnotations;

namespace DonationAcademy.Models
{
    public class CarrinhoCompraItem
    {
        [Key]
        public int CarrinhoCompraItemId { get; set; }
        public int Quantidade { get; set; }

        [StringLength(200)]
        public string CarrinhoCompraId { get; set; }

        public Material Material { get; set; }
    }
}
