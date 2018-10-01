namespace BPAccounting.Data
{
    public class Division
    {
        #region Public properties

        /// <summary>
        /// The id for the division type
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the division type
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The percentage, in decimal notation, for how much the goods are used for profesional uses
        /// </summary>
        public decimal DivisionPercentage { get; set; }

        #endregion
    }
}
