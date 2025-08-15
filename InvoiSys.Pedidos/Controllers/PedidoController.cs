using InvoiSys.Pedidos.Interfaces;
using InvoiSys.Pedidos.Models;
using Microsoft.AspNetCore.Mvc;

namespace InvoiSys.Pedidos.Controllers
{
    public class PedidoController(IPedidoRepository repository) : Controller
    {
        [HttpGet]
        public IActionResult Pedidos()
        {
            List<PedidoModel>? pedidos = repository.CarregarPedidos();

            return View(pedidos);
        }

        [HttpGet]
        public IActionResult DetalhesPedido(int NumeroDoPedido)
        {
            PedidoModel? pedido = repository.CarregarPedidoPorNumeroDoPedido(NumeroDoPedido);

            if (pedido == null)
                return NotFound();
            
            return View(pedido);
        }

        [HttpGet]
        public IActionResult RemoverPedido(int NumeroDoPedido)
        {
            bool retorno = repository.RemoverPedido(NumeroDoPedido);

            if (!retorno)
                return NotFound();

            return RedirectToAction(nameof(Pedidos));
        }

        [HttpGet]
        public IActionResult CriarPedido()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CriarPedido(PedidoModel pedido)
        {
            if (ModelState.IsValid)
            {
                repository.SalvarPedido(pedido);

                return RedirectToAction(nameof(Pedidos));
            }

            return View(pedido);
        }
    }
}
