using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TypeClipboard
{
    public partial class ActivePaster : Form
    {
        const int WS_EX_NOACTIVATE = 0x08000000;

        private static ActivePaster? instance = null;

        public static ActivePaster getInstance() => instance == null || instance.IsDisposed ? instance = new ActivePaster() : instance;

        private ActivePaster()
        {
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams param = base.CreateParams;
                param.ExStyle |= WS_EX_NOACTIVATE;
                return param;
            }
        }

        public void UpdateTextbox(object? sender = null, EventArgs? e = null)
        {
            if (Clipboard.ContainsText(TextDataFormat.UnicodeText))
            {
                String clipboard = Clipboard.GetText(TextDataFormat.UnicodeText);
                textBox1.Text = clipboard;
            }
            else
            {
                textBox1.Text = "No text in clipboard";
            }
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            UpdateTextbox();
        }

        private void Form1_Enter(object sender, EventArgs e)
        {
            UpdateTextbox();
        }

        private void Form1_MouseEnter(object sender, EventArgs e)
        {
            UpdateTextbox();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ClipboardNotification.ClipboardUpdate += UpdateTextbox;
            UpdateTextbox();
        }

        private void Paste_Click(object sender, EventArgs e)
        {
            Typer.TypeClipboard();
        }
    }
}
