using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Controller
{
    public class Locacao
    {
        public static Model.Locacao NovaLocacao(
            string IdCliente,
            string StringDataLocacao,
            List<Model.VeiculoLeve> VeiculosLeves,
            List<Model.VeiculoPesado> VeiculosPesados
        )
        {
            Model.Cliente Cliente = Controller.Cliente
                .GetCliente(Convert.ToInt32(IdCliente));

            DateTime DataLocacao;

            try
            {
                DataLocacao = Convert.ToDateTime(StringDataLocacao);
            }
            catch
            {
                DataLocacao = DateTime.Now;
            }

            if (DataLocacao > DateTime.Now)
            {
                throw new Exception("Data de Locação não pode ser maior que a data atual");
            }

            return new Model.Locacao(Cliente, DataLocacao, VeiculosLeves, VeiculosPesados);
        }
        public static IEnumerable<Model.Locacao> ListarLocacoes()
        {
            return Model.Locacao.GetLocacao();
        }

        public static IEnumerable<Model.Locacao> GetLocacao()
        {
            return Model.Locacao.GetLocacao();
        }
        public static Model.Locacao GetLocacao(int Id)
        {
            int ListarVeiculosLeves = Model.Locacao.GetCount();

            if (Id < 0 || ListarVeiculosLeves < Id)
            {
                throw new Exception("Id informado é inválido.");
            }

            return Model.Locacao.GetLocacao(Id);
        }
        public static Model.Locacao AtualizarLocacao(
            Model.Locacao locacao
        )
        {
            return Model.Locacao.AtualizarLocacoes(locacao);
        }
        public static void RemoverLocacao(string StringId)
        {
            int Id = Convert.ToInt32(StringId);
            try
            {
                Model.Locacao.RemoverLocacao(Id);
            }
            catch
            {
                throw new Exception("Não foi permitido concluir a exclusão ou ID inválido ");
            }
        }
    }
}