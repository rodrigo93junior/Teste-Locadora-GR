using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Controller
{
    public static class Cliente
    {

        public static Model.Cliente NovoCliente(
            string Nome,
            string StringDataNascimento,
            string Cpf,
            string Genero,
            string DiasRetorno
        )
        {

            Regex rgx = new Regex("^\\d{3}\\.\\d{3}\\.\\d{3}-\\d{2}$");
            if (!rgx.IsMatch(Cpf))
            {
                throw new Exception("CPF Inválido");
            }

            DateTime DataNascimento;

            try
            {
                DataNascimento = Convert.ToDateTime(StringDataNascimento);
            }
            catch
            {
                throw new Exception("Data de Nascimento Inválida");
            }

            return new Model.Cliente(
                Nome,
                Convert.ToDateTime(DataNascimento),
                Cpf,
                Genero,
                Convert.ToInt32(DiasRetorno)
            );
        }

        public static Model.Cliente AtualizarClientes(
            Model.Cliente cliente,
            string stringValor,
            string stringCampo
        )
        {
            int Campo = Convert.ToInt32(stringCampo);
            switch (Campo)
            {
                case 1:
                    return Model.Cliente.AtualizarClientes(cliente, stringValor, stringCampo);

                case 2:
                    Regex rgx = new Regex("^\\d{3}\\.\\d{3}\\.\\d{3}-\\d{2}$");
                    if (!rgx.IsMatch(stringValor))
                    {
                        throw new Exception("C.P.F. Inválido");
                    }
                    return Model.Cliente.AtualizarClientes(cliente, stringValor, stringCampo);

                default:
                    throw new Exception("Operação inválida");
            }
        }

        public static Model.Cliente AtualizarClientes(
            Model.Cliente cliente
        )
        {
            return Model.Cliente.AtualizarClientes(cliente);
        }


        public static IEnumerable<Model.Cliente> ListarClientes()
        {
            return Model.Cliente.GetClientes();
        }

        public static Model.Cliente GetCliente(int Id)
        {
            int ListLenght = Model.Cliente.GetCount();

            if (Id < 0 || ListLenght < Id)
            {
                throw new Exception("Id informado é inválido.");
            }

            return Model.Cliente.GetCliente(Id);
        }
        public static void RemoverClientes(string StringId)
        {
            int Id = Convert.ToInt32(StringId);
            try
            {
                Model.Cliente.RemoverClientes(Id);
            }
            catch
            {
                throw new Exception("Não foi permitido concluir a exclusão ou ID inválido ");
            }
        }
    }
}