using System;
using System.Collections.Generic;

namespace Views
{
    public class Locacao
    {
        public static void CriarLocacao()
        {
            int opt;
            int optLeve;
            int optPesado;
            List<Model.VeiculoLeve> VeiculosLeves = new List<Model.VeiculoLeve>();
            List<Model.VeiculoPesado> VeiculosPesados = new List<Model.VeiculoPesado>();
            Console.WriteLine("Informe o Id do Cliente: ");
            string IdCliente = Console.ReadLine();
            Console.WriteLine("Informe a Data da Locação: ");
            string DataLocacao = Console.ReadLine();

            Console.WriteLine("Deseja locar veículos leves? [1] Sim");
            opt = Convert.ToInt32(Console.ReadLine());
            if (opt == 1)
            {
                do
                {
                    Console.WriteLine("Informe o Id do Veículo Leve: ");
                    try
                    {
                        int IdVeiculoLeve = Convert.ToInt32(Console.ReadLine());
                        Model.VeiculoLeve veiculo = Controller.VeiculoLeve.GetVeiculoLeve(IdVeiculoLeve);
                        VeiculosLeves.Add(veiculo);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    Console.WriteLine("Deseja locar outro veículo? [1] Sim");
                    optLeve = Convert.ToInt32(Console.ReadLine());
                } while (optLeve == 1);
            }
            Console.WriteLine("Deleja locar veículos pesados? [1] Sim");
            opt = Convert.ToInt32(Console.ReadLine());
            if (opt == 1)
            {
                do
                {
                    Console.WriteLine("Informe o Id do Veículo Pesado: ");
                    try
                    {
                        int IdVeiculoPesado = Convert.ToInt32(Console.ReadLine());
                        Model.VeiculoPesado veiculo = Controller.VeiculoPesado.GetVeiculoPesado(IdVeiculoPesado);
                        VeiculosPesados.Add(veiculo);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    Console.WriteLine("Deseja informar outro veículo? [1] Sim");
                    optPesado = Convert.ToInt32(Console.ReadLine());
                } while (optPesado == 1);
            }

            try
            {
                Controller.Locacao.NovaLocacao(IdCliente, DataLocacao, VeiculosLeves, VeiculosPesados);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Informações digitadas são incorretas: {e.Message}");
            }
        }

        public static void ListarLocacao()
        {
            foreach (Model.Locacao locacao in Controller.Locacao.GetLocacao())
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine(locacao);
            }
            Console.WriteLine("---------------------------\n");
        }
    }
}