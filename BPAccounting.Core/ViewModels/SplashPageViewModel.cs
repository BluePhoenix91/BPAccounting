using BPAccounting.Data;
using System.Collections.ObjectModel;

namespace BPAccounting.Core
{
    public class SplashPageViewModel : BaseViewModel
    {
        #region Singleton

        public static SplashPageViewModel Instance = new SplashPageViewModel();

        #endregion

        #region Public properties

        public ObservableCollection<CardViewModel> Cards { get; set; } = new ObservableCollection<CardViewModel>();

        #endregion

        #region Constructor

        public SplashPageViewModel()
        {
            var card = new CardModel()
            {
                Title = "Stakeholders",
                ImageString = "pack://application:,,,/BPAccounting;component/Images/stakeholders.png",
            };
            var cardviewmodel = new CardViewModel(card, ApplicationPage.ViewStakeholders);
            Cards.Add(cardviewmodel);

            var inputCardModel = new CardModel()
            {
                Title = "Input",
                ImageString = "pack://application:,,,/BPAccounting;component/Images/stakeholders.png",
            };
            var inputCardViewModel = new CardViewModel(inputCardModel, ApplicationPage.InvoiceInput);
            Cards.Add(inputCardViewModel);

            var vatDarftCardModel = new CardModel()
            {
                Title = "Vat draft",
                ImageString = "pack://application:,,,/BPAccounting;component/Images/stakeholders.png",
            };
            var vatDraftCardViewModel = new CardViewModel(vatDarftCardModel, ApplicationPage.ViewVATDraft);
            Cards.Add(vatDraftCardViewModel);
        }

        #endregion
    }
}
