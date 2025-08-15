using InvoiSys.Pedidos.Models;

namespace InvoiSys.Pedidos.Interfaces
{
    public interface IPedidoRepository
    {
        List<PedidoModel>? CarregarPedidos();

        PedidoModel? CarregarPedidoPorNumeroDoPedido(int numeroDoPedido);

        PedidoModel SalvarPedido(PedidoModel pedido);

        bool RemoverPedido(int numeroDoPedido);
    }
}