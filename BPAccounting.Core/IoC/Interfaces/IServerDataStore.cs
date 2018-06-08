using BPAccounting.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BPAccounting.Core
{
    /// <summary>
    /// Stores and retrieves information about the client application 
    ///  such as customers, suppliers, settings ...
    /// </summary>
    public interface IServerDataStore
    {
        /// <summary>
        /// Makes sure the client data store is correctly set up
        /// </summary>
        /// <returns>Returns a task that will finish once setup is complete</returns>
        Task EnsureDataStoreAsync();

        /// <summary>
        /// Gets the stored stakeholders for this client
        /// </summary>
        /// <returns>Returns the stakeholders if they exist, or null if none exist</returns>
        List<Stakeholder> GetStakeholders();

        /// <summary>
        /// Get all suppliers
        /// </summary>
        /// <returns>returns a list of suppliers</returns>
        List<Stakeholder> GetSuppliers();

        /// <summary>
        /// Get all customers
        /// </summary>
        /// <returns>Returns a liust of customers</returns>
        List<Stakeholder> GetCustomers();

        /// <summary>
        /// Gets the stored invoices
        /// </summary>
        /// <returns>Returns the invoices if they exist, or null if none exist</returns>
        List<Invoice> GetInvoices();

        /// <summary>
        /// Get the stored invoices for a certain quarter of a certain year
        /// </summary>
        /// <param name="quarter">The specific quarter of the year</param>
        /// <param name="year">The specific year</param>
        /// <returns></returns>
        List<Invoice> GetInvoices(int quarter, int year);

        /// <summary>
        /// Gets the stored payments for this client
        /// </summary>
        /// <returns>Returns the payments if they exist, or null if none exist</returns>
        List<Payment> GetPayments();

        /// <summary>
        /// Stores the given stakeholder to the backing data store
        /// </summary>
        /// <param name="stakeholder">The customer to save</param>
        /// <returns>Return a task that will finish once the save is complete</returns>
        Task SaveStakeholder(Stakeholder stakeholder);

        /// <summary>
        /// Stores the given invoice to the backing data store
        /// </summary>
        /// <param name="invoice">The customer to save</param>
        /// <returns>Return a task that will finish once the save is complete</returns>
        Task SaveInvoice(Invoice invoice);

        /// <summary>
        /// Stores the given payment to the backing data store
        /// </summary>
        /// <param name="payment">The customer to save</param>
        /// <returns>Return a task that will finish once the save is complete</returns>
        Task SavePayment(Payment payment);
    }
}
