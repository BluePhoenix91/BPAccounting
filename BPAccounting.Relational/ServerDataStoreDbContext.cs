using BPAccounting.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// The database context for the client data tore
/// </summary>
namespace BPAccounting.Relational
{
    public class ServerDataStoreDbContext : DbContext
    {
        // Tables in the database
        #region DbSets

        /// <summary>
        /// The stakeholders table
        /// </summary>
        public DbSet<Stakeholder> Stakeholders { get; set; }

        /// <summary>
        /// The invoices table
        /// </summary>
        public DbSet<Invoice> Invoices { get; set; }

        /// <summary>
        /// The payments table
        /// </summary>
        public DbSet<Payment> Payments { get; set; }

        /// <summary>
        /// Table with invoice types
        /// </summary>
        public DbSet<InvoiceType> InvoiceTypes { get; set; }

        /// <summary>
        /// Table with deductibilities
        /// </summary>
        public DbSet<Deductibility> Deductibilities { get; set; }

        /// <summary>
        /// Table with divisions
        /// </summary>
        public DbSet<Division> Divisions { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="options"></param>
        public ServerDataStoreDbContext(DbContextOptions<ServerDataStoreDbContext> options) : base(options) { }

        #endregion

        #region Model creating

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Fluent API

            // Configure tables
            // -------------------
            //
            // Set Id as primary key
            modelBuilder.Entity<Stakeholder>().HasKey(a => a.StakeholderId);
            modelBuilder.Entity<Invoice>().HasKey(a => a.InvoiceId);
            modelBuilder.Entity<Payment>().HasKey(a => a.TransactionId);
            modelBuilder.Entity<InvoiceType>().HasKey(a => a.Id);
            modelBuilder.Entity<Division>().HasKey(a => a.Id);
            modelBuilder.Entity<Deductibility>().HasKey(a => a.Id);


            // TODO: Set up limits
        }

        #endregion

    }
}
