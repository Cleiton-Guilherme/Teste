// 2 –  Desenvolva uma calculadora, onde  será necessário entrar com a operação, primeiro e segundo valor, exiba o resultado na tela

namespace CalculadoraSimples{


class Program {
    static void Main(String[] args)
    {
        if (args is null)
        {
            throw new ArgumentNullException(nameof(args));
        }

        Console.WriteLine("Calculadora Simples");

        Console.Write("Digite a operação (+, -, *, /): ");
        char operacao = Convert.ToChar(Console.Read());

        Console.WriteLine("Digite o primeiro valor: ");
        double primeiroValor = Convert.ToDouble(Console.ReadLine());

        Console.Write("Digite o segundo valor: ");
        double segundoValor = Convert.ToDouble(Console.ReadLine());

        double resultado;
    

        switch (operacao){

            case '+':
                resultado = primeiroValor + segundoValor;
                break;
            case'-':
                resultado = primeiroValor - segundoValor;
                break;
            case '*':
                    resultado = primeiroValor * segundoValor;
                break;
            case '/':
                if (segundoValor != 0) 
                {
                        resultado = primeiroValor / segundoValor;
                }
                else
                {
                     Console.WriteLine("Erro: Divisão por zero não é Permitida. ");
                        return;
                    }
                    break;
                    default:
                        Console.WriteLine("Operação Inválida. ");
                        return;
                        
                        }

        Console.WriteLine($"Resultado: {resultado}");
    }
}

}