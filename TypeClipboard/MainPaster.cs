using TypeClipboard.LLL;

namespace TypeClipboard
{
    public partial class MainPaster : Form
    {
        const int WS_EX_NOACTIVATE = 0x08000000;

        private readonly LowLevelKeyboardListener keyboardListener = new();
        private readonly LowLevelMouseListener mouseListener = new();

        private NotifyIcon notifyIcon;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem exitMenuItem;
        private ToolStripMenuItem showMenuItem;

        private static MainPaster? instance;
        private HotkeyTypes? listening;
        private bool initiateTermination = false;

        public HotkeyTypes? Listening { get => listening; set => listening = value; }

        public static MainPaster GetInstance() => instance == null ? instance = new MainPaster() : instance;

        private MainPaster()
        {
            InitializeComponent();
            InitializeNotifyIcon();
            MinimizeToTray();
            Thread.Sleep(100);
        }

        private void InitializeNotifyIcon()
        {
            notifyIcon = new NotifyIcon();
            contextMenuStrip = new ContextMenuStrip();

            notifyIcon.Icon = SystemIcons.Application;
            notifyIcon.Text = "Clip Typer";
            notifyIcon.Visible = true;

            showMenuItem = new ToolStripMenuItem("Show", null, ShowForm);
            exitMenuItem = new ToolStripMenuItem("Exit", null, ExitApplication);

            contextMenuStrip.Items.Add(showMenuItem);
            contextMenuStrip.Items.Add(exitMenuItem);
            notifyIcon.ContextMenuStrip = contextMenuStrip;

            notifyIcon.DoubleClick += ShowForm;
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

        private void Paste_Click(object sender, EventArgs e)
        {
            Typer.TypeClipboard();
        }

        public void UpdateTextbox(object? sender = null, EventArgs? e = null)
        {
            bool success = false;
            int retries = 10;
            while (!success && retries > 0)
            {
                try
                {
                    if (Clipboard.ContainsText(TextDataFormat.UnicodeText))
                    {
                        string clipboard = Clipboard.GetText(TextDataFormat.UnicodeText);
                        textBox1.Text = clipboard;
                    }
                    else
                    {
                        textBox1.Text = "No text in clipboard";
                    }

                    success = true;
                }
                catch (Exception ex)
                {
                    retries--;
                    Thread.Sleep(100);
                }
            }
            if (!success)
            {
                textBox1.Text = "Clipboard access failed";
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
            keyboardListener.HookKeyboard();
            mouseListener.HookMouse();
            pasteHKBtn.Text = "Paste Hotkey: " + Properties.Settings.Default.PasteHotkey;
            cancelHKBtn.Text = "Cancel Hotkey: " + Properties.Settings.Default.CancelHotkey;

            chkEnter.Checked = Properties.Settings.Default.enableEnter;

            ClipboardNotification.ClipboardUpdate += UpdateTextbox;
            UpdateTextbox();
            MinimizeToTray();
        }

        private void BufferType_Click(object sender, EventArgs e)
        {
            Typer.TypeText(textBox2.Text);
        }

        private void ToBuffer_Click(object sender, EventArgs e)
        {
            String clipboard = Clipboard.GetText(TextDataFormat.UnicodeText);
            textBox2.Text = clipboard;
        }

        private void CBEnter_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.enableEnter = chkEnter.Checked;
            Typer.AutoSubmit = chkEnter.Checked;
            Properties.Settings.Default.Save();
        }

        private void Paste_HK_Btn_Click(object sender, EventArgs e)
        {
            Listening = HotkeyTypes.PASTE;
            pasteHKBtn.Text = "Listening...";
        }

        private void Cancel_HK_Btn_Click(object sender, EventArgs e)
        {
            Listening = HotkeyTypes.CANCEL;
            cancelHKBtn.Text = "Listening...";
        }

        public void SetHK(String key, HotkeyTypes? hkt)
        {
            switch (hkt)
            {
                case HotkeyTypes.PASTE:
                    pasteHKBtn.Text = "Paste Hotkey: " + key;
                    break;
                case HotkeyTypes.CANCEL:
                    cancelHKBtn.Text = "Cancel Hotkey: " + key;
                    break;
            }
            Listening = null;
        }

        private void ShowForm(object? sender, EventArgs? e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            BringToFront();
        }

        private void ExitApplication(object? sender, EventArgs? e)
        {
            initiateTermination = true;
            notifyIcon.Visible = false;
            keyboardListener.UnHookKeyboard();
            mouseListener.UnHookMouse();
            Application.Exit();
        }

        private void MinimizeToTray()
        {
            Hide();
            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;
            notifyIcon.Visible = true;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (WindowState == FormWindowState.Minimized)
            {
                MinimizeToTray();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!initiateTermination)
            {
                MinimizeToTray();
                e.Cancel = true;
            }
        }
    }
}
