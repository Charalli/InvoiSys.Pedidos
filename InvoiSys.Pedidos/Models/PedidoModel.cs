namespace InvoiSys.Pedidos.Models
{
    public class PedidoModel
    {
        public int NumeroDoPedido { get; set; }

        public DateTime DataDaSolicitacao { get; set; }

        public DateTime DataPrevistaEntrega { get; set; }

        public string? Observacao { get; set; }

        public List<ItemPedidoModel> ListaItensDoPedido { get; set; } = [];
    }
}