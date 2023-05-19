using DonationAcademy.Models;

namespace DonationAcademy.Repositories.Interfaces
{
    public interface IMaterialRepository
    {
        IEnumerable<Material> Materiais { get; }
        IEnumerable<Material> MateriaisPagos { get; }
        Material GetMaterialById(int materialId);

    }
}
