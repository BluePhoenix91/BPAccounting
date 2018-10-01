using BPAccounting.Data;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace BPAccounting.Core
{
    public class YearResultViewModel : BaseViewModel
    {
        #region Singleton

        /// <summary>
        /// a single instance for binding purposes
        /// </summary>
        public static YearResultViewModel Instance = new YearResultViewModel();

        #endregion

        #region Private fields

        /// <summary>
        /// List of all the invoices for this calculation
        /// </summary>
        private List<Invoice> Invoices { get; set; } = new List<Invoice>();

        #endregion

        #region Public properties

        /// <summary>
        /// The year for which the result is calculated
        /// </summary>
        public int CalculationYear { get; set; }

        /// <summary>
        /// Sales made in the considered year
        /// </summary>
        public double Sales { get; set; }

        /// <summary>
        /// Costs made in the considered year
        /// </summary>
        public double Costs { get; set; }

        /// <summary>
        /// Difference between the sales and the costs
        /// </summary>
        public double OperatingResult { get; set; }

        /// <summary>
        /// Financial gains in the considered year
        /// </summary>
        public double FinancialGain { get; set; }

        /// <summary>
        /// Financial costs in the considered year
        /// </summary>
        public double FinancialCosts { get; set; }

        /// <summary>
        /// Result of the financial gains and costs
        /// </summary>
        public double FinancialResult { get; set; }

        /// <summary>
        /// Total result of the considered year
        /// </summary>
        public double Result { get; set; }

        #endregion

        #region Commands

        public ICommand CalculateResultCommand { get; set; }

        #endregion

        #region Constructor

        public YearResultViewModel()
        {
            CalculateResultCommand = new RelayCommand(() => CalculateResult());

        }

        #endregion

        #region Public methods

        public void CalculateResult()
        {
            RetrieveElements();

            OperatingResult = Sales - Costs;
            FinancialResult = FinancialGain - FinancialCosts;
            Result = OperatingResult + FinancialResult;
        }

        public void RetrieveElements()
        {
            var invoices = new List<Invoice>();

            for (int i = 1; i < 4; i++)
            {
                invoices.AddRange(IoC.ClientDataStore.GetInvoices(i, CalculationYear));
            }

            foreach (var invoice in invoices)
            {
                if(Types.SalesInvoiceTypes.Where(type => type.Name == invoice.Type.Name).Count() > 0 )
                {
                    Sales += invoice.AmGoods;
                }

                if (Types.PurchaseInvoiceTypes.Where(type => type.Name == invoice.Type.Name).Count() > 0)
                {
                    Costs += invoice.AmGoods;
                }
            }
        }

        #endregion
    }
}
