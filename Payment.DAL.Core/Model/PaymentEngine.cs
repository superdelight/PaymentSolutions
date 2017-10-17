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
    
    public partial class PaymentEngine
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PaymentEngine()
        {
            this.Payments = new HashSet<PaymentDetail>();
        }
    
        public int Id { get; set; }
        public string PaymentDescription { get; set; }
        public string MacKey { get; set; }
        public string PaymentId { get; set; }
        public string ProductId { get; set; }
        public string Currency { get; set; }
        public string PaymentUpdateURL { get; set; }
        public string PaymentCode { get; set;}
        public string PaymentURL { get; set; }
        public Nullable<int> SchId { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PaymentDetail> Payments { get; set; }
        public virtual School School { get; set; }
    }
}
