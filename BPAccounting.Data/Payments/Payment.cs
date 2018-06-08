using System;

namespace BPAccounting.Data
{
    public class Payment
    {
        /// <summary>
        /// The transcript number connected with the payment
        /// </summary>
        public int TransactionId { get; set; }

        /// <summary>
        /// The date of the transcript
        /// </summary>
        public DateTime TrDate { get; set; }

        /// <summary>
        /// The invoice connected to the payment
        /// </summary>
        public int InvoiceId { get; set; }
        
        /// <summary>
        /// The total amount of the payment
        /// </summary>
        public double Amtotal { get; set; }

        /// <summary>
        /// Default constructor
        /// What if the payment doesn't equal the bill!
        /// </summary>
        public Payment(int trNr, DateTime trDate, int invoiceId)
        {
            TransactionId = trNr;
            TrDate = trDate;
            InvoiceId = invoiceId;
        }
    }
}
