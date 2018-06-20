using System;
using System.Globalization;
namespace LojaDeMoveis
{
    public class Tela
    {

		//Classe responsavel por interagir com o usuario;
        public Tela()
        {
        }

		public static void mostrarMenu(){
            Console.WriteLine("1 - Listar produtos ordenamente");
            Console.WriteLine("2 - Cadastrar produto");
            Console.WriteLine("3 - Cadastrar pedido");
            Console.WriteLine("4 - Mostrar dados de um pedido");
			Console.WriteLine("5 - Sair");
			Console.Write("Dgite uma opção: ");
		}

		public static void mostrarProdutos(){
			Console.WriteLine("LISTAGEM DE PRODUTOS: ");
			foreach (Produto p in Program.produtos){
				
				Console.WriteLine(p);
			}
		}

		public static void cadastrarProduto(){
			Console.WriteLine("Digite os dados do produto: ");
			Console.Write("Código: "); int codigo = int.Parse(Console.ReadLine());
			Console.Write("Descriçao: "); string descricao = Console.ReadLine();
			Console.Write("Preço: "); double preco = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
			Produto produto = new Produto(codigo, descricao, preco);
			Program.produtos.Add(produto);
			Program.produtos.Sort();
		}
		public static void cadastrarPedido(){
			Console.WriteLine("Digite os dados do pedido:");
			Console.Write("Código: "); int codigo = int.Parse(Console.ReadLine());
			Console.Write("Dia: "); int dia = int.Parse(Console.ReadLine());
			Console.Write("Mes: "); int mes = int.Parse(Console.ReadLine());
			Console.Write("Ano: "); int ano = int.Parse(Console.ReadLine());
			Pedido pedido = new Pedido(codigo,dia,mes,ano);
			Console.Write("Quantos itens tem o pedido? "); int qtePedido = int.Parse(Console.ReadLine());
			for (int i = 1; i <= qtePedido; i++){
				Console.WriteLine("Digite os dados do " + i + "º item: ");
				Console.Write("Produto (código): "); int codigoProduto = int.Parse(Console.ReadLine());
				int pos = Program.produtos.FindIndex(x => x.codigo == codigoProduto);
				if (pos == -1){
					throw new ModelException("Código nao encontrado: " + codigoProduto);
				}
				Produto produto = Program.produtos[pos];
                Console.Write("Quantidade: "); int qte = int.Parse(Console.ReadLine());
				Console.Write("Porcentagem de desconto: "); double porcentagemDesconto = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);

				ItemPedido item = new ItemPedido(qte,porcentagemDesconto,produto,pedido);
				pedido.itens.Add(item);

			}
			Program.pedidos.Add(pedido);
		}

		public static void mostrarPedido(){
			Console.Write("Digite o código do pedido: "); int codigoPedido = int.Parse(Console.ReadLine());
			int pos = Program.pedidos.FindIndex(x => x.codigo == codigoPedido);
			if (pos == -1)
			{
				throw new ModelException("Código nao encontrado: " + codigoPedido);
			}
			Console.WriteLine(Program.pedidos[pos].ToString());
		}
    }
}
