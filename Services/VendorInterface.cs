using System;
using expertglobal.Model;

namespace expertglobal.Services
{
    public interface VendorInterface
    {
        object Get();
        object Get(int id);
        void Post(Vendor value);
        void Delete(int id);
        void Put(int id, Vendor value);

    }
}
