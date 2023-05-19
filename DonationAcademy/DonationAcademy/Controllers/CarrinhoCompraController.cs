using DonationAcademy.Models;
using DonationAcademy.Repositories.Interfaces;
using DonationAcademy.ViewModels;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DonationAcademy.Controllers
{
    [Authorize]
    public class CarrinhoCompraController : Controller
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraController(IMaterialRepository materialRepository, CarrinhoCompra carrinhoCompra)
        {
            _materialRepository = materialRepository;
            _carrinhoCompra = carrinhoCompra;
        }

        [Authorize]
        public IActionResult Carrinho()
        {
            var itens = _carrinhoCompra.GetCarrinhoCompraItens();
            _carrinhoCompra.CarrinhoCompraItems = itens;

            var carrinhoCompraVM = new CarrinhoCompraViewModel
            {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal(),

            };
            return View(carrinhoCompraVM);
        }

        [Authorize]
        public RedirectToActionResult AdicionarItemNoCarrinhoCompra(int materialId)
        {
            var materialSelecionado = _materialRepository.Materiais
                .FirstOrDefault(m => 
                m.MaterialId == materialId);

            if (materialSelecionado != null)
            {
                _carrinhoCompra.AdicionarAoCarrinho(materialSelecionado);
            }

            return RedirectToAction("Carrinho");
        }

        [Authorize]
        public IActionResult RemoverItemDoCarrinho(int materialId)
        {
            var materialSelecionado = _materialRepository.Materiais
                .FirstOrDefault(m =>
                m.MaterialId == materialId);

            if (materialSelecionado != null)
            {
                _carrinhoCompra.RemoverDoCarrinho(materialSelecionado);
            }

            return RedirectToAction("Carrinho");
        }
    }
}
