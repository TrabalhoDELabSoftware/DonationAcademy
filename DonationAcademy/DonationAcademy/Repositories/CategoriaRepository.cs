﻿using DonationAcademy.Context;
using DonationAcademy.Models;
using DonationAcademy.Repositories.Interfaces;

namespace DonationAcademy.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> Categorias => _context.Categorias;
    }
}
