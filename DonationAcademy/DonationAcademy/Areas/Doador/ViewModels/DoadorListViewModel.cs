using DonationAcademy.Areas.Doador.Models;

namespace DonationAcademy.Areas.Doador.ViewModels
{
    public class DoadorListViewModel
    {
        public IEnumerable<DoadorM> Doadores { get; set; }
        public string CategoriaDoadorAtual { get; set; }
    }
}
