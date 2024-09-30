using System;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Threading.Tasks;
using ComeBackLuci.Mirlif;

namespace ComeBackLuci
{
    public partial class MiniConfig : Form
    {
        public MiniConfig()
        {
            InitializeComponent();
        }

        private void BTN_Check_Click(object sender, EventArgs e)
        {
            if (CheckTB()) return;

            BTN_Check.Enabled = false;
            BTN_Check.Text = "Sending...";

            Task.Run(() =>
            {
                SH_Client.SendMessage(TB_URL.Text);

                BTN_Check.Invoke((MethodInvoker)(() =>
                {
                    BTN_Check.Enabled = true;
                    BTN_Check.Text = "Check";
                }));
            });
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            if (CheckTB()) return;

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["client"].Value = Convert.ToBase64String(Encoding.Unicode.GetBytes(TB_URL.Text));
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");

            this.Close();
        }

        private bool CheckTB()
        {
            errorProviderConfig.Clear();

            if (!TB_URL.Text.Contains("https://discord.com/api/webhooks/"))
            {
                errorProviderConfig.SetError(TB_URL, "Enter a valid webhook!");
                return true;
            }

            return false;
        }
    }
}
