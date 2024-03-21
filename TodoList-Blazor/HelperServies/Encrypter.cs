using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;

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
				byte[] bytes = System.Text.Encoding.UTF8.GetBytes(textToEncrypt);
				return Convert.ToBase64String(RSA.Encrypt(bytes, false));
			}
		}

	}
}
