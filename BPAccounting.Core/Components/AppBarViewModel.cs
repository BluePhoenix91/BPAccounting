namespace BPAccounting.Core
{
    public class AppBarViewModel : BaseViewModel
    {
        #region Singleton

        public static AppBarViewModel Instance = new AppBarViewModel();

        #endregion

        #region Public properties

        public string PageTitle { get; set; } = "Welcome to BPAccounting";

        public bool Visible { get; set; } = true;

        #endregion

    }
}
