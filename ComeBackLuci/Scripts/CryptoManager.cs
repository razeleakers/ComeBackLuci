using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Security.Cryptography;

namespace ComeBackLuci
{
    public static class CryptoManager
    {
        public static string LuciGoHome(string content)
        {
            if (string.IsNullOrWhiteSpace(content)) return null;

            var a = Assembly.GetExecutingAssembly().GetName();

            var k = string.Concat(string.Join("-", a.Name.Select(e => $"{(int)e:x4}").ToArray()),"-", string.Join("-", a.Version.ToString().Select(e => $"{(int)e:x4}").ToArray())).ToCharArray();

            Array.Reverse(k);

            var res = Encrypt(new string(k), content);

            var s = string.Join("-", res.Item2.Select(e => $"{(int)e:x4}").ToArray()).ToCharArray();

            Array.Reverse(s);

            var res2 = Encrypt(new string(k),new string(s));

            return $"{res.Item1} {res2.Item1} {res2.Item2}";
        }

        public static string LuciWhereAreYou(string luciContent)
        {
            if (string.IsNullOrWhiteSpace(luciContent)) return null;

            var data = luciContent.Split(' ');

            if (data.Length != 3) return null;

            byte[] st1;

            try { st1 = Convert.FromBase64String(data[2]); }
            catch { return null; }

            var a = Assembly.GetExecutingAssembly().GetName();

            var k = string.Concat(string.Join("-", a.Name.Select(e => $"{(int)e:x4}").ToArray()), "-", string.Join("-", a.Version.ToString().Select(e => $"{(int)e:x4}").ToArray())).ToCharArray();

            Array.Reverse(k);

            var res = Decrypt(new string(k), data[1], st1)?.ToCharArray();

            if (res == null) return null;

            Array.Reverse(res);

            var res2 = string.Join("", new string(res).Split('-').Select(e => (char)Convert.ToInt32(e, 16)));

            byte[] st2;

            try { st2 = Convert.FromBase64String(res2); }
            catch { return null; }

            return Decrypt(new string(k), data[0], st2);
        }

        private static (string, string) Encrypt(string key,string originalText)
        {
            if (string.IsNullOrWhiteSpace(key) || string.IsNullOrWhiteSpace(originalText)) return (null,null);

            byte[] btext = Encoding.Unicode.GetBytes(originalText);

            using (Aes aes = Aes.Create())
            {
                byte[] salt = GenerateSalt(16);

                using (Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(key, salt,10000))
                {
                    aes.Key = rfc.GetBytes(32);
                    aes.IV = rfc.GetBytes(16);
                }
                
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(btext, 0, btext.Length);
                    }

                   return (Convert.ToBase64String(ms.ToArray()),Convert.ToBase64String(salt));
                }
            }
        }

        private static string Decrypt(string key,string encryptText, byte[] salt)
        {
            if (string.IsNullOrWhiteSpace(key) || string.IsNullOrWhiteSpace(encryptText) || salt == null) return null;

            byte[] btext;

            try { btext = Convert.FromBase64String(encryptText); }
            catch { return null; }

            using (Aes aes = Aes.Create())
            {
                using (Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(key, salt,10000))
                {
                    aes.Key = rfc.GetBytes(32);
                    aes.IV = rfc.GetBytes(16);
                }

                using (MemoryStream ms = new MemoryStream())
                {
                    try
                    {
                        using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(btext, 0, btext.Length);
                        }

                        return Encoding.Unicode.GetString(ms.ToArray());
                    }
                    catch { return null; }
                }
            }
        }

        private static byte[] GenerateSalt(int length)
        {
            byte[] salt = new byte[length];

            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return salt;
        }
    }
}