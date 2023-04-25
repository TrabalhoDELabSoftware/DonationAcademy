using DonationAcademy.Areas.Doador.Models;

namespace DonationAcademy.Areas.Doador.Repositories.Interfaces
{
    public interface IMaterialDoadorRepository
    {
        IEnumerable<DoadorM> DoadorMs { get; }
        DoadorM GetDoadorById(int id);
    }
}
