using BPAccounting.Data;
using System.Collections.ObjectModel;
using System.Linq;

namespace BPAccounting.Core
{
    public class ViewStakeholdersViewModel : BaseViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static ViewStakeholdersViewModel Instance => new ViewStakeholdersViewModel();

        #endregion

        #region Public properties

        public string HeaderText { get; set; } = "Some header text";

        /// <summary>
        /// Collection of all stakeholders
        /// </summary>
        public ObservableCollection<Stakeholder> Stakeholders { get; set; }

        /// <summary>
        /// Collection of all customers
        /// </summary>
        public ObservableCollection<Stakeholder> Customers { get; set; }

        /// <summary>
        /// Colelction of all suppliers
        /// </summary>
        public ObservableCollection<Stakeholder> Suppliers { get; set; }

        /// <summary>
        /// Collection fo all invoices
        /// </summary>
        public ObservableCollection<InvoiceViewModel> Invoices { get; set; } = new ObservableCollection<InvoiceViewModel>();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ViewStakeholdersViewModel()
        {
            Stakeholders = new ObservableCollection<Stakeholder>(IoC.ClientDataStore.GetStakeholders());
            Customers = new ObservableCollection<Stakeholder>(IoC.ClientDataStore.GetCustomers());
            Suppliers = new ObservableCollection<Stakeholder>(IoC.ClientDataStore.GetSuppliers());
            var invoices = new ObservableCollection<Invoice>(IoC.ClientDataStore.GetInvoices());
            foreach (var invoice in invoices)
            {
                var inv = new InvoiceViewModel(invoice);
                Invoices.Add(inv);
            }
        }

        #endregion
    }
}
