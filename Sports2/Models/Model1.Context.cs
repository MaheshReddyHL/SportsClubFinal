﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sports2.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FinalcaseEntities1 : DbContext
    {
        public FinalcaseEntities1()
            : base("name=FinalcaseEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<ClubRule> ClubRules { get; set; }
        public virtual DbSet<Facility> Facilities { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<MembershipCharge> MembershipCharges { get; set; }
        public virtual DbSet<TimeSlotRequest> TimeSlotRequests { get; set; }
        public virtual DbSet<TimeSlot> TimeSlots { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
