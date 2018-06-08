using System;

namespace BPAccounting.Data
{
    /// <summary>
    /// General interface for bills
    /// </summary>
    public class Invoice
    {
        /// <summary>
        /// Invoice number
        /// Must be consecutive for customer Invoices!
        /// </summary>
        public int InvoiceId { get; set; }

        /// <summary>
        /// Date on the Invoice
        /// </summary>
        public DateTime InvoiceDate { get; set; }

        /// <summary>
        /// The quarter of the year the invoice belongs too, from a VAT-point of view
        /// </summary>
        public int PeriodQuarter { get; set; }

        /// <summary>
        /// The year of the invoice belongs too, from a VAT-point of view
        /// </summary>
        public int PeriodYear { get; set; }

        /// <summary>
        /// Amount of the goods
        /// in Euro
        /// </summary>
        public double AmGoods { get; set; }

        /// <summary>
        /// Amount of the VAT
        /// in Euro
        /// </summary>
        public double AmVat { get; set; }

        /// <summary>
        /// The total bill amount
        /// </summary>
        public double AmTotal { get; set; }

        /// <summary>
        /// The type of Invoice
        /// Also connects to the correct VAT registration fields
        /// </summary>
        public InvoiceType Type { get; set; }

        /// <summary>
        /// Allows to split the invoice to 
        /// the purpose of the invoice (company - private)
        /// </summary>
        public Division Division { get; set; }

        /// <summary>
        /// Sets the deductibility of the invoice
        /// Is dependable on the current law
        /// </summary>
        public Deductibility Deduct { get; set; }

        /// <summary>
        /// Links the bill with a <see cref="Stakeholder"/>
        /// IE a supplier
        /// </summary>
        public int StakeholderId { get; set; }


    }
}
