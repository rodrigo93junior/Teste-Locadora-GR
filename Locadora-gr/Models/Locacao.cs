using System;
using System.Collections.Generic;
using System.Linq;
using Repositorio;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class Locacao {
        public int Id {set; get;} // Identificador Único (ID)
        public int IdCliente { set; get; } // Identificador Único do Cliente
        [NotMapped]
        public virtual Cliente Cliente { set; get; } // Cliente
        public DateTime DataLocacao { set; get; }// Data de Locação

        public Locacao(){

        }
        public Locacao(
            Cliente Cliente, 
            DateTime DataLocacao,
            List<VeiculoLeve> VeiculosLeves,
            List<VeiculoPesado> VeiculosPesados
            
        ) {
            //this.Id = Context.locacoes.Count;
            Context db = new Context();
            this.IdCliente = Cliente.Id;
            this.Cliente = Cliente;
            this.DataLocacao = DataLocacao;
            db.Locacoes.Add (this);
            db.SaveChanges();

            foreach (VeiculoLeve veiculo in VeiculosLeves) {
                LocacaoVeiculoLeve locacaoVeiculoLeve = new  LocacaoVeiculoLeve (this, veiculo);
            }

            foreach (VeiculoPesado veiculo in VeiculosPesados) {
                LocacaoVeiculoPesado locacaoVeiculoPesado = new  LocacaoVeiculoPesado (this, veiculo);
            }           
        }
        public double GetPrecoLocacao() {
            double total = 0;

            foreach (LocacaoVeiculoLeve veiculo in LocacaoVeiculoLeve.GetVeiculos(this.Id)) {
                total += veiculo.VeiculoLeve.Preco;
            }

            total += LocacaoVeiculoLeve.GetTotal(this.Id);
            
            return total;
        }

        public DateTime GetDiaRetorno() {
            int DiasRetorno = this.Cliente.DiasRetorno;

            return this.DataLocacao.AddDays(DiasRetorno);
        }

        public override string ToString()
        {

            string Print = String.Format (
                "Data da Locação: {0:d} - Data da Devolução: {1:d} - Valor: {2:C}\nCliente: {3}",
                this.DataLocacao,
                this.GetDiaRetorno(),
                this.GetHashCode(),
                this.Cliente
            );
            Print += "\nVeículos Leves Locados: ";
            if (LocacaoVeiculoLeve.GetCount(this.Id) > 0) {
                foreach (LocacaoVeiculoLeve veiculo in LocacaoVeiculoLeve.GetVeiculos(this.Id)) {
                    Print += "\n    " + veiculo.VeiculoLeve;
                }
            } else {
                Print += "\n    Nada Consta";
            }

            Print += "\nVeículos Pesados Locados: ";
            if (LocacaoVeiculoPesado.GetCount(this.Id) > 0) {
                foreach (LocacaoVeiculoPesado veiculo in LocacaoVeiculoPesado.GetVeiculos(this.Id)) {
                    Print += "\n    " + veiculo.VeiculoPesado;
                }
            } else {
                Print += "\n    Nada Consta";
            }

            return Print;
        }

        public override bool Equals (object obj) {
            if (obj == null) {
                return false;
            }
            if (obj.GetType () != this.GetType ()) {
                return false;
            }
            Locacao locacao = (Locacao) obj;
            return this.GetHashCode () == locacao.GetHashCode ();
        }

        public override int GetHashCode () {
            return HashCode.Combine (this.Id);
        }

        public static IEnumerable<Locacao> GetLocacao () {
            Context db = new Context();
            return from Locacao in db.Locacoes select Locacao;
        }

        public static int GetCount(int IdCliente) {
            Context db = new Context();
            return (from locacao in db.Locacoes where locacao.IdCliente == IdCliente select locacao).Count();
        }
        
        public static Locacao GetLocacao(int Id)
        {

            Context db = new Context();
            IEnumerable<Locacao> query = from locacao in db.Locacoes where locacao.Id == Id select locacao;

            return query.First();

        }
        public static Locacao AtualizarLocacoes(
            Locacao locacao
        )
        {
            Context db = new Context();
            db.Locacoes.Update(locacao);
            db.SaveChanges();
            return locacao;
        }
        public static void RemoverLocacao(int Id) {
            Locacao locacao = GetLocacao(Id);
            Context db = new Context();
            db.Locacoes.Remove(locacao);
            db.SaveChanges();
        }
        public static int GetCount()
        {
            return GetLocacao().Count();
        }
    }
}