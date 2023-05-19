using DonationAcademy.Areas.Doador.Models;

namespace DonationAcademy.Areas.Doador.Repositories.Interfaces
{
    public interface ICategoriaDoadorRepository
    {
        IEnumerable<CategoriaDoador> CategoriaDoadores { get; }
    }
}
