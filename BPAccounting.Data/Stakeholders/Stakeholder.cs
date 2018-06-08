using System.Collections.Generic;

namespace BPAccounting.Data
{
    /// <summary>
    /// The interface for a stakeholder
    /// A stakeholder can either be a customer or a supplier
    /// </summary>
    public class Stakeholder
    {
        /// <summary>
        /// The Id of the stakeholder
        /// </summary>
        public int StakeholderId { get; set; }

        /// <summary>
        /// True if the stakeholder is a supplier.
        /// If false, the stakeholder is a customer.
        /// </summary>
        public bool IsSupplier { get; set; }

        /// <summary>
        /// The name of the stakehodler
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The contact phone number for the stakeholder
        /// </summary>
        public string PhNr { get; set; }

        /// <summary>
        /// The VAT number of the stakeholder
        /// </summary>
        public string VatNr { get; set; }

        /// <summary>
        /// The bank account of the stakeholder
        /// </summary>
        public string BankAcc { get; set; }

        //CountryCatEnum Country { get; set; }

        /// <summary>
        /// A list of payments made to or by the stakeholder
        /// </summary>
        public List<Payment> Payments { get; set; }

        /// <summary>
        /// A list of invoices made to or by the stakeholder
        /// </summary>
        //List<Invoice> Invoiced { get; set; }
    }
}
