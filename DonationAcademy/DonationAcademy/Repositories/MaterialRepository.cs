using DonationAcademy.Context;
using DonationAcademy.Models;
using DonationAcademy.Repositories.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace DonationAcademy.Repositories
{
    public class MaterialRepository : IMaterialRepository
    {
        private readonly AppDbContext _context;

        public MaterialRepository(AppDbContext contexto)
        {
            _context = contexto;
        }

        public IEnumerable<Material> Materiais => _context.Materiais.Include(c => c.Categoria);

        public IEnumerable<Material> MateriaisPagos => _context.Materiais
            .Where(m => m.IsMaterialPago)
            .Include(c => c.Categoria);

        public Material GetMaterialById(int materialId)
        {
            return _context.Materiais.FirstOrDefault(m => m.MaterialId == materialId);
        }
    }
}
