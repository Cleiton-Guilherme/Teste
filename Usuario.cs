// 4 - Desenvolva um algoritmo que solicite a entrada de nome, e-mail, telefone e RG de um determinado usuário e grave em um arquivo de texto.
// Exiba as informações na tela a partir do arquivo de texto gerado



// Solicitação de Informações de Usúario

namespace GravarEExibirInformacoes
{
    internal class Program {

        static void Main(string[] args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            Console.Write("Digite o nome: ");
            string nome = " "; Console.ReadLine();

            Console.Write("Digite o E-mail: ");
            string email = " "; Console.ReadLine();

            Console.Write("Digite o telefone: ");
            string telefone =  " "; Console.ReadLine();

            Console.Write("Digite o RG: ");
            string rg = " "; Console.ReadLine();


            // Grava as Informações no arquivo de Texto
            GravarInformacoes(nome, email, telefone, rg);
            

            // Lê e exibe as Informações do Arquivo de texto
            ExibirInformacoesDoArquivo();

            Console.WriteLine("Informaçoes gravadas e Exibidas Com Sucesso!");
        }

        static void GravarInformacoes(string nome, string email, string telefone, string rg)

        {
            string filePath = "informacoes.txt";

            using StreamWriter writer = new(filePath);
            writer.WriteLine($"Nome: {nome}");
            writer.WriteLine($"E-mail: {email}");
            writer.WriteLine($"Telefone: {telefone}");
            writer.WriteLine($"RG: {rg}");
        }

        static void ExibirInformacoesDoArquivo()
        {
            string filePath = "Informacoes.txt";

            if (File.Exists(filePath))
            {
                Console.WriteLine("\nInformações do Arquivo: ");
                using StreamReader reader = new(filePath);
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
            else
            {
                Console.WriteLine("\nArquivo de Informações não encontrado");
            }
        }
    }
}

