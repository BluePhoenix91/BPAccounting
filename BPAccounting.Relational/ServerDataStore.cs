using BPAccounting.Core;
using BPAccounting.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPAccounting.Relational
{
    /// <summary>
    /// Stores and retrieves information about the client application
    /// such as customers, suppliers, settings ... in and SQLite database
    /// </summary>
    public class ServerDataStore : IServerDataStore
    {

        #region Protected members

        /// <summary>
        /// The database context for the client data store
        /// </summary>
        protected ServerDataStoreDbContext _dbContext;

        #endregion

        #region Constructor
        
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="dbContext">The database to use</param>
        public ServerDataStore(ServerDataStoreDbContext dbContext)
        {
            // Set local member
            _dbContext = dbContext;
        }

        #endregion

        #region Interfact implementation

        /// <summary>
        /// Makes sure the client data store is correctly set up
        /// </summary>
        /// <returns>Returns a task that will finish once setup is complete</returns>
        public async Task EnsureDataStoreAsync()
        {
            // Make sure the database exists and is created
            await _dbContext.Database.EnsureCreatedAsync();
        }

        /// <summary>
        /// Gets the stored customers for this client
        /// </summary>
        /// <returns>Returns a list of stakeholders</returns>
        public List<Stakeholder> GetStakeholders()
        {
            // Get the first column in the login credentials table, or null if none exist
            return _dbContext.Stakeholders.ToList();
        }

        /// <summary>
        /// Get all suppliers
        /// </summary>
        /// <returns>returns a list of suppliers</returns>
        public List<Stakeholder> GetSuppliers()
        {
            // Get the first column in the login credentials table, or null if none exist
            return _dbContext.Stakeholders.Where(x => x.IsSupplier).ToList();
        }

        /// <summary>
        /// Get all customers
        /// </summary>
        /// <returns>Returns a liust of customers</returns>
        public List<Stakeholder> GetCustomers()
        {
            // Get the first column in the login credentials table, or null if none exist
            return _dbContext.Stakeholders.Where(x => !x.IsSupplier).ToList();
        }

        /// <summary>
        /// Gets the stored invoices
        /// </summary>
        /// <returns>Returns a list of invoices</returns>
        public List<Invoice> GetInvoices()
        {
            // Makes use of other tables, so load this
            // TODO: At the moment eager loading is used, maybe change to lazy loading?
            var invoices = _dbContext.Invoices
                .Include(Invoice => Invoice.Division)
                .Include(Invoice => Invoice.Type)
                .Include(Invoice => Invoice.Deduct)
                .ToList() ;
            return invoices;
        }

        /// <summary>
        /// Gets the stored invoices for a certain quarter and year
        /// </summary>
        /// <returns>Returns a list of invoices</returns>
        public List<Invoice> GetInvoices(int quarter, int year)
        {
            // Makes use of other tables, so load this
            // TODO: At the moment eager loading is used, maybe change to lazy loading?
            var invoices = _dbContext.Invoices
                .Where(p => p.PeriodYear == year)
                .Where(p => p.PeriodQuarter == quarter)
                .Include(Invoice => Invoice.Division)
                .Include(Invoice => Invoice.Type)
                .Include(Invoice => Invoice.Deduct)
                .ToList();
            return invoices;
        }

        /// <summary>
        /// Stores the given stakeholder to the backing data store
        /// </summary>
        /// <param name="stakeholder">The stakeholder to save</param>
        public async Task SaveStakeholder(Stakeholder stakeholder)
        {
            // Add new one
            _dbContext.Stakeholders.Add(stakeholder);

            // Save changes
            await _dbContext.SaveChangesAsync();
        }

        public async Task SaveInvoice(Invoice invoice)
        {
            // Add new one
            _dbContext.Invoices.Add(invoice);

            // Save changes
            await _dbContext.SaveChangesAsync();
        }


        public List<Payment> GetPayments()
        {
            throw new NotImplementedException();
        }


        public Task SavePayment(Payment payment)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
