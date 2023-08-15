
using System.Data.SqlClient;
using System.Globalization;

namespace IMCCalculator
{

    class Programa
    {

        static void Main()
        {
        string connectionString = "db_imcpessoa";

        while (true)
        {
            Console.WriteLine("Escolha uma opção");
            Console.WriteLine("1 - Novo cadastro");
            Console.WriteLine("2 -  consultar cadastros existentes");
            Console.WriteLine("3 - Sair");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice) 
            {
                case 1:
                    Console.Write("Nome: ");
                    String nome = " "; Console.ReadLine();
                    Console.Write("Idade: ");
                    int idade = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Peso (kg): ");
                    double peso = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Altura (m): ");
                    double altura = Convert.ToDouble(Console.ReadLine());

                    double imc = peso / (altura * altura);

                    using (SqlConnection connection = new SqlConnection(connectionString)) 
                    {
                        connection.open();

                        string insertQuery = "INSERT INTO Cadastros (Nome, Idade, Peso, Altura, IMC) VALUES (@Nome, @Idade, @Peso, @Altura, @IMC)";
                        using (SqlCommand command = new SqlCommand(insertQuery, connection)) 
                        {
                            command.Parameters.AddWithValue("@Nome", nome);
                            command.Parameters.AddWithValue("@Idade", idade);
                            command.Parameters.AddWithValue("@Peso", peso);
                            command.Parameters.AddWithValue("@Altura", altura);
                            command.Parameters.AddWithValue("@IMC", imc);


                            command.ExecuteNonQuery();

                        }
                        Console.WriteLine("Cadastro realizado com sucesso!");

                    }
                    break;

                    case 2:
                        using (SqlConnection connection = new SqlConnection(connectionString)) 
                        {
                            connection.Open();

                            string selectQuery = "SELECT Nome, Idade, Peso, Altura, IMC FROM Cadastros";
                            using (SqlCommand command = new SqlCommand(selectQuery, connection)) 
                            {
                                using SqlDataReader reader = command.ExecuteReader();
                                while (reader.Read())
                                {
                                    string nomeConsulta = reader.GetString(0);
                                    string idadeConsulta = reader.GetInt32(1);
                                    string pesoConsulta = reader.GetDouble(2);
                                    string alturaConsulta = reader.GetDouble(3);
                                    string imcConsulta = reader.GetDouble(4);

                                    Console.WriteLine($"Nome: {nomeConsulta}, Idade: {idadeConsulta}, Peso: {pesoConsulta}, Altura: {alturaConsulta}, IMC: {imcConsulta} ");
                                }
                            }
                        }
                        break;

                        case 3:
                            Console.WriteLine("Saindo...");
                            return;

                            default:
                            Console.WriteLine("Opção inválida. Por favor, escolha novamente. ");
                            break;
                }
            }
        }
    }
}