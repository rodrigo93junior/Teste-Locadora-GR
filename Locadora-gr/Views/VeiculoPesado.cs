using System;
using System.Collections.Generic;

namespace Views
{
    public class VeiculoPesado
    {
        public static void AdicionarVeiculoPesado()
        {
            Console.WriteLine("Veículo Pesado Selecionado! ");
            Console.WriteLine("Informe a Marca do Veículo: ");
            string Marca = Console.ReadLine();
            Console.WriteLine("Informe o Modelo do Veículo: ");
            string Modelo = Console.ReadLine();
            Console.WriteLine("Informe o Ano do Veículo: ");
            string Ano = Console.ReadLine();
            Console.WriteLine("Informe o Preço de Locação do Veículo: ");
            string Preco = Console.ReadLine();
            Console.WriteLine("Informe o Restrições do Veículo: ");
            string Restricoes = Console.ReadLine();

            Controller.VeiculoPesado.AdicionarVeiculoPesado(Marca, Modelo, Ano, Preco, Restricoes);
        }

        public static void ListarVeiculosPesados()
        {
            foreach (Model.VeiculoPesado veiculo in Controller.VeiculoPesado.GetVeiculoPesados())
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine(veiculo);
            }
            Console.WriteLine("---------------------------\n");
        }
    }
}
