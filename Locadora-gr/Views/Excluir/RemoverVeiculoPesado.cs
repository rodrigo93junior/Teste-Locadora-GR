using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using Views.Lib;

namespace Views
{
    public class RemoverVeiculoPesado : Form
    {
        private Label lblId = new Label();       //Label cria o "nome" para as caixas de texto

        private LibsComboBox comboId;
        LibButton btnEcluirVeiculoPesado;
        LibButton btnCancelar;
        public RemoverVeiculoPesado()
        {   
            this.Text = "Remover Veiculo Pesado";

            lblId = new LibLabel("Selecione o Veículo desejado para exclusão:", new Point(20, 30), new Size(250, 15));

            IEnumerable<Model.VeiculoPesado> veiculosPesados;
            try
            {
                veiculosPesados = Controller.VeiculoPesado.ListarVeiculosPesados();
            }
            catch (Exception e)
            {
                throw e;
            }

            List<string> comboVeiculosPesados = new List<string>();
            foreach (Model.VeiculoPesado item in veiculosPesados)
            {
                comboVeiculosPesados.Add($"{item.Id} - {item.Marca} - {item.Modelo} - {item.Ano} - {item.Preco} - {item.Restricoes}");
            }
            string[] options = comboVeiculosPesados.ToArray();

            comboId = new LibsComboBox(new Point(20, 50), new Size(370, 80), options);


            btnEcluirVeiculoPesado = new LibButton("Salvar", new Point(50, 90), new Size(100, 40));
            btnEcluirVeiculoPesado.Click += new EventHandler(this.btnConfirmarClick);

            btnCancelar = new LibButton("Cancelar", new Point(150, 90), new Size(100, 40));
            btnCancelar.Click += new EventHandler(this.botaoCancelar);

            this.Size = new Size(420, 180);

            this.Controls.Add(lblId);
            this.Controls.Add(comboId);
            this.Controls.Add(btnEcluirVeiculoPesado);
            this.Controls.Add(btnCancelar);
        }

        private void btnConfirmarClick(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Excluir Cliente?", "Excluir cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                try
                {
                    string comboValue = this.comboId.Text; // "1 - João"
                    int pos = comboValue.IndexOf("-"); // 2
                    //  01234567
                    // "1 - João"
                    string veiculoPesadoId = comboValue.Substring(0, pos - 1); // "1 ".Trim() === "1"
                    Controller.VeiculoPesado.RemoverVeiculoPesado(veiculoPesadoId);

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