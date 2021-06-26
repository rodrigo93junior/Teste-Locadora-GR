using System;

namespace Model
{
    public class Veiculo
    {
        public string Marca { set; get; } //Marca do Veículo
        public string Modelo { set; get; } //Modelo do Veículo
        public int Ano { set; get; } //Ano do Veículo
        public double Preco { set; get; } //Preço do Veículo

        public Veiculo()
        {

        }
        protected Veiculo(
            string Marca,
            string Modelo,
            int Ano,
            double Preco
        )
        {
            this.Marca = Marca;
            this.Modelo = Modelo;
            this.Ano = Ano;
            this.Preco = Preco;
        }
        public override string ToString()
        {
            return "Marca: " + this.Marca +
                "\n Modelo: " + this.Modelo +
                "\nAno: " + this.Ano +
                "\nPreço de Locação: " + String.Format("{0:C}", this.Preco);
        }
    }
}