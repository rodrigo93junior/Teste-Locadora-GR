using System.Drawing;
using System.Windows.Forms;

namespace Views
{
    namespace Lib
    {
        class DataSelecionavel : DateTimePicker
        {
            public DataSelecionavel(
                Point Location
            )
            {
                this.Location = Location;
            }
        }
    }
}