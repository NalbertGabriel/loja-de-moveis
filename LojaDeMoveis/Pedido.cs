using System;
using System.Globalization;
using System.Collections.Generic;

namespace LojaDeMoveis
{
    public class Pedido
    {
		public int codigo { get; private set; }
		public DateTime data { get; private set; }
		public List<ItemPedido> itens { get; set; }

        public Pedido(int codigo, int dia,int mes, int ano)
        {
			this.codigo = codigo;
			this.data = new DateTime(ano, mes, dia);
			itens = new List<ItemPedido>();
        }

		public double valorTotal(){
			double soma = 0.0;
			foreach(ItemPedido item in itens){
				soma += item.subTotal();
			}
			return soma;
		}

		public override string ToString()
		{
			string s = "Pedido: " + codigo + ", data: " + data.Day + "/" + data.Month + "/" + data.Year;
			s += "\nItens: \n";

			foreach(ItemPedido item in itens){
				s += item.ToString() + "\n";
			}
			s += "Total do pedido: " + valorTotal().ToString("F2",CultureInfo.InvariantCulture);
			return s;
		}
		
	}
}
