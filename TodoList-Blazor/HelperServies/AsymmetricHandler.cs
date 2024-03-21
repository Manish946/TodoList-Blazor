using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text;
using TodoList_Blazor.Services;

namespace TodoList_Blazor.HelperServies
{
    public class AsymmetricHandler
    {
        private string? privateKey;
        public string? publicKey;

        private readonly IPrivateKeyStorageService _privateKeyStorageService;
        public AsymmetricHandler(IPrivateKeyStorageService privateKeyStorageService)
        {
            using (RSA RSA = RSA.Create())
            {
                _privateKeyStorageService = privateKeyStorageService;
                var existedPrivateKey = _privateKeyStorageService.getPrivateKey();
                var existedPublicKey = _privateKeyStorageService.getPublicKey();
                if (existedPrivateKey == "") // If private key doesn't exist
                {

                    // For Private Key
                    RSAParameters privateKeyParameter = RSA.ExportParameters(true);
                    privateKey = RSA.ToXmlString(true);

                    _privateKeyStorageService.setPrivateKey(privateKey);


                    // For Public Key
                    RSAParameters publicKeyParameter = RSA.ExportParameters(false);
                    publicKey = RSA.ToXmlString(false);
                    _privateKeyStorageService.setPrivateKey(publicKey);
                }
                else
                {
                    privateKey = existedPrivateKey;
                    publicKey = existedPublicKey;
                }
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
                byte[] dataBytes = Convert.FromBase64String(textToDecrypt);
                byte[] decryptedData = RSA.Decrypt(dataBytes, true);
                return Encoding.UTF8.GetString(decryptedData);
            }
        }
        public string EncryptAsymmetric(string textToEncrypt)
        {
            return Encrypter.Encrypt(textToEncrypt, publicKey);
        }
    }
}
