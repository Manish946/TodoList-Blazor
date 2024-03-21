using System.Security.Cryptography;

namespace TodoList_Blazor.HelperServies
{
	public class AsymmetricHandler
	{
		private string? privateKey;
		public string? publicKey;

        public AsymmetricHandler()
        {
            using (RSA RSA = RSA.Create())
            {
                // For Private Key
                RSAParameters privateKeyParameter = RSA.ExportParameters(true);
                privateKey = RSA.ToXmlString(true);

                // For Public Key
                RSAParameters publicKeyParameter = RSA.ExportParameters(false);
				publicKey = RSA.ToXmlString(false);


			}
        }
		//
		// Summary:
		//     Decrypts string with private key and returns decrypted string
		//
		public string DecryptAsymmetric(string textToDecrypt)
        {
			using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
				RSA.FromXmlString(privateKey);
				byte[] bytes = RSA.Decrypt(Convert.FromBase64String(textToDecrypt), false);
				return System.Text.Encoding.UTF8.GetString(bytes);
            }
        }
		public string EncryptAsymmetric(string textToEncrypt)
		{
			return Encrypter.Encrypt(textToEncrypt, publicKey);
		}


    }
}
