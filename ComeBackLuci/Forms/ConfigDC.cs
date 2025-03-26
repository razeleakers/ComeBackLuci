using System.Windows.Forms;
using System.Threading.Tasks;

namespace ComeBackLuci
{
    public partial class ConfigDC : Form
    {
        public ConfigDC()
        {
            InitializeComponent();
        }

        private void BTN_Check_Click(object sender, System.EventArgs e)
        {
            if (CheckTB()) return;

            BTN_Check.Enabled = false;
            BTN_Check.Text = "Sending...";

            Task sendMSG = Task.Run(() => ClientManager.SendMessage(TB_Webhook.Text));

            sendMSG.ContinueWith(t =>
            {
                BTN_Check.Enabled = true;
                BTN_Check.Text = "Check";
            },TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void BTN_Save_Click(object sender, System.EventArgs e)
        {
            if (CheckTB()) return;

            SettingsManager.Webhook = TB_Webhook.Text;
            SettingsManager.Save();

            this.Close();
        }

        private bool CheckTB()
        {
            errorProviderConfig.Clear();

            if (string.IsNullOrWhiteSpace(TB_Webhook.Text) || !TB_Webhook.Text.Contains("https://discord.com/api/webhooks/"))
            {
                errorProviderConfig.SetError(TB_Webhook, "Enter a valid webhook!");

                return true;
            }

            return false;
        }
    }
}
