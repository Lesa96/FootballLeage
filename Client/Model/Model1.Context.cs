﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class BazaZaLiguEntities : DbContext
    {
        public BazaZaLiguEntities()
            : base("name=BazaZaLiguEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Igrac> Igracs { get; set; }
        public virtual DbSet<Klub> Klubs { get; set; }
        public virtual DbSet<Liga> Ligas { get; set; }
        public virtual DbSet<Menadzer> Menadzers { get; set; }
        public virtual DbSet<Navijac> Navijacs { get; set; }
        public virtual DbSet<Obezbedjenje> Obezbedjenjes { get; set; }
        public virtual DbSet<Poseduje> Posedujes { get; set; }
        public virtual DbSet<Sponzor> Sponzors { get; set; }
        public virtual DbSet<Stadion> Stadions { get; set; }
        public virtual DbSet<Sudija> Sudijas { get; set; }
        public virtual DbSet<Trener> Treners { get; set; }
        public virtual DbSet<Vlasnik> Vlasniks { get; set; }
        public virtual DbSet<Vodi> Vodis { get; set; }
        public virtual DbSet<LogUser> LogUsers { get; set; }
        public virtual DbSet<transferistorija> transferistorijas { get; set; }
    
        public virtual ObjectResult<string> SumProcedura()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("SumProcedura");
        }
    
        public virtual ObjectResult<string> GetFreeTrenerProcedura()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("GetFreeTrenerProcedura");
        }
    }
}
