using DonationAcademy.Areas.Doador.Models;

namespace DonationAcademy.ViewModels
{
    public class DoadorListViewModel
    {
        public IEnumerable<DoadorM> Doadores { get; set; }
        public string CategoriaAtual { get; set; }
    }
}
