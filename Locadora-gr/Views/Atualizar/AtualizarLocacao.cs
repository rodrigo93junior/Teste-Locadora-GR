using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using Views.Lib;

namespace Views
{
    
    public class AtualizarLocacao : Form
    {
        LibTituloLabel lblTitulo;
        LibLabel lblId;
        LibTextBox id;
        LibComboBox combo;
        LibButton btnSalvarCliente;
        LibButton btnCancelar;
        public AtualizarLocacao()
        {
            string id = "";
            IEnumerable<Model.Cliente> clientes = Controller.Cliente.ListarClientes();
            List<string> listaLocacao = new List<string>();
            foreach (Model.Cliente item in clientes)
            {
                listaLocacao.Add($"{item.Id} - {item.Nome} - {item.DataNascimento} - {item.Cpf} - {item.DiasRetorno}");
            }
            new InputBox(
                "Alterar a Locação",
                "Informe o ID da Locação",
                listaLocacao,
                ref id
            );
            if(!id.Equals("")) {
                CadastrarCliente cadastrarCliente = new CadastrarCliente(id);
                cadastrarCliente.Show();
            }
        }
         private void botaoSalvarCliente(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "Deseja realmente atualizar esta locação?",
                "Confirmar Atualização",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (resultado == System.Windows.Forms.DialogResult.Yes)
            {
                string valorCombo = this.combo.Text; 
                int pos = valorCombo.IndexOf("-"); 

                string id = valorCombo.Substring(0, pos - 1);
                CadastrarCliente cadastro = new CadastrarCliente(id);
                cadastro.Show();
               
            }
            else if (resultado == System.Windows.Forms.DialogResult.No)
            {
                MessageBox.Show("Locação não cadastrada");
            }
            else
            {
                MessageBox.Show("Opção Incorreta");
            }
            this.Close();
        }
        private void botaoCancelar(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "Deseja realmente cancelar?",
                "Confirmar Cadastro",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (resultado == System.Windows.Forms.DialogResult.Yes)
            {
                MessageBox.Show("Cliente não cadastrado");
            }
            else
            {
                MessageBox.Show("Opção Invalida!");
            }

            this.Close();
        }
    }
}