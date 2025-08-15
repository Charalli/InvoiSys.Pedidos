namespace InvoiSys.Pedidos.Models
{
    public class ItemPedidoModel
    {
        public int CodigoDoProduto { get; set; }

        public int Quantidade { get; set; }

        public string? DescricaoDoProduto { get; set; }

        public decimal ValorDoProduto { get; set; }
    }
}