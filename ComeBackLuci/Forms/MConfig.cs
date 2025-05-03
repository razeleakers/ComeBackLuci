using System;
using System.Windows.Forms;
using ComeBackLuci.Properties;

namespace ComeBackLuci
{
    public partial class MConfig : Form
    {
        public MConfig()
        {
            InitializeComponent();
        }

        private void BTN_Show_Click(object sender, EventArgs e)
        {
            TB_Password.PasswordChar = TB_Password.PasswordChar == '*' ? '\0' : '*';

            BTN_Show.Text = BTN_Show.Text == "Show" ? "Hide" : "Show";
        }

        private async void BTN_Send_Click(object sender, EventArgs e)
        {
            if (InvalidData()) return;

            BTN_Send.Text = "Sending...";
            BTN_Send.Enabled = false;
            BTN_Save.Enabled = false;

            using (MailManager mm = new MailManager(TB_Email.Text, TB_Password.Text, true))
            {
                await mm.Send(true);
            }

            BTN_Send.Text = "Send Message";
            BTN_Send.Enabled = true;
            BTN_Save.Enabled = true;
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            if (InvalidData()) return;

            this.Hide();

            Settings.Default.User = CryptoManager.LuciGoHome(TB_Email.Text) ?? string.Empty;
            Settings.Default.Password = CryptoManager.LuciGoHome(TB_Password.Text) ?? string.Empty;
            Settings.Default.Save();

            this.Close();
        }

        private bool InvalidData()
        {
            EP_Form.Clear();

            bool invalid = false;

            if (!TB_Email.Text.Contains("@gmail.com"))
            {
                EP_Form.SetError(TB_Email,"Enter a valid email!");

                invalid = true;
            }

            if (string.IsNullOrWhiteSpace(TB_Password.Text))
            {
                EP_Form.SetError(TB_Password, "Enter a valid password!");

                invalid = true;
            }

            return invalid;
        }
    }
}