using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text;

namespace TodoList_Blazor.HelperServies
{
	public class Encrypter
	{
        public static string Encrypt(string textToEncrypt, string publicKey)
        {
			return EncryptAsymmetric(textToEncrypt, publicKey);
		}
		private static string EncryptAsymmetric(string textToEncrypt, string publicKey)
		{
			using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
			{
                RSA.FromXmlString(publicKey);
                byte[] dataBytes = Encoding.UTF8.GetBytes(textToEncrypt);
                byte[] encryptedData = RSA.Encrypt(dataBytes, true);
                return Convert.ToBase64String(encryptedData);
            }
		}

	}
}
