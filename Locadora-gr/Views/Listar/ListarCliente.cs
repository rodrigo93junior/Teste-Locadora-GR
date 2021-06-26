using System;
using System.Windows.Forms;
using System.Drawing;
using Views.Lib;
using System.Collections.Generic;

namespace Views
{
    public class ListarCliente : Form
    {
        LibListView listagemCliente;
        LibTituloLabel lblTitulo;
        LibButton btnOk;
        public ListarCliente()
        {
            this.Text = "Buscar Clientes Cadastrados";

            lblTitulo = new LibTituloLabel("Buscar Cliente Cadastrado", new Point(180, 10), new Size(180, 40));

            IEnumerable<Model.Cliente> clientes = Controller.Cliente.ListarClientes ();
            LibColuna[] colunas = new LibColuna[] {
                new LibColuna ("ID", HorizontalAlignment.Left),
                new LibColuna ("Nome Completo", HorizontalAlignment.Left),
                new LibColuna ("Data Nascimento", HorizontalAlignment.Left),
                new LibColuna ("CPF", HorizontalAlignment.Left),
                new LibColuna ("Genero", HorizontalAlignment.Left),
                new LibColuna ("Dias Devolção", HorizontalAlignment.Left)
            };
            
            listagemCliente = new LibListView(25, 25, 400, 350, colunas);
            
            foreach (Model.Cliente cliente in clientes)
            {
                ListViewItem item = new ListViewItem(cliente.Id.ToString());
                item.SubItems.Add(cliente.Nome);
                item.SubItems.Add(String.Format("{0:d}", cliente.DataNascimento));
                item.SubItems.Add(cliente.Cpf);
                item.SubItems.Add(cliente.Genero);
                item.SubItems.Add(cliente.DiasRetorno.ToString());
                listagemCliente.Items.Add(item);
            }


            this.Size = new Size(450, 450);
            btnOk = new LibButton("OK", new Point(250, 550), new Size(100, 40));
            btnOk.Click += new EventHandler(this.botaoOk);

            this.Controls.Add(listagemCliente);
            this.Controls.Add(lblTitulo);
            this.Controls.Add(btnOk);

            this.Size = new Size(600, 680);
        }
        private void botaoOk(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
