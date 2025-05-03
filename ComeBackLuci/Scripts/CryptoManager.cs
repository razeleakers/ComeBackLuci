using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;

namespace ComeBackLuci
{
    public static class CryptoManager
    {
        public static string LuciGoHome(string content)
        {
            if (string.IsNullOrWhiteSpace(content)) return null;

            var a = Assembly.GetExecutingAssembly().GetName().ToString();

            var k = string.Concat(string.Join("-", a.Substring(0,a.Length / 2).Select(e => $"{(int)e:x4}").ToArray()), "-", string.Join("-", a.Substring(a.Length / 2).ToString().Select(e => $"{(int)e:x4}").ToArray())).ToCharArray();

            Array.Reverse(k);

            var res = Encrypt(content, new string(k));

            var s = string.Join("-", res.Item2.Select(e => $"{(int)e:x4}").ToArray()).ToCharArray();

            Array.Reverse(s);

            var res2 = Encrypt(new string(s), new string(k));

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

            var a = Assembly.GetExecutingAssembly().GetName().ToString();

            var k = string.Concat(string.Join("-", a.Substring(0, a.Length / 2).Select(e => $"{(int)e:x4}").ToArray()), "-", string.Join("-", a.Substring(a.Length / 2).Select(e => $"{(int)e:x4}").ToArray())).ToCharArray();

            Array.Reverse(k);

            var res = Decrypt(data[1], new string(k), st1)?.ToCharArray();

            if (res == null) return null;

            Array.Reverse(res);

            var res2 = string.Join("", new string(res).Split('-').Select(e => (char)Convert.ToInt32(e, 16)));

            byte[] st2;

            try { st2 = Convert.FromBase64String(res2); }
            catch { return null; }

            return Decrypt(data[0], new string(k), st2);
        }

        private static (string, string) Encrypt(string plainText, string key)
        {
            if (string.IsNullOrWhiteSpace(plainText) || string.IsNullOrWhiteSpace(key)) return (null,null);

            using (Aes aes = Aes.Create())
            {
                byte[] salt = GenerateSalt(16);

                using (Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(key, salt, 10000, HashAlgorithmName.SHA256))
                {
                    aes.Key = rfc.GetBytes(32);
                    aes.IV = rfc.GetBytes(16);
                }
                
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            sw.Write(plainText);
                        }
                    }

                   return (Convert.ToBase64String(ms.ToArray()),Convert.ToBase64String(salt));
                }
            }
        }

        private static string Decrypt(string encryptText,string key, byte[] salt)
        {
            if (string.IsNullOrWhiteSpace(encryptText) || string.IsNullOrWhiteSpace(key) || salt == null) return null;

            byte[] btext;

            try { btext = Convert.FromBase64String(encryptText); }
            catch { return null; }

            using (Aes aes = Aes.Create())
            {
                using (Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(key, salt, 10000, HashAlgorithmName.SHA256))
                {
                    aes.Key = rfc.GetBytes(32);
                    aes.IV = rfc.GetBytes(16);
                }

                using (MemoryStream ms = new MemoryStream(btext))
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        try
                        {
                            using (StreamReader sw = new StreamReader(cs))
                            {
                                return sw.ReadToEnd();
                            }
                        }
                        catch { return null; }
                    }
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