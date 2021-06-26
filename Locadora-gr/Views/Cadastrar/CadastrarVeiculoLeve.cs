using System;
using System.Windows.Forms;
using System.Drawing;
using Views.Lib;

namespace Views
{
    public class CadastrarVeiculoLeve : Form
    {
        Model.VeiculoLeve veiculoLeve = new Model.VeiculoLeve();
        LibTituloLabel lblTitulo;
        LibLabel lblMarca;
        LibTextBox marca;
        LibLabel lblModelo;
        LibTextBox modelo;
        LibLabel lblAno;
        LibMaskedTextBox ano;
        LibLabel lblPreco;
        LibTextBox preco;
        LibLabel lblCor;
        LibTextBox cor;
        LibButton btnSalvarVeiculoLeve;
        LibButton btnCancelar;
        public CadastrarVeiculoLeve(string id = "")
        {
            this.Text = "Cadastro de Veículo Leve";

            lblTitulo = new LibTituloLabel("Cadastro de Novo Veículo Leve", new Point(180, 10), new Size(180, 40));

            lblMarca = new LibLabel("Marca:", new Point(20, 30), new Size(120, 15));

            marca = new LibTextBox(new Point(20, 50), new Size(300, 40));

            lblModelo = new LibLabel("Modelo:", new Point(20, 80), new Size(120, 15));


            modelo = new LibTextBox(new Point(20, 100), new Size(300, 40));

            lblAno = new LibLabel("Ano:", new Point(20, 120), new Size(120, 15));

            ano = new LibMaskedTextBox(new Point(20, 140), new Size(300, 40),"0000");

            lblPreco = new LibLabel("Preço:", new Point(20, 160), new Size(120, 15));


            preco = new LibTextBox(new Point(20, 180), new Size(300, 40));

            lblCor = new LibLabel("Cor:", new Point(20, 200), new Size(120, 15));

            cor = new LibTextBox(new Point(20, 220), new Size(300, 40));

            btnSalvarVeiculoLeve = new LibButton("Salvar", new Point(100, 300), new Size(100, 40));
            btnSalvarVeiculoLeve.Click += new EventHandler(this.botaoSalvarVeiculoLeve);

            btnCancelar = new LibButton("Cancelar", new Point(200, 300), new Size(100, 40));
            btnCancelar.Click += new EventHandler(this.botaoCancelar);

            if (!id.Equals("")) {
                this.veiculoLeve = Controller.VeiculoLeve.GetVeiculoLeve(Convert.ToInt32(id));
                this.marca.Text = veiculoLeve.Marca;
                this.modelo.Text = veiculoLeve.Modelo.ToString();
                this.ano.Text = veiculoLeve.Ano.ToString();
                this.preco.Text = veiculoLeve.Preco.ToString();
                this.cor.Text = veiculoLeve.Cor;
            }

            this.Size = new Size(540, 400);
            this.Controls.Add(lblTitulo);
            this.Controls.Add(lblMarca);
            this.Controls.Add(marca);
            this.Controls.Add(lblModelo);
            this.Controls.Add(modelo);
            this.Controls.Add(lblAno);
            this.Controls.Add(ano);
            this.Controls.Add(lblPreco);
            this.Controls.Add(preco);
            this.Controls.Add(lblCor);
            this.Controls.Add(cor);
            this.Controls.Add(btnSalvarVeiculoLeve);
            this.Controls.Add(btnCancelar);
        }

        private void botaoSalvarVeiculoLeve(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "Deseja realmente cadastrar o veículo?",
                "Confirmar Cadastro",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (resultado == System.Windows.Forms.DialogResult.Yes)
            {
                MessageBox.Show("Usuário Cadastrado!");
                if (this.veiculoLeve.Id > 0) {
                    this.veiculoLeve.Marca = this.marca.Text;
                    this.veiculoLeve.Modelo = this.modelo.Text;
                    this.veiculoLeve.Ano = Convert.ToInt32(this.ano.Text);
                    this.veiculoLeve.Preco = Convert.ToInt32(this.preco.Text);
                    this.veiculoLeve.Cor = this.cor.Text;
                    Controller.VeiculoLeve.AtualizarVeiculoLeve(this.veiculoLeve);
                } else {
                Controller.VeiculoLeve.AdicionarVeiculoLeve(
                    this.marca.Text,
                    this.modelo.Text,
                    this.ano.Text,
                    this.preco.Text,
                    this.cor.Text
                );
                MessageBox.Show("Veículo Cadastrado!");
                }
            }
            else if (resultado == System.Windows.Forms.DialogResult.No)
            {
                MessageBox.Show("Veículo não cadastrado");
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
                MessageBox.Show("Veículo não cadastrado");
            }
            else
            {
                MessageBox.Show("Opção Invalida!");
            }

            this.Close();
        }
    }
}