using BPAccounting.Core;
using System.Windows.Controls;

namespace BPAccounting
{
    /// <summary>
    /// Base properties for each page
    /// </summary>
    public class BasePage : Page
    {

    }

    public class BasePage<VM> : BasePage
        where VM : BaseViewModel, new()
    {
        #region Private members

        /// <summary>
        /// The View Model associated with this page
        /// </summary>
        private VM mViewModel;

        #endregion

        #region Public properties

        public VM ViewModel
        {
            get
            {
                return mViewModel;
            }
            set
            {
                DataContext = mViewModel;
            }
        }

        #endregion

        #region Constructor

        public BasePage() : base()
        {
            ViewModel = new VM();
        }

        #endregion

    }
}

