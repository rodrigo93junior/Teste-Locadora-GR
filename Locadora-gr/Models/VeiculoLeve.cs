using System;
using System.Collections.Generic;
using System.Linq;
using Repositorio;

namespace Model
{
    public class VeiculoLeve : Veiculo
    {
        public int Id { set; get; }
        public string Cor { set; get; }

        public VeiculoLeve() : base()
        {

        }
        public VeiculoLeve(
            string Marca,
            string Modelo,
            int Ano,
            double Preco,
            string Cor
        ) : base(Marca, Modelo, Ano, Preco)
        {
            //this.Id = Context.veiculosLeves.Count;
            Context db = new Context();
            this.Cor = Cor;

            db.VeiculosLeves.Add(this);
            db.SaveChanges();
        }

        public override string ToString()
        {
            return "Id: " + this.Id + "\n" + base.ToString() + "\nCor: " + this.Cor;
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
            VeiculoLeve VeiculoLeve = (VeiculoLeve)obj;
            return this.GetHashCode() == VeiculoLeve.GetHashCode();
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Id);
        }
        public static IEnumerable<VeiculoLeve> GetVeiculosLeves()
        {
            Context db = new Context();
            return from VeiculoLeve in db.VeiculosLeves select VeiculoLeve;
        }
        public static int GetCount()
        {
            return GetVeiculosLeves().Count();
        }

        public static VeiculoLeve GetVeiculoLeve(int Id)
        {
            Context db = new Context();
            return (
                from VeiculoLeve in db.VeiculosLeves
                where VeiculoLeve.Id == Id
                select VeiculoLeve
            ).First();
        }
        public static VeiculoLeve AtualizarVeiculoLeve(
            VeiculoLeve veiculoLeve
        )
        {
            Context db = new Context();
            db.VeiculosLeves.Update(veiculoLeve);
            db.SaveChanges();
            return veiculoLeve;
        }
        public static void RemoverVeiculoLeve(int Id) {
            VeiculoLeve veiculoLeve = GetVeiculoLeve(Id);
            Context db = new Context();
            db.VeiculosLeves.Remove(veiculoLeve);
            db.SaveChanges();
        }
    }
}