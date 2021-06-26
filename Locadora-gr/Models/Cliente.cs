using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Repositorio;

namespace Model
{
    public class Cliente
    {
        public int Id { set; get; } // Identificador Único (ID)
        [Required]
        public string Nome { set; get; } // Nome
        public DateTime DataNascimento { set; get; } // Data de Nascimento
        public string Cpf { set; get; } // CPF
        public string Genero { set; get; } // Genero
        public int DiasRetorno { set; get; } // Dias para Devolução

        public Cliente()
        {

        }
        public Cliente(
            string Nome,
            DateTime DataNascimento,
            string Cpf,
            string Genero,
            int DiasRetorno
        )
        {
            this.Nome = Nome;
            this.DataNascimento = DataNascimento;
            this.Cpf = Cpf;
            this.DiasRetorno = DiasRetorno;
            
            if (VerificaCpf())
            {
                Context db = new Context();
                db.Clientes.Add(this);
                db.SaveChanges();
            }
        }

        public static Cliente AtualizarClientes(
            Cliente cliente,
            string stringValor,
            string stringCampo
        )
        {
            int Campo = Convert.ToInt32(stringCampo);
            switch (Campo)
            {
                case 1:
                    cliente.Nome = stringValor;
                    break;
                case 2:
                    cliente.Cpf = stringValor;
                    break;

            }
            Context db = new Context();
            db.Clientes.Update(cliente);
            db.SaveChanges();
            return cliente;
        }

        public static Cliente AtualizarClientes(
            Cliente cliente
        )
        {
            Context db = new Context();
            db.Clientes.Update(cliente);
            db.SaveChanges();
            return cliente;
        }
        public static void RemoverClientes(int Id)
        {
            Cliente cliente = GetCliente(Id);
            Context db = new Context();
            db.Clientes.Remove(cliente);
            db.SaveChanges();
        }

        public override string ToString()
        {
            return String.Format(
                "Id: {0} - Nome: {1} - Data de Nascimento: {2:d}",
                this.Id,
                this.Nome,
                this.DataNascimento
            );
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
            Cliente Cliente = (Cliente)obj;
            return this.GetHashCode() == Cliente.GetHashCode();
        }

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = (int)2166136261;
                hash = (hash * 16777619) ^ this.Id.GetHashCode();
                return hash;
            }
        }

        public static IEnumerable<Cliente> GetClientes()
        {
            Context db = new Context();
            return from cliente in db.Clientes select cliente;
        }

        public static int GetCount()
        {
            return GetClientes().Count();
        }
        /*
        public static IEnumerable<Cliente> GetClientes()
        {
            return from cliente in Context.Clientes select cliente;
        }

        
        public static List<Cliente> ArrayClientes()
        {
            return (from cliente in Context.Clientes select cliente)
                .ToList();
        }
        */
        public static void AddCliente(Cliente cliente)
        {
            Context db = new Context();
            db.Clientes.Add(cliente);
        }

        public static Cliente GetCliente(int Id)
        {
            Context db = new Context();
            IEnumerable<Cliente> query = from cliente in db.Clientes where cliente.Id == Id select cliente;

            return query.First();

        }
        public bool VerificaNome(string pNome)
        {
            if (String.IsNullOrEmpty(pNome))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool VerificaDataNascimento(string pDataNascimento)
        {
            if (Convert.ToDateTime(pDataNascimento) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool VerificaDataNascimento2(string pDataNascimento)
        {
            if (Convert.ToDateTime(pDataNascimento) > DateTime.Now)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool VerificaCpf()
        {
            if (String.IsNullOrEmpty(this.Cpf))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool VerificaGenero(string pGenero)
        {
            if (String.IsNullOrEmpty(pGenero))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool VerificaDiasRetorno(string pDiasRetorno)
        {
            if (String.IsNullOrEmpty(pDiasRetorno))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}