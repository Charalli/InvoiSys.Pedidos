using InvoiSys.Pedidos.Interfaces;
using InvoiSys.Pedidos.Models;
using System.Text.Json;

namespace InvoiSys.Pedidos.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly string _filePath = Path.Combine(AppContext.BaseDirectory, "Data", "Pedidos.txt");

        public List<PedidoModel>? CarregarPedidos()
        {
            if (!File.Exists(_filePath))
                return new List<PedidoModel>();

            string json = File.ReadAllText(_filePath);

            if (string.IsNullOrEmpty(json))
                return new List<PedidoModel>();

            return JsonSerializer.Deserialize<List<PedidoModel>>(json);
        }

        public PedidoModel? CarregarPedidoPorNumeroDoPedido(int numeroDoPedido)
        {
            if (!File.Exists(_filePath))
                return null;

            string json = File.ReadAllText(_filePath);

            if (string.IsNullOrEmpty(json))
                return null;

            var pedidos = JsonSerializer.Deserialize<List<PedidoModel>>(json);

            return pedidos?.FirstOrDefault(p => p.NumeroDoPedido == numeroDoPedido);
        }

        public PedidoModel SalvarPedido(PedidoModel pedido)
        {
            List<PedidoModel>? listaPedidos = CarregarPedidos();

            listaPedidos!.Add(pedido);

            string json = JsonSerializer.Serialize(listaPedidos);
            
            File.WriteAllText(_filePath, json);

            return pedido;
        }

        public bool RemoverPedido(int numeroDoPedido)
        {
            List<PedidoModel>? listaPedidos = CarregarPedidos();

            var pedidoToRemove = listaPedidos?.FirstOrDefault(p => p.NumeroDoPedido == numeroDoPedido);

            if (pedidoToRemove != null)
            {
                listaPedidos!.Remove(pedidoToRemove);

                string json = JsonSerializer.Serialize(listaPedidos);
                
                File.WriteAllText(_filePath, json);

                return true;
            }

            return false;
        }
    }
}