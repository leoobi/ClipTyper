using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Timers;

namespace TypeClipboard.LLL
{
    internal class LowLevelMouseListener
    {
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int WH_MOUSE_LL = 14;
        private const int WM_RBUTTONDOWN = 0x0204;
        private const int WM_RBUTTONUP = 0x0205;

        private bool _rightButtonHeld = false;
        private System.Timers.Timer? _timer;

        private ActivePaster? _activePaster;

        private int startX = 0;
        private int startY = 0;

        [StructLayout(LayoutKind.Sequential)]
        private struct POINT
        {
            public int X;
            public int Y;
        }

        public delegate nint LowLevelMouseProc(int nCode, nint wParam, nint lParam);
        LowLevelMouseProc MouseHookProcedure;
        private nint _hookID = nint.Zero;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool UnhookWindowsHookEx(nint idHook);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int SetWindowsHookEx(int idHook, LowLevelMouseProc lpfn, nint hInstance, int threadId);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern nint GetModuleHandle(string lpModuleName);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int CallNextHookEx(nint hhk, int nCode, nint wParam, nint lParam);

        [DllImport("user32.dll")]
        private static extern void mouse_event(nint dwFlags, int dx, int dy, uint dwData, int dwExtraInfo);

        [DllImport("user32.dll")]
        private static extern nint GetForegroundWindow();

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetCursorPos(out POINT lpPoint);

        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);

        public LowLevelMouseListener() => MouseHookProcedure = HookCallback;

        public void HookMouse()
        {
            _hookID = SetHook(MouseHookProcedure);
        }

        public void UnHookMouse()
        {
            if (_hookID != nint.Zero)
            {
                UnhookWindowsHookEx(_hookID);
                _hookID = nint.Zero;
            }
        }

        private static nint SetHook(LowLevelMouseProc proc)
        {
            using Process curProcess = Process.GetCurrentProcess();
            using ProcessModule? curModule = curProcess.MainModule;
            if (curModule != null)
            {
                return SetWindowsHookEx(WH_MOUSE_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
            return nint.Zero;
        }

        private nint HookCallback(int nCode, nint wParam, nint lParam)
        {
            if (nCode >= 0)
            {
                if (wParam == WM_RBUTTONDOWN)
                {
                    if (GetCursorPos(out POINT p))
                    {
                        if (_activePaster != null &&
                            (p.X < _activePaster.Left ||
                            p.X > _activePaster.Left + _activePaster.Width ||
                            p.Y < _activePaster.Top ||
                            p.Y > _activePaster.Top + _activePaster.Height))
                        {
                            _activePaster.Close();
                            _activePaster = null;
                        }
                    }
                    startX = p.X;
                    startY = p.Y;

                    _timer = new System.Timers.Timer(500);
                    _timer.Elapsed += ElapsedEvent!;
                    _timer.AutoReset = false;
                    _timer.Start();
                }
                else if (wParam == WM_RBUTTONUP)
                {
                    if (_timer != null)
                    {
                        _timer.Stop();
                        _timer.Dispose();
                    }
                    if (_rightButtonHeld)
                    {
                        _rightButtonHeld = false;
                        SimulateLeftClick();
                    }
                }
            }

            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        private static async void SimulateLeftClick()
        {
            await createEvents();
        }

        private static async Task createEvents()
        {
            await Task.Run(() =>
            {
                if (GetCursorPos(out POINT p))
                {
                    SetCursorPos(p.X - 1, p.Y - 1);
                    mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                    mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                }
            });
        }

        private async void ElapsedEvent(object source, ElapsedEventArgs e)
        {
            if (GetCursorPos(out POINT p))
            {
                if (Math.Abs(p.X - startX) < 50 && Math.Abs(p.Y - startY) < 50)
                {
                    _rightButtonHeld = true;
                    await OpenForm();
                }
            }
        }

        private async Task OpenForm()
        {
            await Task.Run(() =>
            {
                MainPaster.GetInstance().Invoke((MethodInvoker)delegate
                {
                    _activePaster = ActivePaster.getInstance();
                    _activePaster.Show();
                    _activePaster.BringToFront();
                    if (GetCursorPos(out POINT p))
                    {
                        _activePaster.Left = p.X;
                        _activePaster.Top = p.Y;
                    }
                });
            });
        }
    }
}
