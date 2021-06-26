using System;
using System.Windows.Forms;
using System.Drawing;
using Views.Lib;
using System.Collections.Generic;

namespace Views
{
    public class CadastrarLocacao : Form
    {
        Model.Locacao locacao = new Model.Locacao();
        LibTituloLabel lblTitulo;
        LibLabel lblId;
        LibTextBox idCliente;
        LibLabel lblDataLocacao;
        LibMaskedTextBox dataLocacao;
        LibGroupBox tipo;
        LibRadioButton veiculoLeve;
        LibRadioButton veiculoPesado;
        LibLabel lblModelosVeiculos;
        LibComboBox modelosVeiculosLeves;
        LibComboBox modelosVeiculosPesados;
        Calendario monthCalendar1;
        LibButton btnSalvarCliente;
        LibButton btnCancelar;
        public CadastrarLocacao(string id = "")
        {
            this.Text = "Cadastrar Locação";

            lblTitulo = new LibTituloLabel("Cadastro de Nova Locação", new Point(180, 10), new Size(180, 40));

            lblId = new LibLabel("ID do Cliente:", new Point(20, 30), new Size(120, 15));

            idCliente = new LibTextBox(new Point(20, 50), new Size(300, 40));

            lblDataLocacao = new LibLabel("Data de Locação:", new Point(20, 80), new Size(120, 15));

            dataLocacao = new LibMaskedTextBox(new Point(20, 100), new Size(90, 40), "00/00/0000");

            tipo = new LibGroupBox("Tipo", new Point(20, 150), new Size(300, 50));

            veiculoLeve = new LibRadioButton("Veículo Leve", new Point(2, 20), new Size(110, 20));
            veiculoLeve.Click += new EventHandler(this.clickVeiculoLeve);

            veiculoPesado = new LibRadioButton("Veículo Pesado", new Point(120, 20), new Size(110, 20));
            veiculoPesado.Click += new EventHandler(this.clickVeiculoPesado);

            monthCalendar1 = new Calendario(new Point(370, 30));

            lblModelosVeiculos = new LibLabel("Modelos de Veículos:", new Point(20, 240), new Size(120, 15));

            modelosVeiculosLeves = new LibComboBox(new Point(20, 260), new Size(300, 40));
            IEnumerable<Model.VeiculoLeve> veiculosLeves = Controller.VeiculoLeve.GetVeiculosLeves();
            List<string> listLeve = new List<string>();
            foreach (Model.VeiculoLeve item in veiculosLeves)
            {
                listLeve.Add($"{item.Id} - {item.Marca} - {item.Modelo}");
            }
            modelosVeiculosLeves.Items.AddRange(listLeve.ToArray());

            modelosVeiculosPesados = new LibComboBox(new Point(20, 260), new Size(300, 40));
            IEnumerable<Model.VeiculoPesado> veiculosPesados = Controller.VeiculoPesado.GetVeiculoPesados();
            List<string> listPesado = new List<string>();
            foreach (Model.VeiculoPesado item in veiculosPesados)
            {
                listPesado.Add($"{item.Id} - {item.Marca} - {item.Modelo} - {item.Ano} - {item.Restricoes}");
            }
            modelosVeiculosPesados.Items.AddRange(listPesado.ToArray());

            btnSalvarCliente = new LibButton("Salvar", new Point(100, 300), new Size(100, 40));
            btnSalvarCliente.Click += new EventHandler(this.botaoSalvarCliente);

            btnCancelar = new LibButton("Cancelar", new Point(200, 300), new Size(100, 40));
            btnCancelar.Click += new EventHandler(this.botaoCancelar);

            if (!id.Equals("")) {
                this.locacao = Controller.Locacao.GetLocacao(Convert.ToInt32(id));
                this.idCliente.Text = locacao.IdCliente.ToString();
                this.dataLocacao.Text = locacao.DataLocacao.ToString();
            }

            this.Size = new Size(700, 400);
            this.Controls.Add(lblTitulo);
            this.Controls.Add(modelosVeiculosLeves);
            this.Controls.Add(modelosVeiculosPesados);
            this.Controls.Add(lblId);
            this.Controls.Add(idCliente);
            this.Controls.Add(lblDataLocacao);
            this.Controls.Add(dataLocacao);
            this.Controls.Add(tipo);
            this.Controls.Add(monthCalendar1);
            tipo.Controls.Add(veiculoLeve);
            tipo.Controls.Add(veiculoPesado);
            this.Controls.Add(btnSalvarCliente);
            this.Controls.Add(btnCancelar);
        }
        private void clickVeiculoLeve(object sender, EventArgs e)
        {
            this.modelosVeiculosLeves.Show();
            this.modelosVeiculosPesados.Hide();
        }
        private void clickVeiculoPesado(object sender, EventArgs e)
        {
            this.modelosVeiculosPesados.Show();
            this.modelosVeiculosLeves.Hide();
        }
        private void botaoSalvarCliente(object sender, EventArgs e)
        {
            List<Model.VeiculoLeve> VeiculosLeves = new List<Model.VeiculoLeve>();
            List<Model.VeiculoPesado> VeiculosPesados = new List<Model.VeiculoPesado>();
            DialogResult resultado = MessageBox.Show(
                "Deseja realmente cadastrar a locação?",
                "Confirmar Locação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (resultado == System.Windows.Forms.DialogResult.Yes)
            {
                MessageBox.Show("Usuário Cadastrado!");
                if (this.locacao.Id > 0) {
                    this.locacao.IdCliente = Convert.ToInt32(this.idCliente.Text);
                    this.locacao.DataLocacao = Convert.ToDateTime(this.dataLocacao.Text);
                    Controller.Locacao.AtualizarLocacao(this.locacao);
                }
                if (this.veiculoLeve.Checked)
                {
                    string combo = this.modelosVeiculosLeves.Text;
                    int pos = combo.IndexOf("-");
                    string strId = combo.Substring(0, pos - 1);
                    int id = Convert.ToInt32(strId);
                    Model.VeiculoLeve veiculo = Controller.VeiculoLeve.GetVeiculoLeve(id);
                    VeiculosLeves.Add(veiculo);
                }
                if (this.veiculoPesado.Checked)
                {
                    string combo = this.modelosVeiculosPesados.Text;
                    int pos = combo.IndexOf("-");
                    string strId = combo.Substring(0, pos - 1);
                    int id = Convert.ToInt32(strId);
                    Model.VeiculoPesado veiculo = Controller.VeiculoPesado.GetVeiculoPesado(id);
                    VeiculosPesados.Add(veiculo);
                }

                Controller.Locacao.NovaLocacao(
                    this.idCliente.Text,
                    this.dataLocacao.Text,
                    VeiculosLeves,
                    VeiculosPesados
                );


                MessageBox.Show("Locação Cadastrada!");
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
                MessageBox.Show("Locação não cadastrada");
            }
            else
            {
                MessageBox.Show("Opção Invalida!");
            }

            this.Close();
        }
    }
}