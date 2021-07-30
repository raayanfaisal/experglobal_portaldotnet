using System;
using System.Collections.Generic;
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
        private readonly UserManager<UserBio> _um;
        private readonly SignInManager<UserBio> _sm;
        private readonly RoleManager<IdentityRole> _rm;
        private readonly IPasswordHasher<UserBio> _ih;


        public CleintManageService(
            DataDbContext _db,
            UserManager<UserBio> _um,
            SignInManager<UserBio> _sm,
            RoleManager<IdentityRole> _rm,
            IPasswordHasher<UserBio> _ih
            )
        {
            this._db = _db;
            this._um = _um;
            this._sm = _sm;
            this._rm = _rm;
            this._ih = _ih;

        }

        public async Task<bool> Approve(int id)
        {
            try
            {

                var user = _db.OnlineClientRegs.Where(x => x.Id == id).AsNoTracking().FirstOrDefault();

                var useregUser = new UserBio
                {
                    UserName = user.IDCard,
                    Email = user.Email,
                    PhoneNumber = user.CNumber,
                    FullName = user.FullName

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

        public async Task<bool> DeateTheUser(string userName)
        {
            try
            {
                var user = await _um.FindByNameAsync(userName);
                return true;
            }
            catch (Exception ex)
            {
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

        public async Task<bool> Exist(string idCard)
        {
            try
            {

                var result = await _um.FindByNameAsync(idCard);
                if (result != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
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

        public async Task<object> GetAllUsers()
        {
            try
            {
                List<User> userInfo = new List<User>();
                var result = _um.Users.ToList();
                foreach (var item in result)
                {
                    var roles = await _um.GetRolesAsync(item);
                    var x = new User
                    {
                        Email = item.Email,
                        FullName = item.FullName,
                        Roles = roles.ToArray(),
                        Number = item.PhoneNumber,
                        UserName = item.UserName

                    };
                    userInfo.Add(x);

                }
                return userInfo;
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

        public async Task<bool> RegUser(User value)
        {
            try
            {

                var useregUser = new UserBio
                {
                    UserName = value.UserName,
                    Email = value.Email,
                    PhoneNumber = value.Number,
                    FullName = value.FullName

                };
                var result = await _um.CreateAsync(useregUser, value.Password);
                if (result.Succeeded)
                {
                    foreach (var item in value.Roles)
                    {
                        if (item.Length > 0)
                        {
                            await _um.AddToRoleAsync(useregUser, item);
                            _db.SaveChanges();
                        }
                    }
                    var auditLog = new AuditLog
                    {
                        Action = $"{value.FullName} user name {value.UserName} was created on {DateTime.Now.ToShortDateString()} at {DateTime.Now.ToShortTimeString()}",
                        Date = DateTime.Now,
                        Staff = "admin user",
                        Task = "user create"
                    };
                    _db.AuditLogs.Add(auditLog);
                    _db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
