using System;
using System.Collections.Generic;
using System.Linq;
using Repositorio;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class LocacaoVeiculoLeve
    {
        public int Id { set; get; }
        public int IdLocacao { set; get; }
        [NotMapped]
        public virtual Locacao Locacao { set; get; }
        public int IdVeiculoLeve { set; get; }
        [NotMapped]
        public virtual VeiculoLeve VeiculoLeve { set; get; }

        public LocacaoVeiculoLeve()
        {

        }
        public LocacaoVeiculoLeve(
            Locacao Locacao,
            VeiculoLeve VeiculoLeve
        )
        {
            Context db = new Context();
            this.Locacao = Locacao;
            this.IdLocacao = Locacao.Id;
            this.VeiculoLeve = VeiculoLeve;
            this.IdVeiculoLeve = VeiculoLeve.Id;

            db.LocacaoVeiculosLeves.Add(this);
            db.SaveChanges();
        }
        public static IEnumerable<LocacaoVeiculoLeve> GetVeiculos(int IdLocacao)
        {
            Context db = new Context();
            return from veiculo in db.LocacaoVeiculosLeves where veiculo.IdLocacao == IdLocacao select veiculo;
        }
        public static double GetTotal(int IdLocacao)
        {
            Context db = new Context();
            return (
                from veiculo in db.LocacaoVeiculosLeves
                where veiculo.IdLocacao == IdLocacao
                select veiculo.VeiculoLeve.Preco
            ).Sum();
        }
        public static int GetCount(int IdLocacao)
        {
            return GetVeiculos(IdLocacao).Count();
        }
        
    }
}
