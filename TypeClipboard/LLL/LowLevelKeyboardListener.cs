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
        private const int WM_KEYUP = 0x0101;
        private const int WM_SYSKEYUP = 0x0105;

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

        private static HashSet<Key> _currentKeys = new HashSet<Key>();

        private string? _currentHotkeyCandidate = null;

        private nint HookCallback(int nCode, nint wParam, nint lParam)
        {
            if (nCode >= 0)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                Key key = KeyInterop.KeyFromVirtualKey(vkCode);

                if (wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN)
                {
                    _currentKeys.Add(key);
                    _currentHotkeyCandidate = GetCombinationString(_currentKeys);

                    if (MainPaster.GetInstance().Listening == null)
                    {
                        if (_currentHotkeyCandidate.Equals(Properties.Settings.Default.PasteHotkey, StringComparison.OrdinalIgnoreCase) && !Typer.IsTyping)
                        {
                            Typer.TypeClipboard();
                            return new nint(1);
                        }
                        else if (_currentHotkeyCandidate.Equals(Properties.Settings.Default.CancelHotkey, StringComparison.OrdinalIgnoreCase))
                        {
                            Typer.IsTyping = false;
                            return new nint(1);
                        }
                    } else
                    {
                        return new nint(1);
                    }

                    OnKeyPressed?.Invoke(this, new KeyPressedArgs(key));
                }
                else if (wParam == WM_KEYUP || wParam == WM_SYSKEYUP)
                {
                    _currentKeys.Remove(key);

                    if (_currentKeys.Count == 0 && MainPaster.GetInstance().Listening != null)
                    {
                        var hkType = MainPaster.GetInstance().Listening;
                        if (!string.IsNullOrEmpty(_currentHotkeyCandidate))
                        {
                            switch (hkType)
                            {
                                case HotkeyTypes.PASTE:
                                    Properties.Settings.Default.PasteHotkey = _currentHotkeyCandidate;
                                    break;
                                case HotkeyTypes.CANCEL:
                                    Properties.Settings.Default.CancelHotkey = _currentHotkeyCandidate;
                                    break;
                            }
                            Properties.Settings.Default.Save();
                            MainPaster.GetInstance().SetHK(_currentHotkeyCandidate, hkType);
                            MainPaster.GetInstance().Listening = null;
                        }
                        _currentHotkeyCandidate = null;
                    }
                }
            }

            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        private string GetCombinationString(IEnumerable<Key> keys)
        {
            KeysConverter kc = new KeysConverter();
            var orderedKeys = keys.OrderBy(k =>
            {
                if (k == Key.LeftCtrl || k == Key.RightCtrl)
                    return 0;
                if (k == Key.LeftShift || k == Key.RightShift)
                    return 1;
                if (k == Key.LeftAlt || k == Key.RightAlt)
                    return 2;
                return 3;
            }).ThenBy(k => kc.ConvertToString(k));

            return string.Join("+", orderedKeys.Select(k => kc.ConvertToString(k)));
        }
    }

    public class KeyPressedArgs(Key key) : EventArgs
    {
        public Key KeyPressed { get; private set; } = key;
    }
}