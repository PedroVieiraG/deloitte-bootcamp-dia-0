using System;
using System.Collections.Generic;
using System.Globalization;
class Program
{
    static void Main()
    {
        List<Produto> estoque = new List<Produto>();
        int opcoes;

        do
        {
            Console.Clear();
            Console.WriteLine("=== CONTROLE DE ESTOQUE ===");
            Console.WriteLine("1 - Adicionar produto");
            Console.WriteLine("2 - Listar produtos");
            Console.WriteLine("3 - Editar produto");
            Console.WriteLine("4 - Excluir produto");
            Console.WriteLine("0 - Sair");
            Console.Write("\nEscolha uma opção: ");

            if (!int.TryParse(Console.ReadLine(), out opcoes)) opcoes = -1;

            try
            {
                switch (opcoes)
                {
                    case 1:
                        AdicionarProduto(estoque);
                        break;
                    case 2:
                        ListarProdutos(estoque);
                        break;
                    case 3:
                        EditarProduto(estoque);
                        break;
                    case 4:
                        ExcluirProduto(estoque);
                        break;
                }
            }               
            catch (Exception ex)
            {
                Console.WriteLine($"\n[ERRO] {ex.Message}");
            }

            if (opcoes != 0)
            {
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }

        } while (opcoes != 0);
    }
    
    static void AdicionarProduto(List<Produto> estoque)
    {
        Console.Write("Nome: ");
        string nome = Console.ReadLine();

        Console.Write("Preço: ");
        double preco = double.Parse(Console.ReadLine());

        Console.Write("Quantidade: ");
        int quantidade = int.Parse(Console.ReadLine());

        estoque.Add(new Produto(nome, preco, quantidade));
        Console.WriteLine("\n[SUCESSO] Produto adicionado!");
    }

    static void ListarProdutos(List<Produto> estoque)
    {
        Console.WriteLine("\n=== PRODUTOS CADASTRADOS ===");

        if (estoque.Count == 0)
        {
            Console.WriteLine("Nenhum produto cadastrado.");
            return;
        }

        for (int i = 0; i < estoque.Count; i++)
        {
            Console.WriteLine($"{i + 1} - {estoque[i]}");
        }
    }

    static void EditarProduto(List<Produto> estoque)
    {
        ListarProdutos(estoque);
        Console.Write("\nDigite o número do produto para editar: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index < 0 || index >= estoque.Count)
            throw new Exception("Produto inválido.");

        Console.Write("Novo nome: ");
        string nome = Console.ReadLine();

        Console.Write("Novo preço: ");
        double preco = double.Parse(Console.ReadLine());

        Console.Write("Nova quantidade: ");
        int quantidade = int.Parse(Console.ReadLine());

        estoque[index].Atualizar(nome, preco, quantidade);
        Console.WriteLine("\n[SUCESSO] Produto atualizado!");
    }

    static void ExcluirProduto(List<Produto> estoque)
    {
        ListarProdutos(estoque);
        Console.Write("\nDigite o número do produto para excluir: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index < 0 || index >= estoque.Count)
            throw new Exception("Produto inválido.");

        estoque.RemoveAt(index);
        Console.WriteLine("\n[SUCESSO] Produto removido!");
    }
}
