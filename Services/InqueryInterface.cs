using System;
using expertglobal.Model;

namespace expertglobal.Services
{
    public interface InqueryInterface
    {
        object Get();
        object Get(int id);
        void Post(Inquery value);
        void Put(int id, Inquery value);
        void Delete(int id);
        void AddVendorInquery(InqueryVendor value);
        object GetInqueryVendorList(int id);
    }
}
