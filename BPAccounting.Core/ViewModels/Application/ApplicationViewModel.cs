using BPAccounting.Data;
using System.Collections.ObjectModel;

namespace BPAccounting.Core
{
    /// <summary>
    /// The application state as a view model
    /// </summary>
    public class ApplicationViewModel : BaseViewModel
    {
        /// <summary>
        /// The current page of the application
        /// </summary>
        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Start;

        public ObservableCollection<AppLink> AppLinks { get; set; }
        /// <summary>
        /// True if the side menu should be shown
        /// </summary>
        public bool SideMenuVisible { get; set; } = false;

        public ApplicationViewModel()
        {
            AppLinks = new ObservableCollection<AppLink>()
            {
                new AppLink(ApplicationPage.Start) { Name = "Start"},
                new AppLink(ApplicationPage.ViewStakeholders){ Name = "Stakeholders"},
                new AppLink(ApplicationPage.InvoiceInput){ Name = "Input"},
                new AppLink(ApplicationPage.ViewVATDraft){ Name = "VAT Draft"},
                new AppLink(ApplicationPage.YearResult){ Name = "Year Results"}
            };
        }
    }
}
