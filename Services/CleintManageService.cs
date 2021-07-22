using System;
using System.Linq;
using System.Threading.Tasks;
using expertglobal.Data;
using expertglobal.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace expertglobal.Services
{
    public class CleintManageService : AuthClientInterface
    {
        private readonly DataDbContext _db;
        private readonly UserManager<IdentityUser> _um;
        private readonly SignInManager<IdentityUser> _sm;
        private readonly RoleManager<IdentityRole> _rm;
        private readonly IPasswordHasher<IdentityUser> _ih;


        public CleintManageService(
            DataDbContext _db,
            UserManager<IdentityUser> _um,
            SignInManager<IdentityUser> _sm,
            RoleManager<IdentityRole> _rm,
            IPasswordHasher<IdentityUser> _ih
            )
        {
            this._db = _db;
            this._um = _um;
            this._sm = _sm;
            this._rm = _rm;
            this._ih = _ih;

        }

        public async Task<object> Approve(int id)
        {
            try
            {
               
                var user = _db.OnlineClientRegs.Where(x=>x.Id == id).AsNoTracking().FirstOrDefault();

                var useregUser = new IdentityUser
                {
                    UserName = user.IDCard,
                    Email = user.Email,
                    PhoneNumber = user.CNumber

                };
                var result = await _um.CreateAsync(useregUser, user.Password);
                if (result.Succeeded)
                {
                    await _um.AddToRoleAsync(useregUser, "client");


                    _db.SaveChanges();

                    var auditLog = new AuditLog
                    {
                        Action = $"{user.FullName} registration was approved at {DateTime.Now.ToShortDateString()} at {DateTime.Now.ToShortTimeString()}",
                        Date = DateTime.Now,
                        Task = "Approve Client Registration"
                    };
                    _db.AuditLogs.Add(auditLog);
                    _db.SaveChanges();
                    var del = new OnlineClientReg
                    {
                        Id = id
                    };
                    _db.OnlineClientRegs.Remove(del);
                    _db.SaveChanges();
                    return true;


                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                var del = new OnlineClientReg
                {
                    Id = id
                };
                _db.OnlineClientRegs.Remove(del);
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
                return _db.OnlineClientRegs.ToList();
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
                return _db.OnlineClientRegs.Find(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Post(OnlineClientReg value)
        {
            try
            {
                _db.OnlineClientRegs.Add(value);
                _db.SaveChanges();

                var audit = new AuditLog
                {
                    Action = $"{value.FullName} ,{value.IDCard} request for register as a client ",
                    Date = DateTime.Now.Date,
                    Task = "client Registration"
       

                };
                _db.AuditLogs.Add(audit);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}
