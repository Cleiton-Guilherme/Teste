using System;
using System.Data.SqlClient;
using System.Globalization;

namespace OrdenacaoVetor
{
    class Program
    {
        static void Main()
        {
            int[] vetor = { 8, 4, 6, 9, 2, 5, 10, 7, 1, 3 };

            Array.Sort(vetor);  // Ordena o vetor em ordem crescente

            string connectionString = "your_connection_string_here";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                for (int i = 0; i < vetor.Length; i++)
                {
                    string numeroExtenso = NumeroPorExtenso(vetor[i]);

                    string insertQuery = "INSERT INTO Tb_Vetor (Numero, Descricao) VALUES (@Numero, @Descricao)";
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Numero", vetor[i]);
                        command.Parameters.AddWithValue("@Descricao", numeroExtenso);

                        command.ExecuteNonQuery();
                    }
                }

                Console.WriteLine("Vetor ordenado e informações salvas na tabela.");
            }
        }

        static string NumeroPorExtenso(int numero)
        {
            CultureInfo cultura = new("pt-BR");
            TextInfo textInfo = cultura.TextInfo;
            return textInfo.ToTitleCase(cultura.NumberFormat.CurrencySpellout(numero).ToLower());
        }
    }
}
