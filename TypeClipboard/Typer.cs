using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace TypeClipboard
{
    class Typer
    {
        public static Char[] specialChars = ['+', '%', '~', '(', ')', '{', '}', '[', ']'];
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
                    if (specialChars.Contains(c))
                    {
                        SendKeys.SendWait("{" + c + "}");
                    } else if (c == '^')
                    {
                        SendCaretGerman();
                    }
                    else
                    {
                        SendKeys.SendWait(c.ToString());
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

        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint SendInput(uint nInputs, [MarshalAs(UnmanagedType.LPArray)] INPUT[] pInputs, int cbSize);

        [StructLayout(LayoutKind.Sequential)]
        public struct INPUT
        {
            public int type;
            public InputUnion u;
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct InputUnion
        {
            [FieldOffset(0)] public MOUSEINPUT mi;
            [FieldOffset(0)] public KEYBDINPUT ki;
            [FieldOffset(0)] public HARDWAREINPUT hi;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct KEYBDINPUT
        {
            public ushort wVk;
            public ushort wScan;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public uint mouseData;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct HARDWAREINPUT
        {
            public uint uMsg;
            public ushort wParamL;
            public ushort wParamH;
        }

        const int INPUT_KEYBOARD = 1;
        const uint KEYEVENTF_KEYUP = 0x0002;
        const ushort VK_SHIFT = 0x10;
        const ushort VK_DEAD_CARET = 0xDC;
        const ushort VK_SPACE = 0x20;

        public static void SendCaretGerman()
        {
            INPUT[] inputs = new INPUT[6];

            inputs[1].type = INPUT_KEYBOARD;
            inputs[1].u.ki = new KEYBDINPUT { wVk = VK_DEAD_CARET };

            inputs[2].type = INPUT_KEYBOARD;
            inputs[2].u.ki = new KEYBDINPUT { wVk = VK_DEAD_CARET, dwFlags = KEYEVENTF_KEYUP };

            inputs[4].type = INPUT_KEYBOARD;
            inputs[4].u.ki = new KEYBDINPUT { wVk = VK_SPACE };

            inputs[5].type = INPUT_KEYBOARD;
            inputs[5].u.ki = new KEYBDINPUT { wVk = VK_SPACE, dwFlags = KEYEVENTF_KEYUP };

            SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(INPUT)));
        }

    }
}
