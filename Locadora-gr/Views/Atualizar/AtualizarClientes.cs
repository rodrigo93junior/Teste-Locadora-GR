using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using Views.Lib;

namespace Views
{
    
    public class AtualizarClientes : Form
    {
        LibTituloLabel lblTitulo;
        LibLabel lblId;
        LibTextBox id;
        LibComboBox combo;
        LibButton btnSalvarCliente;
        LibButton btnCancelar;
        public AtualizarClientes()
        {
            string id = "";
            IEnumerable<Model.Cliente> clientes = Controller.Cliente.ListarClientes();
            List<string> listaClientes = new List<string>();
            foreach (Model.Cliente item in clientes)
            {
                listaClientes.Add($"{item.Id} - {item.Nome} - {item.DataNascimento} - {item.Cpf} - {item.DiasRetorno}");
            }
            new InputBox(
                "Alterar o Cliente",
                "Informe o ID do Cliente",
                listaClientes,
                ref id
            );
            if(!id.Equals("")) {
                CadastrarCliente cadastrarCliente = new CadastrarCliente(id);
                cadastrarCliente.Show();
            }
            /*this.Text = "Alterar cadastro de Cliente";

            lblTitulo = new LibTituloLabel("Alterar cadastro de Cliente", new Point(180, 10), new Size(180, 40));
            lblId = new LibLabel("Id:", new Point(20, 30), new Size(120, 15));
            id = new LibTextBox(new Point(20, 50), new Size(300, 40));
           
            List<string> listaClientes = new List<string>();
            foreach (Model.Cliente item in clientes)
            {
                listaClientes.Add($"{item.Id} - {item.Nome} - {item.DataNascimento} - {item.Cpf} - {item.DiasRetorno}");
            }

            btnSalvarCliente = new LibButton("Salvar", new Point(100, 300), new Size(100, 40));
            btnSalvarCliente.Click += new EventHandler(this.botaoSalvarCliente);

            btnCancelar = new LibButton("Cancelar", new Point(200, 300), new Size(100, 40));
            btnCancelar.Click += new EventHandler(this.botaoCancelar);
        
            this.Size = new Size(540, 400);
            this.Controls.Add(lblTitulo);
            this.Controls.Add(lblId);
            this.Controls.Add(id);*/
            
        }
         private void botaoSalvarCliente(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "Deseja realmente atualizar este cliente?",
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
                MessageBox.Show("Usuário não cadastrado");
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