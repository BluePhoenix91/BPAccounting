namespace BPAccounting.Core
{
    /// <summary>
    /// A page of the application
    /// </summary>
    public enum ApplicationPage
    {
        /// <summary>
        /// The initial page
        /// </summary>
        Start = 0,

        /// <summary>
        /// The stakeholder input page
        /// </summary>
        StakeholderInput = 1,

        /// <summary>
        /// Collection of stakeholders page
        /// </summary>
        ViewStakeholders = 2,

        /// <summary>
        /// VAT draft page
        /// </summary>
        ViewVATDraft = 3,

        /// <summary>
        /// A testing page
        /// </summary>
        InvoiceInput = 4,

        /// <summary>
        /// A page showing the results of the year
        /// </summary>
        YearResult = 5,
    }
}
