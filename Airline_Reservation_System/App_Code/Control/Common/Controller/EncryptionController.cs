using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.Web.Configuration;

/// <summary>
/// https://mustafabukulmez.com/2018/07/03/c-sharp-encrypt-decrypt/#close
/// </summary>
public class EncryptionController
{
    public EncryptionController()
    {
        
    }

    public static String Encrypt(String text)
    {
        String publicKey = WebConfigurationManager.AppSettings["PublicKey"];

        byte[] testData = Encoding.UTF8.GetBytes(text);
        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(1024))
        {
            try
            {
                rsa.FromXmlString(publicKey.ToString());
                byte[] encryptedData = rsa.Encrypt(testData, true);
                String base64Encrypted = Convert.ToBase64String(encryptedData);
                return base64Encrypted;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                rsa.PersistKeyInCsp = false;
            }
        }
    }

    public static String Decrypt(string text)
    {
        string BOS = "";
        try
        {
            var privateKey = WebConfigurationManager.AppSettings["PrivateKey"];
            var testData = Encoding.UTF8.GetBytes(text);
            using (var rsa = new RSACryptoServiceProvider(1024))
            {
                try
                {
                    var base64Encrypted = text;
                    rsa.FromXmlString(privateKey);
                    var resultBytes = Convert.FromBase64String(base64Encrypted);
                    var decryptedBytes = rsa.Decrypt(resultBytes, true);
                    var decryptedData = Encoding.UTF8.GetString(decryptedBytes);
                    return decryptedData.ToString();
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }
        }
        catch { return BOS; }
    }
}