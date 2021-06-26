using System;
using System.Windows.Forms;
using System.Drawing;
using Views.Lib;
using System.Collections.Generic;

namespace Views
{
    public class ListarVeiculosLeves : Form
    {
        LibListView listagemVeiculosLeves;
        LibTituloLabel lblTitulo;
        LibButton btnOk;
        public ListarVeiculosLeves()
        {
            this.Text = "Buscar Veiculos Leves Cadastrados";

            lblTitulo = new LibTituloLabel("Buscar Veiculos Leves Cadastrados", new Point(180, 10), new Size(180, 40));

            IEnumerable<Model.VeiculoLeve> veiculosLeves = Controller.VeiculoLeve.ListarVeiculosLeves ();
            LibColuna[] colunas = new LibColuna[] {
                new LibColuna ("Id", HorizontalAlignment.Left),
                new LibColuna ("Marca", HorizontalAlignment.Left),
                new LibColuna ("Modelo.", HorizontalAlignment.Left),
                new LibColuna ("Ano", HorizontalAlignment.Left),
                new LibColuna ("Cor", HorizontalAlignment.Left)
            };
            
            listagemVeiculosLeves = new LibListView(25, 25, 400, 350, colunas);
            
            foreach (Model.VeiculoLeve veiculoLeve in veiculosLeves)
            {
                ListViewItem item = new ListViewItem(veiculoLeve.Id.ToString());
                item.SubItems.Add(veiculoLeve.Marca);
                item.SubItems.Add(veiculoLeve.Modelo);
                item.SubItems.Add(String.Format("{0:d}", veiculoLeve.Ano));
                item.SubItems.Add(veiculoLeve.Cor);
                listagemVeiculosLeves.Items.Add(item);
            }


            this.Size = new Size(450, 450);
            btnOk = new LibButton("OK", new Point(250, 550), new Size(100, 40));
            btnOk.Click += new EventHandler(this.botaoOk);

            this.Controls.Add(listagemVeiculosLeves);
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
