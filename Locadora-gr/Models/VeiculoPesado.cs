using System;
using System.Collections.Generic;
using System.Linq;
using Repositorio;

namespace Model
{
    public class VeiculoPesado : Veiculo
    {
        public int Id { set; get; }
        public string Restricoes { set; get; }

        public VeiculoPesado() : base()
        {

        }
        public VeiculoPesado(
            string Marca,
            string Modelo,
            int Ano,
            double Preco,
            string Restricoes
        ) : base(Marca, Modelo, Ano, Preco)
        {
            //this.Id = Context.veiculosPesados.Count;
            Context db = new Context();
            this.Restricoes = Restricoes;

            db.VeiculosPesados.Add(this);
            db.SaveChanges();

        }

        public override string ToString()
        {
            return "Id: " + this.Id + " - " + base.ToString() + " - Restrições: " + this.Restricoes;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            VeiculoPesado VeiculoPesado = (VeiculoPesado)obj;
            return this.GetHashCode() == VeiculoPesado.GetHashCode();
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Id);
        }

        public static IEnumerable<VeiculoPesado> GetVeiculosPesados()
        {
            Context db = new Context();
            return from VeiculoPesado in db.VeiculosPesados select VeiculoPesado;
        }

        public static int GetCount()
        {
            return GetVeiculosPesados().Count();
        }

        public static VeiculoPesado GetVeiculoPesado(int Id)
        {
            Context db = new Context();
            return (
                from veiculoPesado in db.VeiculosPesados
                where veiculoPesado.Id == Id
                select veiculoPesado
            ).First();
        }
        public static VeiculoPesado AtualizarVeiculoPesado(
            VeiculoPesado veiculoPesado
        )
        {
            Context db = new Context();
            db.VeiculosPesados.Update(veiculoPesado);
            db.SaveChanges();
            return veiculoPesado;
        }
         public static void RemoverVeiculoPesado(int Id) {
            VeiculoPesado veiculoPesado = GetVeiculoPesado(Id);
            Context db = new Context();
            db.VeiculosPesados.Remove(veiculoPesado);
            db.SaveChanges();
        }
    }
}