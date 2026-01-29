public class Produto
{
    public string Nome { get; private set; }
    public double Preco { get; private set; }
    public int Quantidade { get; private set; }

    public Produto(string nome, double preco, int quantidade)
    {
        Validar(nome, preco, quantidade);

        Nome = nome;
        Preco = preco;
        Quantidade = quantidade;
    }

    public void Atualizar(string nome, double preco, int quantidade)
    {
        Validar(nome, preco, quantidade);

        Nome = nome;
        Preco = preco;
        Quantidade = quantidade;
    }

    private void Validar(string nome, double preco, int quantidade)
    {
        
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("O nome não pode ser vazio.");
        
        if (double.TryParse(nome, out _))
            throw new ArgumentException("O nome não pode ser um número.");

        if (preco <= 0)
            throw new ArgumentException("O preço deve ser maior que zero.");

        if (quantidade < 0)
            throw new ArgumentException("A quantidade não pode ser negativa.");
    }

    public override string ToString()
    {
        return $"Produto: {Nome} | Preço: {Preco:C} | Estoque: {Quantidade}";
    }
}
