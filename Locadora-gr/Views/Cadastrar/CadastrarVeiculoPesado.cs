using System;
using System.Windows.Forms;
using System.Drawing;
using Views.Lib;

namespace Views
{
    public class CadastrarVeiculoPesado : Form
    {
        Model.VeiculoPesado veiculoPesado = new Model.VeiculoPesado();
        LibTituloLabel lblTitulo;
        LibLabel lblMarca;
        LibTextBox marca;
        LibLabel lblModelo;
        LibTextBox modelo;
        LibLabel lblAno;
        LibMaskedTextBox ano;
        LibLabel lblPreco;
        LibTextBox preco;
        LibLabel lblRestricao;
        LibTextBox restricao;
        LibButton btnSalvarVeiculoPesado;
        LibButton btnCancelar;
        public CadastrarVeiculoPesado(string id = "")
        {
            this.Text = "Cadastro de Veículo Pesado";

            lblTitulo = new LibTituloLabel("Cadastro de Novo Veículo Pesado", new Point(180, 10), new Size(200, 40));

            lblMarca = new LibLabel("Marca:", new Point(20, 30), new Size(120, 15));

            marca = new LibTextBox(new Point(20, 50), new Size(300, 40));

            lblModelo = new LibLabel("Modelo:", new Point(20, 80), new Size(120, 15));

            modelo = new LibTextBox(new Point(20, 100), new Size(300, 40));

            lblAno = new LibLabel("Ano:", new Point(20, 120), new Size(120, 15));

            ano = new LibMaskedTextBox(new Point(20, 140), new Size(300, 40), "0000");

            lblPreco = new LibLabel("Preço:", new Point(20, 160), new Size(120, 15));

            preco = new LibTextBox(new Point(20, 180), new Size(300, 40));

            lblRestricao = new LibLabel("Restricao:", new Point(20, 200), new Size(120, 15));

            restricao = new LibTextBox(new Point(20, 220), new Size(300, 40));

            btnSalvarVeiculoPesado = new LibButton("Salvar", new Point(100, 300), new Size(100, 40));
            btnSalvarVeiculoPesado.Click += new EventHandler(this.botaoSalvarVeiculoPesado);

            btnCancelar = new LibButton("Cancelar", new Point(200, 300), new Size(100, 40));
            btnCancelar.Click += new EventHandler(this.botaoCancelar);

            if (!id.Equals(""))
            {
                this.veiculoPesado = Controller.VeiculoPesado.GetVeiculoPesado(Convert.ToInt32(id));
                this.marca.Text = veiculoPesado.Marca;
                this.modelo.Text = veiculoPesado.Modelo.ToString();
                this.ano.Text = veiculoPesado.Ano.ToString();
                this.preco.Text = veiculoPesado.Preco.ToString();
                this.restricao.Text = veiculoPesado.Restricoes;
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
            this.Controls.Add(lblRestricao);
            this.Controls.Add(restricao);
            this.Controls.Add(btnSalvarVeiculoPesado);
            this.Controls.Add(btnCancelar);
        }

        private void botaoSalvarVeiculoPesado(object sender, EventArgs e)
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
                if (this.veiculoPesado.Id > 0) {
                    this.veiculoPesado.Marca = this.marca.Text;
                    this.veiculoPesado.Modelo = this.modelo.Text;
                    this.veiculoPesado.Ano = Convert.ToInt32(this.ano.Text);
                    this.veiculoPesado.Preco = Convert.ToInt32(this.preco.Text);
                    this.veiculoPesado.Restricoes = this.restricao.Text;
                    Controller.VeiculoPesado.AtualizarVeiculoPesado(this.veiculoPesado);
                } else {
                    Controller.VeiculoPesado.AdicionarVeiculoPesado(
                        this.marca.Text,
                        this.modelo.Text,
                        this.ano.Text,
                        this.preco.Text,
                        this.restricao.Text
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