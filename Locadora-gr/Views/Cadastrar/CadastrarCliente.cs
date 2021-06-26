using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using Views.Lib;
using System.Text.RegularExpressions;

namespace Views
{
    public class CadastrarCliente : Form
    {
        Model.Cliente cliente = new Model.Cliente();
        LibTituloLabel lblTitulo;
        LibLabel lblNome;
        LibTextBox nome;
        LibLabel lblDataNascimento;
        LibMaskedTextBox dataNascimento;
        LibLabel lblCpf;
        LibMaskedTextBox cpf;
        LibLabel lblDiasRetorno;
        LibNumeric diasRetorno;
        LibGroupBox genero;
        LibRadioButton generoFeminino;
        LibRadioButton generoMasculino;
        LibButton btnSalvarCliente;
        LibButton btnCancelar;
        ErrorProvider erroCpf;
        public CadastrarCliente(string id = "")
        {
            this.Text = "Cadastro de Cliente";

            lblTitulo = new LibTituloLabel("Cadastro de Novo Cliente", new Point(180, 10), new Size(180, 40));

            lblNome = new LibLabel("Nome Completo:", new Point(20, 30), new Size(120, 15));

            nome = new LibTextBox(new Point(20, 50), new Size(300, 40));

            lblDataNascimento = new LibLabel("Data de Nascimento:", new Point(20, 80), new Size(120, 15));

            dataNascimento = new LibMaskedTextBox(new Point(20, 100), new Size(90, 40), "00/00/0000");

            lblCpf = new LibLabel("CPF:", new Point(20, 130), new Size(120, 15));

            cpf = new LibMaskedTextBox(new Point(20, 150), new Size(90, 40), "000,000,000-00");
            cpf.Validated += new EventHandler(this.cpfValidated);
            erroCpf = new ErrorProvider();
            erroCpf.SetIconAlignment(this.cpf, ErrorIconAlignment.MiddleRight);
            erroCpf.SetIconPadding(this.cpf, 2);
            erroCpf.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;

            genero = new LibGroupBox("Genero", new Point(20, 180), new Size(300, 50));

            generoFeminino = new LibRadioButton("Feminino", new Point(2, 20), new Size(100, 20));


            generoMasculino = new LibRadioButton("Maculino", new Point(120, 20), new Size(100, 20));

            genero.Controls.Add(generoFeminino);
            genero.Controls.Add(generoMasculino);

            lblDiasRetorno = new LibLabel("Dias para Retorno:", new Point(20, 240), new Size(120, 15));

            diasRetorno = new LibNumeric(new Point(20, 260), new Size(300, 40), 1, 180, 1);

            btnSalvarCliente = new LibButton("Salvar", new Point(100, 300), new Size(100, 40));
            btnSalvarCliente.Click += new EventHandler(this.botaoSalvarCliente);

            btnCancelar = new LibButton("Cancelar", new Point(200, 300), new Size(100, 40));
            btnCancelar.Click += new EventHandler(this.botaoCancelar);

            if (!id.Equals(""))
            {
                this.cliente = Controller.Cliente.GetCliente(Convert.ToInt32(id));
                this.nome.Text = cliente.Nome;
                this.dataNascimento.Text = cliente.DataNascimento.ToString();
                this.cpf.Text = cliente.Cpf;
                this.genero.Text = cliente.Genero;
                this.diasRetorno.Text = cliente.DiasRetorno.ToString();
            }

            this.Size = new Size(540, 400);
            this.Controls.Add(lblTitulo);
            this.Controls.Add(lblNome);
            this.Controls.Add(nome);
            this.Controls.Add(lblDataNascimento);
            this.Controls.Add(dataNascimento);
            this.Controls.Add(cpf);
            this.Controls.Add(lblCpf);
            this.Controls.Add(genero);
            this.Controls.Add(lblDiasRetorno);
            this.Controls.Add(diasRetorno);
            this.Controls.Add(btnSalvarCliente);
            this.Controls.Add(btnCancelar);
        }

        private void botaoSalvarCliente(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "Deseja realmente cadastrar o cliente?",
                "Confirmar Cadastro",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (resultado == System.Windows.Forms.DialogResult.Yes)
            {
                MessageBox.Show("Usuário Cadastrado!");
                if (this.cliente.Id > 0)
                {
                    this.cliente.Nome = this.nome.Text;
                    this.cliente.DataNascimento = Convert.ToDateTime(this.dataNascimento.Text);
                    this.cliente.Cpf = this.cpf.Text;
                    this.genero.Text = cliente.Genero;
                    this.cliente.DiasRetorno = Convert.ToInt32(this.diasRetorno.Text);
                    Controller.Cliente.AtualizarClientes(this.cliente);
                }
                else
                {
                    Controller.Cliente.NovoCliente(
                        this.nome.Text,
                        this.dataNascimento.Text,
                        this.cpf.Text,
                        this.genero.Text,
                        this.diasRetorno.Text
                    );
                }
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
        private void cpfValidated(object sender, EventArgs e) {
             Regex rgx = new Regex("^\\d{3}\\.\\d{3}\\.\\d{3}-\\d{2}$");
            if (!rgx.IsMatch(this.cpf.Text))
            {
                this.erroCpf.SetError(this.cpf, "CPF INVALIDO!");
            }else{
                this.erroCpf.SetError(this.cpf, String.Empty);
            }

        }
    }
}