/*
 * Created by SharpDevelop.
 * User: Heather
 * Date: 17/03/2018
 * Time: 16:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SSUtility2 {
    /// <summary>
    /// Class with program entry point.
    /// </summary>
    internal sealed class Program {

        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;
        private static LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;

        /// <summary>
        /// Program entry point.
        /// </summary>
        [STAThread]
        private static void Main(string[] args) {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            _hookID = SetHook(_proc);
            Application.Run(new MainForm());
            UnhookWindowsHookEx(_hookID);

        }

        private static IntPtr SetHook(LowLevelKeyboardProc proc) {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule) {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
        static Keys currentKey = Keys.None;
        static Keys lastKey = Keys.None;

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam) {
            if (ApplicationIsActivated()) {
                if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN) {
                    Keys pressedKey = (Keys)Marshal.ReadInt32(lParam);

                    if (currentKey != Keys.None && currentKey != pressedKey) {
                        lastKey = currentKey;
                    }

                    if (currentKey != pressedKey) {
                        currentKey = pressedKey;

                        MainForm.m.KeyControl(currentKey, lastKey);
                    }
                }
                if (nCode >= 0 && wParam == (IntPtr)WM_KEYUP) {
                    MainForm.m.StopCam();
                    lastKey = Keys.None;
                    currentKey = Keys.None;
                }
            }

            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }


        public static bool ApplicationIsActivated() {
            var activatedHandle = GetForegroundWindow();
            if (activatedHandle == IntPtr.Zero) {
                return false;       // No window is currently activated
            }

            var procId = Process.GetCurrentProcess().Id;
            int activeProcId;
            GetWindowThreadProcessId(activatedHandle, out activeProcId);

            return activeProcId == procId;
        }


        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowThreadProcessId(IntPtr handle, out int processId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
        
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr GetFocus();

    }
}
