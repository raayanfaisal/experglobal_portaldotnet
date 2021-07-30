using System;
using System.Linq;
using expertglobal.Data;
using expertglobal.Model;

namespace expertglobal.Services
{
    public class InqueryService : InqueryInterface
    {
        private readonly DataDbContext _db;

        public InqueryService(DataDbContext _db)
        {
            this._db = _db;
        }

        public void Delete(int id)
        {
            try
            {
                var del = new Inquery
                {
                    Id = id
                };
                _db.Inqueries.Remove(del);
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
                return _db.Inqueries.OrderByDescending(x => x.Id).ToList();
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
                return _db.Inqueries.Find(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Post(Inquery value)
        {
            try
            {
                _db.Inqueries.Add(value);
                _db.SaveChanges();
                var auditLog = new AuditLog
                {
                    Action = $"inquery created by {value.CustomerName} ,idcard {value.IDard}, on {DateTime.Now.ToShortDateString()}" +
                     $"at {DateTime.Now.ToShortTimeString()}",
                    Date = DateTime.Now,
                    Staff = value.CustomerName,
                    Task = "inquery generating"
                };
                _db.AuditLogs.Add(auditLog);

                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Put(int id, Inquery value)
        {
            try
            {
                var result = _db.Inqueries.Find(id);
                if (value.Active != result.Active)
                {
                    result.Active = value.Active;
                }
                if (result.AssignTo != value.AssignTo)
                {
                    result.AssignTo = value.AssignTo;
                }
                if (result.CustomertStatus != value.CustomertStatus)
                {
                    result.CustomertStatus = value.CustomertStatus;
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
