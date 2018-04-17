using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
namespace WCSAoyou
{

    public class TextBoxWriter : System.IO.TextWriter
    {
        RichTextBox logBox;
        delegate void VoidAction();

        public TextBoxWriter(RichTextBox box)
        {
            logBox = box;
        }

        public override void Write(string value)
        {
            VoidAction action = delegate
            {
                if (logBox.Text.Count() > 10000)
                {
                    this.logBox.Text = "";
                }
                logBox.Text += (string.Format("[{0:yyyy-MM-dd HH:mm:ss.fff}]{1}", DateTime.Now, value) + "\r\n");

            };
            logBox.BeginInvoke(action);
        }

        public override void WriteLine(string value)
        {
            VoidAction action = delegate
            {
                if (logBox.Text.Count() > 10000)
                {
                    this.logBox.Text = "";
                }
                logBox.Text += (string.Format("[{0:yyyy-MM-dd HH:mm:ss.fff}]{1}", DateTime.Now, value) + "\r\n");

            };
            logBox.BeginInvoke(action);
        }

        public override System.Text.Encoding Encoding
        {
            get { return System.Text.Encoding.UTF8; }
        }
    }      
}
