using DonationAcademy.Context;
using DonationAcademy.Models;

using Microsoft.EntityFrameworkCore;

namespace DonationAcademy.Areas.Admin.Servicos
{
    public class RelatorioVendasService
    {
        private readonly AppDbContext context;

        public RelatorioVendasService(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Pedido>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var resultado = from obj in context.Pedidos select obj;

            if (minDate.HasValue)
            {
                resultado = resultado.Where(x => x.PedidoEnviado >= minDate.Value);
            }

            if (maxDate.HasValue)
            {
                resultado = resultado.Where(x => x.PedidoEnviado <= maxDate.Value);
            }

            return await resultado
                         .Include(p => p.PedidoItens)
                         .ThenInclude(r => r.Material)
                         .OrderByDescending(x => x.PedidoEnviado)
                         .ToListAsync();

        }
    }
}
