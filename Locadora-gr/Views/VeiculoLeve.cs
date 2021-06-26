using System;

namespace Views
{
    public class VeiculoLeve
    {
        public static void AdicionarVeiculoLeve()
        {
            Console.WriteLine("Veículo Leve Selecionado! ");
            Console.WriteLine("Informe a Marca: ");
            string Marca = Console.ReadLine();
            Console.WriteLine("Informe o Modelo: ");
            string Modelo = Console.ReadLine();
            Console.WriteLine("Informe o Ano: ");
            string Ano = Console.ReadLine();
            Console.WriteLine("Informe o Preço de Locação: ");
            string Preco = Console.ReadLine();
            Console.WriteLine("Informe a Cor do Veículo: ");
            string Cor = Console.ReadLine();

            Controller.VeiculoLeve.AdicionarVeiculoLeve(Marca, Modelo, Ano, Preco, Cor);
        }
        public static void ListarVeiculosLeves()
        {
            foreach (Model.VeiculoLeve veiculo in Controller.VeiculoLeve.GetVeiculosLeves())
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine(veiculo);
            }
            Console.WriteLine("---------------------------\n");
        }
    }
}