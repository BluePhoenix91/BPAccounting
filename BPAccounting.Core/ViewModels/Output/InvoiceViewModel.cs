using BPAccounting.Data;
using System;
using System.Linq;

namespace BPAccounting.Core
{
    public class InvoiceViewModel
    {
        #region Private fields

        private Invoice _model;

        #endregion

        #region Public properties

        /// <summary>
        /// Invoice number
        /// Must be consecutive for customer Invoices!
        /// </summary>
        public int InvoiceId { get => _model.InvoiceId; }

        /// <summary>
        /// Date on the Invoice
        /// </summary>
        public string InvoiceDate { get => _model.InvoiceDate.ToString("dd-MM-yyyy"); }

        /// <summary>
        /// The quarter of the year the invoice belongs too, from a VAT-point of view
        /// </summary>
        public int PeriodQuarter { get => _model.PeriodQuarter; }

        /// <summary>
        /// The year of the invoice belongs too, from a VAT-point of view
        /// </summary>
        public int PeriodYear { get => _model.PeriodYear; }

        /// <summary>
        /// Amount of the goods
        /// in Euro
        /// </summary>
        public double AmGoods { get => _model.AmGoods; }

        /// <summary>
        /// Amount of the VAT
        /// in Euro
        /// </summary>
        public double AmVat { get => _model.AmVat; }

        /// <summary>
        /// The total bill amount
        /// </summary>
        public double AmTotal { get => _model.AmTotal; }

        /// <summary>
        /// The type of Invoice
        /// Also connects to the correct VAT registration fields
        /// </summary>
        public string Type { get => _model.Type.Name; }

        /// <summary>
        /// Allows to split the invoice to 
        /// the purpose of the invoice (company - private)
        /// </summary>
        public string Division { get => _model.Division.Name; }

        /// <summary>
        /// Sets the deductibility of the invoice
        /// Is dependable on the current law
        /// </summary>
        public string Deduct { get => _model.Deduct.Name; }

        /// <summary>
        /// Links the bill with a <see cref="Stakeholder"/>
        /// IE a supplier
        /// </summary>
        public string Stakeholder { get; set; }

        #endregion

        #region Default constructor

        public InvoiceViewModel(Invoice invoice)
        {
            _model = invoice;
            Stakeholder = ((Stakeholder)IoC.ClientDataStore.GetStakeholders().Where(p => p.StakeholderId == invoice.StakeholderId).Single()).Name;
        }

        #endregion
    }
}
