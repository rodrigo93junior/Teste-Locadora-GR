using System;
using System.Windows.Forms;
using System.Drawing;
using Views.Lib;
using System.Collections.Generic;

namespace Views
{
    public class ListarLocacoes : Form
    {
        LibListView listargemlocacoes;
        LibTituloLabel lblTitulo;
        LibButton btnOk;
        public ListarLocacoes()
        {
            this.Text = "Buscar Locações";

            lblTitulo = new LibTituloLabel("Buscar Locações", new Point(180, 10), new Size(180, 40));

            IEnumerable<Model.Locacao> locacoes = Controller.Locacao.GetLocacao ();
            LibColuna[] colunas = new LibColuna[] {
                new LibColuna ("ID Locação", HorizontalAlignment.Left),
                new LibColuna ("ID Cliente", HorizontalAlignment.Left),
                new LibColuna ("Data locação.", HorizontalAlignment.Left),
                new LibColuna ("Veiculos Leves", HorizontalAlignment.Left),
                new LibColuna ("Veiculos Pesados", HorizontalAlignment.Left)
            };
            
            listargemlocacoes = new LibListView(25, 25, 400, 350, colunas);
            
            foreach (Model.Locacao locacao in locacoes)
            {
                ListViewItem item = new ListViewItem(locacao.Id.ToString());
                item.SubItems.Add(locacao.IdCliente.ToString());
                item.SubItems.Add(String.Format("{0:d}", locacao.DataLocacao));
                // item.SubItems.Add(locacao.VeiculosLeves);
                // item.SubItems.Add(locacao.VeiculosPesados);
                listargemlocacoes.Items.Add(item);
            }


            this.Size = new Size(450, 450);
            btnOk = new LibButton("OK", new Point(250, 550), new Size(100, 40));
            btnOk.Click += new EventHandler(this.botaoOk);

            this.Controls.Add(listargemlocacoes);
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
