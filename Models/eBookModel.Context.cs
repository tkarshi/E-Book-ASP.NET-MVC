﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ebookOrderDBEntities : DbContext
    {
        public ebookOrderDBEntities()
            : base("name=ebookOrderDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<bookOrderTable> bookOrderTables { get; set; }
        public virtual DbSet<bookTable> bookTables { get; set; }
        public virtual DbSet<bookTypeTable> bookTypeTables { get; set; }
        public virtual DbSet<customerPaymentTable> customerPaymentTables { get; set; }
        public virtual DbSet<customerTable> customerTables { get; set; }
        public virtual DbSet<feedbackTable> feedbackTables { get; set; }
        public virtual DbSet<orderDetailsTable> orderDetailsTables { get; set; }
        public virtual DbSet<orderStatusTable> orderStatusTables { get; set; }
        public virtual DbSet<userTable> userTables { get; set; }
    }
}
