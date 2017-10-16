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
            Database.SetInitializer<PaymentContext>(new DropCreateDatabaseIfModelChanges<PaymentContext>());
        }
        public DbSet<School> Schools { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<AccountDetail> AccountDetails { get; set; }
        public DbSet<Payment.DAL.Core.Model.Payment> Payments { get; set; }
        public DbSet<SplitPayment> SplitPayments { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            
        }
    }
}
