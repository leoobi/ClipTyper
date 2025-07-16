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

        public static ActivePaster GetInstance() => instance == null || instance.IsDisposed ? instance = new ActivePaster() : instance;

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
                if (Properties.Settings.Default.HideClipboardText)
                {
                    textBox1.Text = "******************";
                }
                else
                {
                    textBox1.Text = clipboard;
                }
            }
            else
            {
                textBox1.Text = "No text in clipboard";
            }
        }
        
        public void setHideCheck(bool check)
        {
            chkHide.Checked = check;
        }
        
        public void CBHide_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.HideClipboardText = chkHide.Checked;
            Properties.Settings.Default.Save();
            MainPaster.GetInstance().setHideCheck(chkHide.Checked);
            UpdateTextbox();
            MainPaster.GetInstance().UpdateTextbox();
            MainPaster.GetInstance().UpdateBufferVisibility();
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
