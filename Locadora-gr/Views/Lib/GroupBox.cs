using System.Drawing;
using System.Windows.Forms;

namespace Views
{
    namespace Lib
    {

        class LibGroupBox : GroupBox
        {
            public LibGroupBox(
                string Text,
                Point Location,
                Size Size
            )
            {
                this.Text = Text;
                this.Location = Location;
                this.Size = Size;
            }
        }
    }
}