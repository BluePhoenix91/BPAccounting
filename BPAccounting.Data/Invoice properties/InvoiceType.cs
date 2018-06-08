namespace BPAccounting.Data
{
    public class InvoiceType
    {
        #region Public properties

        /// <summary>
        /// The id for the invoice type
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the invoice type
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A shorthand name to easily use in programming
        /// </summary>
        public string ShortHand { get; set; }
                
        #endregion

    }
}
