using DonationAcademy.Models;

namespace DonationAcademy.ViewModels
{
    public class MaterialListViewModel
    {
        public IEnumerable<Material> Materiais { get; set; }
        public string CategoriaAtual { get; set; }
    }
}
