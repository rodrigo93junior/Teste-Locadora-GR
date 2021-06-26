using System.Drawing;
using System.Windows.Forms;

namespace Views
{
    namespace Lib
    {
        class LibRadioButton : RadioButton
        {
            public LibRadioButton(
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