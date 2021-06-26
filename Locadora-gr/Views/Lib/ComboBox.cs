using System.Drawing;
using System.Windows.Forms;

namespace Views
{
    namespace Lib
    {
        class LibComboBox : ComboBox
        {
            public LibComboBox(
                Point Location,
                Size Size
            )
            {
                this.Location = Location;
                this.Size = Size;
            }
        }
        class LibNumeric : NumericUpDown
        {
            public LibNumeric(
                Point Location,
                Size Size,
                int Value,
                int Maximum,
                int Minimum
            )
            {
                this.Location = Location;
                this.Size = Size;
                this.Value = Value;
                this.Maximum = Maximum;
                this.Minimum = Minimum;
            }
        }
        public class LibsComboBox : ComboBox
        {
            public LibsComboBox(
                Point Location,
                Size Size,
                string[] options
            )
            {
                this.Location = Location;
                this.Size = Size;
                foreach (string item in options)
                {
                    this.Items.Add(item);
                }
            }

        }
        public class LibsCBBox : ComboBox
        {
            public LibsCBBox(
                Point Location,
                Size Size,
                string[] opt

            )
            {
                this.Location = Location;
                this.Size = Size;
                foreach (string item in opt)
                {
                    this.Items.Add(item);
                }

            }
        }
    }
}