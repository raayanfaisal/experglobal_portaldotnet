using System;
using System.Threading.Tasks;
using expertglobal.Model;

namespace expertglobal.Services
{
    public interface SecurityInterface
    {
      Task< object> AuthUser(User value);
    }
}
