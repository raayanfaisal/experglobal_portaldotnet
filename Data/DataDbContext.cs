using System;
using expertglobal.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace expertglobal.Data
{
    public class DataDbContext:IdentityDbContext<UserBio>
    {
        public DataDbContext(DbContextOptions<DataDbContext>options)
            :base(options)
        {
        }
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<OnlineClientReg> OnlineClientRegs { get; set; }
        public DbSet<Inquery> Inqueries { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<CustomerDetail> CustomerDetails { get; set; }
    }
}
