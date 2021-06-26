using System;
using System.Windows.Forms;
using System.Drawing;
using Views.Lib;
using System.Collections.Generic;

namespace Views
{
    public class ListarVeiculosPesados : Form
    {
        LibListView listagemVeiculosPesados;
        LibTituloLabel lblTitulo;
        LibButton btnOk;
        public ListarVeiculosPesados()
        {
            this.Text = "Buscar Veiculos Pesados Cadastrados";

            lblTitulo = new LibTituloLabel("Buscar Veiculos Pesados Cadastrados", new Point(180, 10), new Size(180, 40));

            IEnumerable<Model.VeiculoPesado> veiculosPesados = Controller.VeiculoPesado.ListarVeiculosPesados ();
            LibColuna[] colunas = new LibColuna[] {
                new LibColuna ("Id", HorizontalAlignment.Left),
                new LibColuna ("Marca", HorizontalAlignment.Left),
                new LibColuna ("Modelo.", HorizontalAlignment.Left),
                new LibColuna ("Ano", HorizontalAlignment.Left),
                new LibColuna ("Restrição", HorizontalAlignment.Left)
            };
            
            listagemVeiculosPesados = new LibListView(25, 25, 400, 350, colunas);
            
            foreach (Model.VeiculoPesado veiculoPesado in veiculosPesados)
            {
                ListViewItem item = new ListViewItem(veiculoPesado.Id.ToString());
                item.SubItems.Add(veiculoPesado.Marca);
                item.SubItems.Add(veiculoPesado.Modelo);
                item.SubItems.Add(String.Format("{0:d}", veiculoPesado.Ano));
                item.SubItems.Add(veiculoPesado.Restricoes);
                listagemVeiculosPesados.Items.Add(item);
            }


            this.Size = new Size(450, 450);
            btnOk = new LibButton("OK", new Point(250, 550), new Size(100, 40));
            btnOk.Click += new EventHandler(this.botaoOk);

            this.Controls.Add(listagemVeiculosPesados);
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
