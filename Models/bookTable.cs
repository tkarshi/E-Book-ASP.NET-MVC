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
    
    public partial class bookTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public bookTable()
        {
            this.orderDetailsTables = new HashSet<orderDetailsTable>();
        }
    
        public int Id { get; set; }
        public int bookTypeIdFk { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string imageUrl { get; set; }
    
        public virtual bookTypeTable bookTypeTable { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<orderDetailsTable> orderDetailsTables { get; set; }
    }
}