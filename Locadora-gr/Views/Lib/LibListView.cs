using System.Drawing;
using System.Windows.Forms;

namespace Views
{
    namespace Lib
    {
        public class LibColuna
        {
            public string Campo { get; }
            public HorizontalAlignment Oreientacao { get; }

            public LibColuna(
                string Campo,
                HorizontalAlignment Oreientacao
            )
            {
                this.Campo = Campo;
                this.Oreientacao = Oreientacao;
            }
        }
        public class LibListView : ListView
        {
            public LibListView(
                int x,
                int y,
                int width,
                int height,
                LibColuna[] colunas
            )
            {
                this.Size = new Size(width, height);
                this.Location = new Point(x, y);
                this.View = View.Details;
                this.FullRowSelect = true;
                this.GridLines = true;
                this.AllowColumnReorder = true;
                this.Sorting = SortOrder.Ascending;

                foreach (LibColuna item in colunas)
                {
                    this.Columns.Add(item.Campo, -2, item.Oreientacao);
                }
            }
        }

    }
}