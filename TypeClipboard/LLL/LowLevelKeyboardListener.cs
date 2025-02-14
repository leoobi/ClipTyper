using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Input;

namespace TypeClipboard.LLL
{
    public class LowLevelKeyboardListener
    {
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_SYSKEYDOWN = 0x0104;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern nint SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, nint hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(nint hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern nint CallNextHookEx(nint hhk, int nCode, nint wParam, nint lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern nint GetModuleHandle(string lpModuleName);

        public delegate nint LowLevelKeyboardProc(int nCode, nint wParam, nint lParam);

        public event EventHandler<KeyPressedArgs>? OnKeyPressed;

        private LowLevelKeyboardProc _proc;
        private nint _hookID = nint.Zero;

        public LowLevelKeyboardListener() => _proc = HookCallback;

        public void HookKeyboard()
        {
            _hookID = SetHook(_proc);
        }

        public void UnHookKeyboard()
        {
            if (_hookID != nint.Zero)
            {
                UnhookWindowsHookEx(_hookID);
                _hookID = nint.Zero;
            }
        }

        private static nint SetHook(LowLevelKeyboardProc proc)
        {
            using Process curProcess = Process.GetCurrentProcess();
            using ProcessModule? curModule = curProcess.MainModule;
            if (curModule != null)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
            return nint.Zero;
        }

        private nint HookCallback(int nCode, nint wParam, nint lParam)
        {
            if (nCode >= 0 && wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                Key keyPressed = KeyInterop.KeyFromVirtualKey(vkCode);

                KeysConverter kc = new KeysConverter();
                string key = kc.ConvertToString(keyPressed)!;

                var hkType = MainPaster.GetInstance().Listening;
                if (hkType != null)
                {
                    switch (hkType)
                    {
                        case HotkeyTypes.PASTE:
                            Properties.Settings.Default.PasteHotkey = key;
                            break;
                        case HotkeyTypes.CANCEL:
                            Properties.Settings.Default.CancelHotkey = key;
                            break;
                    }
                    Properties.Settings.Default.Save();
                    MainPaster.GetInstance().SetHK(key, hkType);
                    return new nint(1);
                }
                else if (key == Properties.Settings.Default.PasteHotkey && !Typer.IsTyping)
                {
                    Typer.TypeClipboard();
                    return new nint(1);
                } else if(key == Properties.Settings.Default.CancelHotkey)
                {
                    Typer.IsTyping = false;
                    return new nint(1);
                }

                if (OnKeyPressed != null) { OnKeyPressed(this, new KeyPressedArgs(keyPressed)); }
            }

            return CallNextHookEx(_hookID, nCode, wParam, lParam);

        }
    }

    public class KeyPressedArgs(Key key) : EventArgs
    {
        public Key KeyPressed { get; private set; } = key;
    }
}