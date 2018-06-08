namespace BPAccounting.Data
{
    public class Deductibility
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
        /// The percentage, in decimal notation, for how much the goods are deductible
        /// </summary>
        public decimal DedubctibilPercentage { get; set; }

        #endregion
    }
}
