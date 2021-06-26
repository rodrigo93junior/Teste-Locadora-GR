using System;
using System.Collections.Generic;

namespace Views
{
    public class Cliente
    {
        public static void NovoCliente()
        {
            Console.WriteLine("Digite o nome da pessoa: ");
            string Nome = Console.ReadLine();
            Console.WriteLine("Digite a Data de Nascimento da pessoa: ");
            string DataNascimento = Console.ReadLine();
            Console.WriteLine("Digite o CPF da pessoa: ");
            string Cpf = Console.ReadLine();
            Console.WriteLine("Digite o Genero: ");
            string Genero = Console.ReadLine();
            Console.WriteLine("Digite o Número de Dias para Devolução: ");
            string DiasRetorno = Console.ReadLine();
            try
            {
                Controller.Cliente.NovoCliente(Nome, DataNascimento, Cpf, Genero, DiasRetorno);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Informações digitadas são incorretas: {e.Message}");
            }
        }


        public static void AtualizerClientes()
        {
            Model.Cliente cliente;
            try
            {
                Console.WriteLine("insira o ID do Cliente: ");
                string Id = Console.ReadLine();
                cliente = Controller.Cliente.GetCliente(Convert.ToInt32(Id));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Digite a opção desejada:");
            Console.WriteLine(" 1 - Alterar Nome do Cliente.");
            Console.WriteLine(" 2 - Alterar CPF do Cliente.");
            string opcao = Console.ReadLine();
            Console.WriteLine(" Digite a informação a ser alterada: ");
            string informacao = Console.ReadLine();
        }
        public static void DeleteCliente()
        {

        }
        public static void ListarClientes()
        {
            foreach (Model.Cliente cliente in Controller.Cliente.ListarClientes())
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine(cliente);
            }
            Console.WriteLine("---------------------------\n");
        }
    }
}