using DonationAcademy.Areas.Doador.Models;
using DonationAcademy.Areas.Doador.Repositories.Interfaces;
using DonationAcademy.Context;

namespace DonationAcademy.Areas.Doador.Repositories
{
    public class CategoriaDoadorRepository : ICategoriaDoadorRepository
    {
        private readonly AppDbContext _context;

        public CategoriaDoadorRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<CategoriaDoador> CategoriaDoadores => _context.CategoriaDoadores;
    }
}
