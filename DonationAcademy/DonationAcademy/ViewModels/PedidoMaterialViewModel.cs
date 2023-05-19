using DonationAcademy.Models;

namespace DonationAcademy.ViewModels
{
    public class PedidoMaterialViewModel
    {
        public Pedido Pedido { get; set; }
        public IEnumerable<PedidoDetalhe> PedidoDetalhes { get; set; }
    }
}
