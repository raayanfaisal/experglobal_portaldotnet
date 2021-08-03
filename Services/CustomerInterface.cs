using System;
using expertglobal.Model;

namespace expertglobal.Services
{
    public interface CustomerInterface
    {
        void Post(CustomerDetail value);
        object Get();
        object Get(int id);
        void Put(int id, CustomerDetail value);
        void Delete(int id);
        object GetCustomerId(int id);
    }
}
