using Payment.DAL.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.DAL.Core
{
    public class PaymentContext: DbContext
    {
        public PaymentContext():base("PaymentContext")
        {

        }
        public DbSet<School> Schools { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<AccountDetail> AccountDetails { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
