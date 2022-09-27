using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Reflection.Metadata.Ecma335;

namespace UniqueIdentifier_gen
{
    public class encrypt
    {
        static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aes = Aes.Create())
            {
                aes.Key = Key;
                aes.IV = IV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                            
                        }
                        encrypted = msEncrypt.ToArray();
                        return encrypted;
                    }
                }
            }
        }
        public string EncryptToString(string input)
        {
            using (Aes myAes = Aes.Create())
            {
                byte[] encrypted = EncryptStringToBytes_Aes(input, myAes.Key, myAes.IV);
                return Convert.ToHexString(encrypted);
            }
        }
    }
    internal class Program
    {
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static string filepath() => Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/SilenceUID";
        public static bool envvar => Environment.GetEnvironmentVariable("SilenceUID") != null 
                                    && !Environment.GetEnvironmentVariable("SilenceUID").ToString().Equals("null");
        static void Main(string[] args)
        {
            encrypt encrypt = new encrypt();
            if (args.Length > 0)
            {
                var arguments = args[0];
                switch (arguments)
                {
                    case "-help":
                        Console.WriteLine(" ----[UID - gen]----");
                        Console.WriteLine(" ");
                        Console.WriteLine("Usage:");
                        Console.WriteLine("uid.exe -help       | Displays this example table.");
                        Console.WriteLine("uid.exe <string>    | Generates a random ID from the string.");
                        Console.WriteLine("uid.exe -q          | Same as with no arguments, but ONLY the ID is outputted.");
                        Console.WriteLine("uid.exe -q <string> | Same as -q, but with your own string.");
                        Console.WriteLine("uid.exe -v2         | Uses a 16 random ASCII characters to generate UID.");
                        Console.WriteLine("uid.exe -v2q        | Same as -q, but uses 16 random ASCII characters to generate UID.");
                        Console.WriteLine("uid.exe             | Generates a random ID from the current unix timestamp." + "\n");
                        Console.WriteLine(" ");
                        Console.WriteLine("Tip: To make UID not complain about no arguments, Make a file at '" + filepath() + "'.");
                        break;
                    default:
                        Console.WriteLine("Your Input: " + args[0]);
                        Console.WriteLine("Your ID: " + encrypt.EncryptToString(args[0]));
                        break;
                    case "-q":
                        if (args.Length > 1)
                        {
                            Console.WriteLine(encrypt.EncryptToString(args[1]));
                        }
                        else if (args.Length <= 1)
                        {
                            Console.WriteLine(encrypt.EncryptToString(DateTime.Now.Subtract(new DateTime(1970, 1, 1)).TotalSeconds.ToString()));
                        }
                        break;
                    case "-v2":
                        string randomString = RandomString(16);
                        Console.WriteLine("The Input: " + randomString);
                        Console.WriteLine("Your ID: " + encrypt.EncryptToString(randomString));
                        break;
                    case "-v2q":
                        Console.WriteLine(encrypt.EncryptToString(RandomString(16)));
                        break;
                }
            }
            else
            {
                if (filepath() != string.Empty)
                {
                    if (!File.Exists(filepath()))
                    {
                        Console.WriteLine("Note: You're running UID without any arguments, run 'uid.exe -help' for more info.\n");
                    }
                }

                Int32 unixTimestamp = (Int32)(DateTime.Now.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                Console.WriteLine("Your ID: " + encrypt.EncryptToString(unixTimestamp.ToString()));
            }
        }
    }
}