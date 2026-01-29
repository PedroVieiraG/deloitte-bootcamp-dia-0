namespace CadastroDeUsuario
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Bem-vindo ao sistema de cadastro de usuários!\n");
            string name = ObterNome();
            int age = ObterIdade();
            ExibirCadastro(name, age);
        }

        private static string ObterNome()
        {
            while (true)
            {
                Console.WriteLine("Digite o nome de usuário");
                string input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input;
                }
                Console.WriteLine("[Erro]: O nome não pode estar vazio. Tente novamente");
            }
        }
        private static string ObterIdade()
        {
            while (true)
            {
                Console.WriteLine("Digite o nome de usuário");
                string input = Console.ReadLine();

                if (int.TryParse(input,out int age) && age > 0 && age < 120)
                {
                    return age;
                }
                Console.WriteLine("[Erro]: A idade de ser maior que zero e menor que 120. Tente novamente");
            }
        
        }
         private static void ExibirCadastro(string name, int age)
        {
            Console.WriteLine("\n-----------------------------------");
            Console.WriteLine("Cadastro realizado com sucesso!");
            Console.WriteLine($"Nome: {name}");
            Console.WriteLine($"Idade: {age} anos");
            Console.WriteLine("-----------------------------------\n");
        }
    }
}