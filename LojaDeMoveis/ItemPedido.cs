using System;
using System.Globalization;
namespace LojaDeMoveis
{
	public class ItemPedido
	{
		public int quantidade { get; private set; }
		public double porcentagemDesconto { get; private set; }
		public Produto produto { get; private set; }
		public Pedido pedido { get; private set; }

		public ItemPedido(int quantidade, double porcentagemDesconto,Produto produto, Pedido pedido)
        {
			this.quantidade = quantidade;
			this.porcentagemDesconto = porcentagemDesconto;
			this.produto = produto;
			this.pedido = pedido;

        }

		public double subTotal(){
			double desconto;
			desconto = (produto.preco * porcentagemDesconto) / 100.0;
			return (produto.preco - desconto) * quantidade;
		}

		public override string ToString()
		{
			return produto.descricao 
				          + ", Preço: " + produto.preco.ToString("F2",CultureInfo.InvariantCulture) 
				          + ", Qte: " + quantidade 
				          + ", Desconto: " + porcentagemDesconto.ToString("F1",CultureInfo.InvariantCulture) + "%"
				          + ", Subtotal: " + subTotal().ToString("F2",CultureInfo.InvariantCulture);
		}
	}
}
