using BPAccounting.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BPAccounting.Core
{
    public class InvoiceInputViewModel : BaseViewModel
    {
        #region Singleton

        public static InvoiceInputViewModel Instance = new InvoiceInputViewModel();

        #endregion

        #region private members

        private DateTime _invoiceDate;

        /// <summary>
        /// True if the invoice is from a supplier
        /// </summary>
        private bool _isIncoming = true;

        /// <summary>
        /// Collection of Customers
        /// </summary>
        private List<Stakeholder> Customers;

        /// <summary>
        /// Collection of Suppliers
        /// </summary>
        private List<Stakeholder> Suppliers;

        /// <summary>
        /// The amount of VAT on the invoice
        /// </summary>
        private double _amountVAT;

        /// <summary>
        /// The amount of value of goods on the invoice
        /// </summary>
        private double _amountGoods;

        /// <summary>
        /// The selected customer or supplier
        /// </summary>
        Stakeholder _selectedCustomerSupplier;

        /// <summary>
        /// The selected customer or supplier
        /// </summary>
        InvoiceType _typeSelected;

        /// <summary>
        /// The selected customer or supplier
        /// </summary>
        Deductibility _deductibilitySelected;

        /// <summary>
        /// The selected customer or supplier
        /// </summary>
        Division _divisionSelected;


        #endregion

        #region public properties

        /// <summary>
        /// Date on the invoice
        /// </summary>
        public DateTime InvoiceDate
        {
            get => _invoiceDate;
            set
            {
                _invoiceDate = value;
                PeriodQuarter = GetQuarter(_invoiceDate);
                PeriodYear = _invoiceDate.Year;
            }
        }

        /// <summary>
        /// The quarter of the year the invoice belongs too, from a VAT-point of view
        /// </summary>
        public int PeriodQuarter { get; set; }

        /// <summary>
        /// The year of the invoice belongs too, from a VAT-point of view
        /// </summary>
        public int PeriodYear { get; set; }

        /// <summary>
        /// Amount of the goods on the invoice
        /// </summary>
        public double AmGoods
        {
            get => _amountGoods;
            set
            {
                _amountGoods = value;
                // Update total
                AmTotal = AmGoods + AmVat;
            }
        }

        /// <summary>
        /// Amount of the VAT on the invoice
        /// </summary>
        public double AmVat
        {
            get => _amountVAT;
            set
            {
                _amountVAT = value;
                // Update total
                AmTotal = AmGoods + AmVat;
            }
        }

        /// <summary>
        /// Total amount of the invoice
        /// </summary>
        public double AmTotal { get; set; }

        /// <summary>
        /// True if the invoice is from a supplier
        /// </summary>
        public bool IsIncoming
        {
            get => _isIncoming;
            set
            {
                _isIncoming = value;
                // Retrieve the suppliers and customers
                // TODO: Replace this with a flag that is set when
                //       new customer / supplier is created.
                GetStakeholders();
                // When choosing for suppliers
                if (value)
                {
                    CustomersSuppliers = new ObservableCollection<Stakeholder>(Suppliers);
                    InvoiceTypes = new ObservableCollection<InvoiceType>(Types.PurchaseInvoiceTypes);
                    // Log
                    Console.WriteLine("Suppliers selected");
                }
                // When choosing for customers
                else
                {
                    CustomersSuppliers = new ObservableCollection<Stakeholder>(Customers);
                    InvoiceTypes = new ObservableCollection<InvoiceType>(Types.SalesInvoiceTypes);
                    // Log
                    Console.WriteLine("Customers selected");
                }
            }
        }

        /// <summary>
        /// List with either customers or suppliers
        /// </summary>
        public ObservableCollection<Stakeholder> CustomersSuppliers { get; set; }

        /// <summary>
        /// Still to be implemented
        /// </summary>
        public ObservableCollection<InvoiceType> InvoiceTypes { get; set; }

        /// <summary>
        /// Collection of divisions
        /// </summary>
        public ObservableCollection<Division> Divisions { get; set; } = new ObservableCollection<Division>(Types.DivisionTypes);

        /// <summary>
        /// List with different types of taxiblity
        /// </summary>
        public ObservableCollection<Deductibility> Deductibility { get; set; } = new ObservableCollection<Deductibility>(Types.DeductibilityTypes);

        /// <summary>
        /// Helper for the selected customer or supplier
        /// </summary>
        public Stakeholder SelectedCustomerSupplier
        {
            get => _selectedCustomerSupplier;
            set
            {
                if (value != null)
                {
                    _selectedCustomerSupplier = value;
                    // Log
                    Console.WriteLine("The selected customer or supplier is:" + value.Name);
                }
            }
        }

        /// <summary>
        /// Helper for the selected type
        /// </summary>
        public InvoiceType TypeSelected
        {
            get => _typeSelected;
            set
            {
                if (value != null)
                {
                    _typeSelected = value;
                    // Log
                    Console.WriteLine("The selected invoice type is:" + _typeSelected.Name);
                }
            }
        }

        /// <summary>
        /// Helper for the selected Division
        /// </summary>
        public Division DivisionSelected
        {
            get => _divisionSelected;
            set
            {
                if (value != null)
                {
                    _divisionSelected = value;
                    // Log
                    Console.WriteLine("The selected division is:" + _divisionSelected.Name);
                }
            }
        }

        /// <summary>
        /// Helper for the selected Taxibility
        /// </summary>
        public Deductibility DeductibilitySelected
        {
            get => _deductibilitySelected;
            set
            {
                if (value != null)
                {
                    _deductibilitySelected = value;
                    // Log
                    Console.WriteLine("The selected customer or supplier is:" + _deductibilitySelected.Name);
                }
            }
        }

        /// <summary>
        /// Saves the invoice to the database
        /// </summary>
        public RelayCommand CreateInvoiceCommand { get; set; }

        /// <summary>
        /// Resets the invoice input fields
        /// </summary>
        public RelayCommand ResetInvoiceCommand { get; set; }

        #endregion

        #region constructor

        /// <summary>
        /// The default constructor
        /// </summary>
        public InvoiceInputViewModel()
        {
            CreateInvoiceCommand = new RelayCommand(() => SaveInvoice());
            ResetInvoiceCommand = new RelayCommand(() => ResetInvoice());
            InvoiceDate = DateTime.Now;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Saves an invoice to the database
        /// </summary>
        public void SaveInvoice()
        {
            var invoice = new Invoice()
            {
                StakeholderId = SelectedCustomerSupplier.StakeholderId,
                AmGoods = AmGoods,
                AmVat = AmVat,
                AmTotal = AmTotal,
                InvoiceDate = InvoiceDate,
                PeriodQuarter = PeriodQuarter,
                PeriodYear = PeriodYear,
                Type = TypeSelected,
                Division = DivisionSelected,
                Deduct = DeductibilitySelected,
            };
            IoC.ClientDataStore.SaveInvoice(invoice);
            ResetInvoice();
        }

        /// <summary>
        /// Resets the invoice input fields
        /// </summary>
        public void ResetInvoice()
        {
            AmGoods = 0;
            AmVat = 0;
        }


        public int GetQuarter(DateTime fromDate)
        {
            int month = fromDate.Month - 1;
            int month2 = Math.Abs(month / 3) + 1;
            return month2;
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Gets all the stakeholders from the database and copies them to their collections
        /// </summary>
        private void GetStakeholders()
        {
            Suppliers = IoC.ClientDataStore.GetSuppliers();
            Customers = IoC.ClientDataStore.GetCustomers();
            // Log
            Console.WriteLine(Suppliers.Count + " supplier(s), customer(s):" + Customers.Count);
        }

        #endregion
    }
}
