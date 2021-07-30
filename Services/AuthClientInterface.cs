using System;
using System.Threading.Tasks;
using expertglobal.Model;

namespace expertglobal.Services
{
    public interface AuthClientInterface
    {
        object Get();
        void Post(OnlineClientReg value);
        void Delete(int id);
        object Get(int id);
        Task<bool> RegUser(User value);
        Task <bool> Approve(int id);
        Task<bool> Exist(string idCard);
        Task<object> GetAllUsers();
        Task<bool> DeateTheUser(string userName);
    }
}
