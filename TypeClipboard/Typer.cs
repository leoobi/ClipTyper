using System.Runtime.InteropServices;

namespace TypeClipboard
{
    class Typer
    {
        private static bool autoSubmit = false;
        public static bool AutoSubmit { get => autoSubmit; set => autoSubmit = value; }

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        public static async void TypeText(String str)
        {
            if (GetForegroundWindow() == ActivePaster.getInstance().Handle) return;
            await Task.Run(() =>
            {
                foreach (Char c in str.ToCharArray())
                {
                    switch (c)
                    {
                        case '{': SendKeys.SendWait("{{}"); break;
                        case '}': SendKeys.SendWait("{}}"); break;
                        case '+': SendKeys.SendWait("{+}"); break;
                        case '^': SendKeys.SendWait("{^}"); break;
                        case '%': SendKeys.SendWait("{%}"); break;
                        case '~': SendKeys.SendWait("{~}"); break;
                        case '(': SendKeys.SendWait("{(}"); break;
                        case ')': SendKeys.SendWait("{)}"); break;
                        default: SendKeys.SendWait(c.ToString()); break;
                    }
                }
                if (autoSubmit)
                {
                    SendKeys.SendWait("{ENTER}");
                }
            });
        }

        public static void TypeClipboard()
        {
            if (Clipboard.ContainsText(TextDataFormat.UnicodeText))
            {
                String clipboard = Clipboard.GetText(TextDataFormat.UnicodeText);
                TypeText(clipboard);
            }
        }
    }
}
