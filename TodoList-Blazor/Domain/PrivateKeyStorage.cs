using System.ComponentModel.DataAnnotations;

namespace TodoList_Blazor.Domain
{
    public class PrivateKeyStorage
    {
        public int Id { get; set; }

        public string PrivateKey { get; set; }
    }
}
