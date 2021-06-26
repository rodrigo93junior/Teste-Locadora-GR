using System;
using System.Collections.Generic;
using System.Linq;
using Repositorio;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class LocacaoVeiculoPesado
    {
        public int Id { set; get; }
        public int IdLocacao { set; get; }
        [NotMapped]
        public virtual Locacao Locacao { set; get; }
        public int IdVeiculoPesado { set; get; }
        [NotMapped]
        public virtual VeiculoPesado VeiculoPesado { set; get; }

        public LocacaoVeiculoPesado()
        {

        }

        public LocacaoVeiculoPesado(
            Locacao Locacao,
            VeiculoPesado VeiculoPesado
        )
        {
            Context db = new Context();
            //this.Id = Context.locacaoVeiculosPesados.Count;
            this.Locacao = Locacao;
            this.IdLocacao = Locacao.Id;
            this.VeiculoPesado = VeiculoPesado;
            this.IdVeiculoPesado = VeiculoPesado.Id;

            db.LocacaoVeiculosPesados.Add(this);
            db.SaveChanges();
        }

        public static IEnumerable<LocacaoVeiculoPesado> GetVeiculos(int IdLocacao)
        {
            Context db = new Context();
            return from veiculo in db.LocacaoVeiculosPesados where veiculo.IdLocacao == IdLocacao select veiculo;
        }
        public static double GetTotal(int IdLocacao)
        {
            Context db = new Context();
            return (
                from veiculo in db.LocacaoVeiculosPesados
                where veiculo.IdLocacao == IdLocacao
                select veiculo.VeiculoPesado.Preco
            ).Sum();
        }
        public static int GetCount(int IdLocacao)
        {
            return GetVeiculos(IdLocacao).Count();
        }
    }
}
