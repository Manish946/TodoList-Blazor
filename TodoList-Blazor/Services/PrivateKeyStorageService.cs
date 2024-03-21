using Microsoft.EntityFrameworkCore;
using TodoList_Blazor.Data;
using TodoList_Blazor.Domain;

namespace TodoList_Blazor.Services
{
    public class PrivateKeyStorageService : IPrivateKeyStorageService
    {
        private readonly DataContext _dataContext;

        public PrivateKeyStorageService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public string getPrivateKey()
        {
            var privateKeyStorage = _dataContext.PrivateKeyStorage.FirstOrDefault();
            if (privateKeyStorage != null)
            {
                return privateKeyStorage.PrivateKey;
            } else
            {
                return "";
            }
        }

        public string getPublicKey()
        {
            var privateKeyStorage = _dataContext.PrivateKeyStorage.Skip(1).FirstOrDefault();
            if (privateKeyStorage != null)
            {
                return privateKeyStorage.PrivateKey;
            }
            else
            {
                return "";
            }
        }

        public void setPrivateKey(string privateKey)
        {
            var privateKeyStorage = new PrivateKeyStorage
            {
                PrivateKey = privateKey
            };
            _dataContext.PrivateKeyStorage.Add(privateKeyStorage);
            _dataContext.SaveChanges();
        }
    }
}
