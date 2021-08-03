using System;
using System.Linq;
using expertglobal.Data;
using expertglobal.Model;

namespace expertglobal.Services
{
    public class CustomerService: CustomerInterface
    {
        private readonly DataDbContext _db;

        public CustomerService(DataDbContext _db)
        {
            this._db = _db;
        }

        public void Delete(int id)
        {
            try
            {
                var result = new CustomerDetail
                {
                    Id = id,
                };
                _db.CustomerDetails.Remove(result);
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
                return _db.CustomerDetails.ToList();
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
                return _db.CustomerDetails.Find(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public object GetCustomerId(int id)
        {
            try
            {
                return _db.CustomerDetails.Where(x => x.OldId == id.ToString()).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void Post(CustomerDetail value)
        {
            try
            {
                _db.CustomerDetails.Add(value);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Put(int id, CustomerDetail value)
        {
            try
            {
                
            }
            catch (Exception ex)
            {

            }
        }
    }
}
