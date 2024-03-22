using Microsoft.AspNetCore.DataProtection;

namespace TodoList_Blazor.HelperServies
{
	public class SymmetricHandler
	{
        private readonly IDataProtector _dataProtector;
        public SymmetricHandler(IDataProtectionProvider dataProtector)
        {
            _dataProtector = dataProtector.CreateProtector("Manish"); // Key
        }

        public string Encrypt(string textToEncrypt)
        {
            return _dataProtector.Protect(textToEncrypt);
        }
        
        public string Decrypt(string textToEncrypt)
        {
            return _dataProtector.Unprotect(textToEncrypt);
        }
    }
}
