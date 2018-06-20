using System;
using System.Globalization;
namespace LojaDeMoveis
{
	public class Produto : IComparable
    {
		public int codigo { get; private set; }
		public string descricao { get; private set; }
		public double preco { get; private set; }

        public Produto(int codigo, string descricao, double preco)
        {
			this.codigo = codigo;
			this.descricao = descricao;
			this.preco = preco;
        }

		public override string ToString()
		{
			return codigo + ", "
				+ descricao + ", "
				+ preco.ToString("F2",CultureInfo.InvariantCulture);
		}

		public int CompareTo(object obj)
		{
			Produto outro = (Produto)obj;
			int resultado = descricao.CompareTo(outro.descricao);
			if (resultado != 0){
				return resultado;
			}else{
				return -preco.CompareTo(outro.preco);
			}
		}
	}
}
