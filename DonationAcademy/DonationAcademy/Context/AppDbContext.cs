using DonationAcademy.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DonationAcademy.Areas.Doador.Models;
using DonationAcademy.Areas.Admin.ViewModels;

namespace DonationAcademy.Context
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Material> Materiais{ get; set; }
        public DbSet<CarrinhoCompraItem> CarrinhoCompraItens{ get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoDetalhe> PedidosDetalhe { get; set; }
        public DbSet<DoadorM> Doadores { get; set; }
        public DbSet<CategoriaDoador> CategoriaDoadores { get; set; }
        public DbSet<DonationAcademy.Areas.Admin.ViewModels.AdminRegistroUsuarioViewModel> AdminRegistroUsuarioViewModel { get; set; }
    }
}
