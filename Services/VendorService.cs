using System;
using System.Linq;
using expertglobal.Data;
using expertglobal.Model;

namespace expertglobal.Services
{
    public class VendorService: VendorInterface
    {
        private readonly DataDbContext _db;
        public VendorService(DataDbContext _db)
        {
            this._db = _db;
        }

        public void Delete(int id)
        {
            try
            {
                var del = new Vendor
                {
                    Id = id
                };
                _db.Vendors.Remove(del);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public object Get()
        {
            try
            {
                return _db.Vendors.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public object Get(int id)
        {
            try
            {
                return _db.Vendors.Find(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Post(Vendor value)
        {
            try
            {
                _db.Vendors.Add(value);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Put(int id, Vendor value)
        {
            try
            {
                var result = _db.Vendors.Find(id);
                if (value.Email.Length >0)
                {
                    result.Email = value.Email;
                }
                if (value.ContactNumber.Length>0)
                {
                    result.ContactNumber = value.ContactNumber;
                }
                if (value.Name.Length > 0)
                {
                    result.Name = value.Name;
                }
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
