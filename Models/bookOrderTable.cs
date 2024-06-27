//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EBookPvt.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class bookOrderTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public bookOrderTable()
        {
            this.customerPaymentTables = new HashSet<customerPaymentTable>();
            this.feedbackTables = new HashSet<feedbackTable>();
            this.orderDetailsTables = new HashSet<orderDetailsTable>();
        }
    
        public int Id { get; set; }
        public int cusIdFk { get; set; }
        public System.DateTime orderDate { get; set; }
        public System.DateTime deliveryDate { get; set; }
        public int totalAmount { get; set; }
        public int orderStatusIdFk { get; set; }
    
        public virtual customerTable customerTable { get; set; }
        public virtual orderStatusTable orderStatusTable { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<customerPaymentTable> customerPaymentTables { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<feedbackTable> feedbackTables { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<orderDetailsTable> orderDetailsTables { get; set; }
    }
}