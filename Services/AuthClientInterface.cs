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
        Task <object> Approve(int id);
    }
}
