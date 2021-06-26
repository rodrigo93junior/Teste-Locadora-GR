using System.Drawing;
using System.Windows.Forms;
using System;
using System.Collections.Generic;

namespace Views {
    namespace Lib {
        public class InputBox {
            public InputBox (
                string title,
                string promptText,
                List<string> listOptions,
                ref string value
            ) {
                Form form = new Form ();
                Label label = new Label ();
                ComboBox comboBox = new ComboBox ();
                Button buttonOk = new Button ();
                Button buttonCancel = new Button ();

                form.Text = title;
                label.Text = promptText;
                comboBox.Items.AddRange(listOptions.ToArray());

                buttonOk.Text = "OK";
                buttonCancel.Text = "Cancel";
                buttonOk.DialogResult = DialogResult.OK;
                buttonCancel.DialogResult = DialogResult.Cancel;

                label.SetBounds (9, 20, 372, 13);
                comboBox.SetBounds (12, 45, 372, 20);
                buttonOk.SetBounds (228, 120, 75, 23);
                buttonCancel.SetBounds (309, 120, 75, 23);

                label.AutoSize = true;
                comboBox.Anchor = comboBox.Anchor | AnchorStyles.Right;
                buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

                form.ClientSize = new Size (400, 180);
                form.Controls.AddRange (
                    new Control[] { label, comboBox, buttonOk, buttonCancel }
                );
                form.ClientSize = new Size (
                    Math.Max (300, label.Right + 10), 
                    form.ClientSize.Height
                );
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.StartPosition = FormStartPosition.CenterScreen;
                form.MinimizeBox = false;
                form.MaximizeBox = false;
                form.AcceptButton = buttonOk;
                form.CancelButton = buttonCancel;

                form.ShowDialog ();
                string comboValue = comboBox.Text;
                if (!comboValue.Equals("")) {
                    int pos = comboValue.IndexOf("-"); 

                    value = comboValue.Substring(0, pos - 1);
                }
            }
        }
    }
}