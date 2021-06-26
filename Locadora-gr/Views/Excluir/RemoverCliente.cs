using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using Views.Lib;

namespace Views
{
    public class RemoverClientes : Form
    {
        private Label lblId = new Label();       //Label cria o "nome" para as caixas de texto

        private LibsComboBox comboId;
        LibButton btnEcluirCliente;
        LibButton btnCancelar;
        public RemoverClientes()
        {   
            this.Text = "Remover Loca";

            lblId = new LibLabel("Selecione o cliente desejado para exclusão:", new Point(20, 30), new Size(250, 15));

            IEnumerable<Model.Cliente> clientes;
            try
            {
                clientes = Controller.Cliente.ListarClientes();
            }
            catch (Exception e)
            {
                throw e;
            }

            List<string> comboClientes = new List<string>();
            foreach (Model.Cliente item in clientes)
            {
                comboClientes.Add($"{item.Id} - {item.Nome} - {item.DataNascimento} - {item.Cpf}");
            }
            string[] options = comboClientes.ToArray();

            comboId = new LibsComboBox(new Point(20, 50), new Size(370, 80), options);


            btnEcluirCliente = new LibButton("Salvar", new Point(50, 90), new Size(100, 40));
            btnEcluirCliente.Click += new EventHandler(this.btnConfirmarClick);

            btnCancelar = new LibButton("Cancelar", new Point(150, 90), new Size(100, 40));
            btnCancelar.Click += new EventHandler(this.botaoCancelar);

            this.Size = new Size(420, 180);

            this.Controls.Add(lblId);
            this.Controls.Add(comboId);
            this.Controls.Add(btnEcluirCliente);
            this.Controls.Add(btnCancelar);
        }

        private void btnConfirmarClick(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Excluir Cliente?", "Excluir cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                try
                {
                    string comboValue = this.comboId.Text;
                    int pos = comboValue.IndexOf("-");
                    string clienteId = comboValue.Substring(0, pos - 1);
                    Controller.Cliente.RemoverClientes(clienteId);

                }
                catch (Exception error)
                {
                    Console.WriteLine("ErroID" + error.Message);
                }

                MessageBox.Show("Excluído com sucesso!");


            }
            else if (resultado == DialogResult.No)
            {
                MessageBox.Show("Exclusão não concluída!");
            }
            else
            {
                MessageBox.Show("Opção desconhecida!");
            }
            this.Close();

        }

        private void botaoCancelar(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "Deseja realmente cancelar?",
                "Confirmar Exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (resultado == System.Windows.Forms.DialogResult.Yes)
            {
                MessageBox.Show("Cliente não exclído");
            }
            else
            {
                MessageBox.Show("Opção Invalida!");
            }

            this.Close();
        }
    }
}