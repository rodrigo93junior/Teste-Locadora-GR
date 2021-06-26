using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using Views.Lib;

namespace Views
{
    public class RemoverLocacao : Form
    {
        private Label lblId = new Label();       //Label cria o "nome" para as caixas de texto

        private LibsComboBox comboId;
        LibButton btnEcluirLocacao;
        LibButton btnCancelar;
        public RemoverLocacao()
        {   
            this.Text = "Remover Locacao";

            lblId = new LibLabel("Selecione a Locação desejada para exclusão:", new Point(20, 30), new Size(250, 15));

            IEnumerable<Model.Locacao> locacoes;
            try
            {
                locacoes = Controller.Locacao.ListarLocacoes();
            }
            catch (Exception e)
            {
                throw e;
            }

            List<string> comboLocacoes = new List<string>();
            foreach (Model.Locacao item in locacoes)
            {
                comboLocacoes.Add($"{item.Id} - {item.DataLocacao}");
            }
            string[] options = comboLocacoes.ToArray();

            comboId = new LibsComboBox(new Point(20, 50), new Size(370, 80), options);


            btnEcluirLocacao = new LibButton("Salvar", new Point(50, 90), new Size(100, 40));
            btnEcluirLocacao.Click += new EventHandler(this.btnConfirmarClick);

            btnCancelar = new LibButton("Cancelar", new Point(150, 90), new Size(100, 40));
            btnCancelar.Click += new EventHandler(this.botaoCancelar);

            this.Size = new Size(420, 180);

            this.Controls.Add(lblId);
            this.Controls.Add(comboId);
            this.Controls.Add(btnEcluirLocacao);
            this.Controls.Add(btnCancelar);
        }

        private void btnConfirmarClick(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Excluir Locacao?", "Excluir Locacao", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                try
                {
                    string comboValue = this.comboId.Text;
                    int pos = comboValue.IndexOf("-");
                    string locacaoId = comboValue.Substring(0, pos - 1);
                    Controller.Locacao.RemoverLocacao(locacaoId);

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