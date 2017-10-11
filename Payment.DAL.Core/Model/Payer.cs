//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Payment.DAL.Core.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Payer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Payer()
        {
            this.PaymentInvoices = new HashSet<PaymentInvoice>();
        }
    
        public long Id { get; set; }
        public string Surname { get; set; }
        public string Othername { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<int> SchId { get; set; }
        public Nullable<long> periodId { get; set; }
        public string RefNo { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNo { get; set; }
    
        public virtual FiscalPeriod FiscalPeriod { get; set; }
        public virtual School School { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PaymentInvoice> PaymentInvoices { get; set; }
    }
}
