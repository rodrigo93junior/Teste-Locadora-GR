using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using Views.Lib;

namespace Views
{

    public class AtualizarVeiculoPesado : Form
    {
        LibTituloLabel lblTitulo;
        LibLabel lblId;
        LibTextBox id;
        LibComboBox combo;
        LibButton botaoSalvar;
        LibButton btnCancelar;
        public AtualizarVeiculoPesado()
        {
            string id = "";
            IEnumerable<Model.VeiculoPesado> veiculosPesados = Controller.VeiculoPesado.ListarVeiculosPesados();
            List<string> listaVeiculosPesados = new List<string>();
            foreach (Model.VeiculoPesado item in veiculosPesados)
            {
                listaVeiculosPesados.Add($"{item.Id} - {item.Marca} - {item.Modelo} - {item.Ano} - {item.Preco} - {item.Restricoes}");
            }
            new InputBox(
                "Alterar o Veiculo Pesado",
                "Informe o ID do Veiculo",
                listaVeiculosPesados,
                ref id
            );
            if (!id.Equals(""))
            {
                CadastrarVeiculoPesado cadastrarVeiculoPesado = new CadastrarVeiculoPesado(id);
                cadastrarVeiculoPesado.Show();
            }
            botaoSalvar = new LibButton("Salvar", new Point(100, 300), new Size(100, 40));
            botaoSalvar.Click += new EventHandler(this.botaoSalvarVeiculo);

            btnCancelar = new LibButton("Cancelar", new Point(200, 300), new Size(100, 40));
            btnCancelar.Click += new EventHandler(this.botaoCancelar);

            this.Controls.Add(botaoSalvar);
            this.Controls.Add(btnCancelar);
        }
        private void botaoSalvarVeiculo(object sender, EventArgs e)
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
                CadastrarVeiculoPesado cadastro = new CadastrarVeiculoPesado(id);
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