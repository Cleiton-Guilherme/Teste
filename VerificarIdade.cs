// 3 – Desenvolva um algoritmo que solicite a entrada da idade de um determinado usuário, 
//se for menor que 18 anos exiba na cor vermelha “Sem permissão”, caso seja maior ou igual a 18 anos 
//exiba na cor verde “Permissão concedida”


namespace VerificacaoIdade
{

    class Program
    {
        static void Main(string[] args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            Console.Write("Digite a sua Idade: ");
            int idade = Convert.ToInt32(Console.ReadLine());

            if (idade < 18)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sem Permissão");

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Permissão concedida");
            }

            //Restaura a cor padrão
            Console.ResetColor();
        }
    }
}