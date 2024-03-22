namespace TodoList_Blazor.Services
{
    public interface IPrivateKeyStorageService
    {
        void setPrivateKey(string privateKey);
        string getPrivateKey();
        string getPublicKey();
    }
}
