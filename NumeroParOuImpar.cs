
//  1– Desenvolva um algoritmo que solicite a entrada de um número e calcule se o número é par ou ímpar

namespace ParouImpar{
    class Program{
        static void Main(string[] args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            Console.Write("Digite um número:");
            int numero = Convert.ToInt32(Console.ReadLine());

            if (numero % 2 ==0){

                Console.WriteLine("O número é par");
               
            } else
            
            {
                Console.WriteLine("O Número e Impar");
            }
        }
    }
}
