namespace BPAccounting.Core
{
    public class VATEntryViewModel : BaseViewModel
    {
        #region Public properties

        public string Description { get; set; }
        public double Amount { get; set; }

        public string RosterNumber { get; set; }

        #endregion

        #region Constructor

        public VATEntryViewModel(string description, double amount, string rosterNumber)
        {
            Description = description;
            Amount = amount;
            RosterNumber = rosterNumber;
        }

        #endregion
    }
}
