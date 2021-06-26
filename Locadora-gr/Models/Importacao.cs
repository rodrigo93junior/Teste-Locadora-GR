using System;

namespace Model {
    public static class Importacao {
        public static void BDImportacao () {
            new Cliente ("Rodrigo Moreira", Convert.ToDateTime ("20/12/1993"), "635.787.555-00","Masculino", 5);
            new Cliente ("Lais Silva", Convert.ToDateTime ("20/08/1995"), "365.478.358-22","Feminino", 10);
            new Cliente ("Leticia Fagundes", Convert.ToDateTime ("08/07/2000"), "324.784.658-03","Feminino", 10);
            new Cliente ("Antonio Silva", Convert.ToDateTime ("08/03/1998"), "654.878.965-08","Masculino", 16);
            new Cliente ("Joaquim Pietro", Convert.ToDateTime ("03/09/1988"), "128.007.389-01","Masculino", 30);

            new VeiculoLeve ("Chevrolet", "Onix", 2019, 150.0, "Preta");
            new VeiculoLeve ("Chevrolet", "Onix Plus", 2019, 200.0, "Preta");
            new VeiculoLeve ("Ford", "Ka", 2019, 120.0, "Vermelho");
            new VeiculoLeve ("Renault", "Kwid", 2019, 150.0, "Branco");
            new VeiculoLeve ("Hyundai", "HB20", 2019, 150.0, "Preta");
            new VeiculoLeve ("Volkswagen", "Gol", 2019, 120.0, "Prata");
            new VeiculoLeve ("Volkswagen", "Polo", 2019, 200.0, "Prata");
            new VeiculoLeve ("Fiat", "Argo", 2019, 200.0, "Vermelho");
            new VeiculoLeve ("Jeep", "Renegade", 2019, 300.0, "Laranja");
            new VeiculoLeve ("Fiat", "Mobi", 2019, 120.0, "Verde");

            new VeiculoPesado ("Volvo", "FH540", 2019, 350.0, "Carteira C");
            new VeiculoPesado ("Volvo", "FH 460", 2019, 300.0, "Carteira D");
            new VeiculoPesado ("DAF", "XF105", 2019, 400.0, "Carteira C");
            new VeiculoPesado ("Scania", "R450", 2019, 250.0, "Carteira C");
            new VeiculoPesado ("Mercedez-Benz", "Actros 2651 ", 2019, 450.0, "Carteira D");
            new VeiculoPesado ("Scania", "R500", 2019, 200.0, "Carteira C");
            new VeiculoPesado ("Mercedez-Benz", "Axor 3344", 2019, 400.0, "Carteira C");
            new VeiculoPesado ("Mercedez-Benz", "Axor 2544", 2019, 450.0, "Carteira D");
            new VeiculoPesado ("Mercedez-Benz", "Actros 2546", 2019, 450.0, "Carteira C");
            new VeiculoPesado ("MAN", "TGX 28.440", 2019, 150.0, "Carteira D");
        }
    }
}
