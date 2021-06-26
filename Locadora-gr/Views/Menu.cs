using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using Views.Lib;

namespace Views
{
    public class Menu : Form
    {
        PictureBox pbImagem;
        public Menu()
        {
            this.Text = "GR - Locadora de Veículos";

            pbImagem = new PictureBox();
            pbImagem.Size = new Size(300, 120);
            pbImagem.Location = new Point(130, 3);
            pbImagem.Load("gr.jpg");
            pbImagem.SizeMode = PictureBoxSizeMode.Zoom;

            Label lblTitulo = new Label();
            lblTitulo.Text = "Bem vindo!";
            lblTitulo.Location = new Point(220, 110);
            lblTitulo.Size = new Size(80, 50);

            Label lblSubTitulo = new Label();
            lblSubTitulo.Text = "Cadastros:";
            lblSubTitulo.Location = new Point(20, 140);
            lblSubTitulo.Size = new Size(80, 20);

            Button btCadastrarLocacao = new Button();
            btCadastrarLocacao.Text = "Cadastrar Locação";
            btCadastrarLocacao.Location = new Point(20, 180);
            btCadastrarLocacao.Size = new Size(200, 40);
            btCadastrarLocacao.Click += new EventHandler(this.btCadastrarLocacao);

            Button btCadastrarCliente = new Button();
            btCadastrarCliente.Text = "Cadastrar Cliente";
            btCadastrarCliente.Location = new Point(20, 230);
            btCadastrarCliente.Size = new Size(200, 40);
            btCadastrarCliente.Click += new EventHandler(this.btCadastrarCliente);

            Button btCadastrarVeiculoLeve = new Button();
            btCadastrarVeiculoLeve.Text = "Cadastrar Veículo Leve";
            btCadastrarVeiculoLeve.Location = new Point(20, 280);
            btCadastrarVeiculoLeve.Size = new Size(200, 40);
            btCadastrarVeiculoLeve.Click += new EventHandler(this.btCadastrarVeiculoLeve);

            Button btCadastrarVeiculoPesado = new Button();
            btCadastrarVeiculoPesado.Text = "Cadastrar Veículo Pesado";
            btCadastrarVeiculoPesado.Location = new Point(20, 330);
            btCadastrarVeiculoPesado.Size = new Size(200, 40);
            btCadastrarVeiculoPesado.Click += new EventHandler(this.btCadastrarVeiculoPesado);

            Label lblSubTituloVisualizacao = new Label();
            lblSubTituloVisualizacao.Text = "Visualização:";
            lblSubTituloVisualizacao.Location = new Point(300, 140);
            lblSubTituloVisualizacao.Size = new Size(80, 20);

            Button btListarLocacoes = new Button();
            btListarLocacoes.Text = "Buscar Locacoes";
            btListarLocacoes.Location = new Point(300, 180);
            btListarLocacoes.Size = new Size(200, 40);
            btListarLocacoes.Click += new EventHandler(this.btListarLocacoes);

            Button btListarCliente = new Button();
            btListarCliente.Text = "Buscar Cliente";
            btListarCliente.Location = new Point(300, 230);
            btListarCliente.Size = new Size(200, 40);
            btListarCliente.Click += new EventHandler(this.btListarCliente);

            Button btListarVeiculoLeve = new Button();
            btListarVeiculoLeve.Text = "Buscar Veículo Leve";
            btListarVeiculoLeve.Location = new Point(300, 280);
            btListarVeiculoLeve.Size = new Size(200, 40);
            btListarVeiculoLeve.Click += new EventHandler(this.btListarVeiculoLeve);

            Button btListarVeiculoPesado = new Button();
            btListarVeiculoPesado.Text = "Buscar Veículo Pesado";
            btListarVeiculoPesado.Location = new Point(300, 330);
            btListarVeiculoPesado.Size = new Size(200, 40);
            btListarVeiculoPesado.Click += new EventHandler(this.btListarVeiculoPesado);

            Label lblSubTituloAtualizar = new Label();
            lblSubTituloAtualizar.Text = "Atualização:";
            lblSubTituloAtualizar.Location = new Point(20, 390);
            lblSubTituloAtualizar.Size = new Size(80, 20);

            Button btAtualizarCliente = new Button();
            btAtualizarCliente.Text = "Atualizar Cliente";
            btAtualizarCliente.Location = new Point(20, 420);
            btAtualizarCliente.Size = new Size(200, 40);
            btAtualizarCliente.Click += new EventHandler(this.btAtualizarClienteClick);

            Button btAtualizarVeiculoLeve = new Button();
            btAtualizarVeiculoLeve.Text = "Atualizar Veículo Leve";
            btAtualizarVeiculoLeve.Location = new Point(20, 470);
            btAtualizarVeiculoLeve.Size = new Size(200, 40);
            btAtualizarVeiculoLeve.Click += new EventHandler(this.btAtualizarVeiculoleve);

            Button btAtualizarVeiculoPesado = new Button();
            btAtualizarVeiculoPesado.Text = "Atualizar Veículo Pesado";
            btAtualizarVeiculoPesado.Location = new Point(20, 520);
            btAtualizarVeiculoPesado.Size = new Size(200, 40);
            btAtualizarVeiculoPesado.Click += new EventHandler(this.btAtualizarVeiculoPesado);

            Button btAtualizarLocacao = new Button();
            btAtualizarLocacao.Text = "Atualizar Locação";
            btAtualizarLocacao.Location = new Point(20, 570);
            btAtualizarLocacao.Size = new Size(200, 40);
            btAtualizarLocacao.Click += new EventHandler(this.btAtualizarLocacao);

            Label lblSubTituloRemover = new Label();
            lblSubTituloRemover.Text = "Remover";
            lblSubTituloRemover.Location = new Point(300, 390);
            lblSubTituloRemover.Size = new Size(80, 20);

            Button btRemoverCliente = new Button();
            btRemoverCliente.Text = "Remover Cliente";
            btRemoverCliente.Location = new Point(300, 420);
            btRemoverCliente.Size = new Size(200, 40);
            btRemoverCliente.Click += new EventHandler(this.btRemoverClienteClick);

            Button btRemoverVeiculoLeve = new Button();
            btRemoverVeiculoLeve.Text = "Remover Veículo Leve";
            btRemoverVeiculoLeve.Location = new Point(300, 470);
            btRemoverVeiculoLeve.Size = new Size(200, 40);
            btRemoverVeiculoLeve.Click += new EventHandler(this.btRemoverVeiculoLeveClick);

            Button btRemoverVeiculoPesado = new Button();
            btRemoverVeiculoPesado.Text = "Remover Veículo Pesado";
            btRemoverVeiculoPesado.Location = new Point(300, 520);
            btRemoverVeiculoPesado.Size = new Size(200, 40);
            btRemoverVeiculoPesado.Click += new EventHandler(this.btRemoverVeiculoPesadoClick);

            Button btRemoverLocacao = new Button();
            btRemoverLocacao.Text = "Remover Locação";
            btRemoverLocacao.Location = new Point(300, 570);
            btRemoverLocacao.Size = new Size(200, 40);
            btRemoverLocacao.Click += new EventHandler(this.btRemoverLocacaoClick);


            this.Size = new Size(600, 700);
            this.Controls.Add(lblTitulo);
            this.Controls.Add(pbImagem);
            this.Controls.Add(lblSubTitulo);
            this.Controls.Add(btCadastrarLocacao);
            this.Controls.Add(btCadastrarCliente);
            this.Controls.Add(btCadastrarVeiculoLeve);
            this.Controls.Add(btCadastrarVeiculoPesado);

            this.Controls.Add(lblSubTituloVisualizacao);
            this.Controls.Add(btListarLocacoes);
            this.Controls.Add(btListarCliente);
            this.Controls.Add(btListarVeiculoLeve);
            this.Controls.Add(btListarVeiculoPesado);

            this.Controls.Add(lblSubTituloAtualizar);
            this.Controls.Add(btAtualizarCliente);
            this.Controls.Add(btAtualizarVeiculoLeve);
            this.Controls.Add(btAtualizarVeiculoPesado);
            this.Controls.Add(btAtualizarLocacao);

            this.Controls.Add(lblSubTituloRemover);
            this.Controls.Add(btRemoverCliente);
            this.Controls.Add(btRemoverVeiculoLeve);
            this.Controls.Add(btRemoverVeiculoPesado);
            this.Controls.Add(btRemoverLocacao);
        }

        private void btCadastrarCliente(object sender, EventArgs e)
        {
            CadastrarCliente cadastrarCliente = new CadastrarCliente();
            cadastrarCliente.Show();
        }
        private void btCadastrarLocacao(object sender, EventArgs e)
        {
            CadastrarLocacao cadastrarLocacao = new CadastrarLocacao();
            cadastrarLocacao.Show();
        }
        private void btCadastrarVeiculoLeve(object sender, EventArgs e)
        {
            CadastrarVeiculoLeve cadastrarVeiculoLeve = new CadastrarVeiculoLeve();
            cadastrarVeiculoLeve.Show();
        }
        private void btCadastrarVeiculoPesado(object sender, EventArgs e)
        {
            CadastrarVeiculoPesado cadastrarVeiculoPesado = new CadastrarVeiculoPesado();
            cadastrarVeiculoPesado.Show();
        }

        private void btListarCliente(object sender, EventArgs e)
        {
            ListarCliente listarCliente = new ListarCliente();
            listarCliente.Show();
        }
        private void btListarLocacoes(object sender, EventArgs e)
        {
            ListarLocacoes listarLocacoes = new ListarLocacoes();
            listarLocacoes.Show();
        }
        private void btListarVeiculoLeve(object sender, EventArgs e)
        {
            ListarVeiculosLeves listarVeiculosLeves = new ListarVeiculosLeves();
            listarVeiculosLeves.Show();
        }
        private void btListarVeiculoPesado(object sender, EventArgs e)
        {
            ListarVeiculosPesados listarVeiculosPesados = new ListarVeiculosPesados();
            listarVeiculosPesados.Show();
        }

        private void btAtualizarClienteClick(object sender, EventArgs e)
        {
            AtualizarClientes atualizarClientes = new AtualizarClientes();
            atualizarClientes.Show();
        }
        private void btAtualizarVeiculoleve(object sender, EventArgs e)
        {
            AtualizarVeiculoLeve atualizarVeiculoLeve = new AtualizarVeiculoLeve();
            atualizarVeiculoLeve.Show();
        }
        private void btAtualizarVeiculoPesado(object sender, EventArgs e)
        {
            AtualizarVeiculoPesado atualizarVeiculoPesado = new AtualizarVeiculoPesado();
            atualizarVeiculoPesado.Show();
        }
        private void btAtualizarLocacao(object sender, EventArgs e)
        {
            AtualizarLocacao atualizarLocacao = new AtualizarLocacao();
            atualizarLocacao.Show();
        }

        private void btRemoverClienteClick(object sender, EventArgs e)
        {
            RemoverClientes removerClientes = new RemoverClientes();
            removerClientes.Show();
        }
        private void btRemoverLocacaoClick(object sender, EventArgs e)
        {
            RemoverLocacao removerLocaRemoverLocacao = new RemoverLocacao();
            removerLocaRemoverLocacao.Show();
        }
        private void btRemoverVeiculoLeveClick(object sender, EventArgs e)
        {
            RemoverVeiculoLeve removerVeiculoLeve = new RemoverVeiculoLeve();
            removerVeiculoLeve.Show();
        }
        private void btRemoverVeiculoPesadoClick(object sender, EventArgs e)
        {
            RemoverVeiculoPesado removerVeiculoPesado = new RemoverVeiculoPesado();
            removerVeiculoPesado.Show();
        }
    }
}