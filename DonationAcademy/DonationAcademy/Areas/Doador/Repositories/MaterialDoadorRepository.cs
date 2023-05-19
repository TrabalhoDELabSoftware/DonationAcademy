using DonationAcademy.Areas.Doador.Models;
using DonationAcademy.Areas.Doador.Repositories.Interfaces;
using DonationAcademy.Context;

using Microsoft.EntityFrameworkCore;

namespace DonationAcademy.Areas.Doador.Repositories
{
    public class MaterialDoadorRepository : IMaterialDoadorRepository
    {
        private readonly AppDbContext _context;

        public MaterialDoadorRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<DoadorM> DoadorMs => _context.Doadores.Include(cd => cd.CategoriaDoador);

        public DoadorM GetDoadorById(int id)
        {
            return _context.Doadores.FirstOrDefault(cd => cd.Id == id);
        }
    }
}
