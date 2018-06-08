using BPAccounting.Data;
using System;
using System.Diagnostics;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace BPAccounting.Core
{
    public class CardViewModel
    {
        #region Private fields

        private CardModel _model { get; set; }
        
        #endregion

        #region Public properties

        public ImageSource CardImage { get { return new BitmapImage(new Uri(_model.ImageString)); } }

        public string Title { get { return _model.Title; } }

        public string Subtitle { get { return _model.Subtitle; } }


        #endregion

        #region public commands

        public ICommand OpenPageCommand { get; set; }
        public ICommand DeleteTileCommand { get; set; }

        #endregion

        #region Constructor

        public CardViewModel(CardModel model, ApplicationPage page)
        {
            _model = model;

            //DeleteTileCommand = new RelayCommand(() => DeleteTile());          
            OpenPageCommand = new RelayCommand(() => OpenPage(page));
        }

        #endregion

        #region public methods

        public void OpenPage(ApplicationPage page)
        {
            Debug.WriteLine("Going to page...");

            //Open the page
            IoC.Get<ApplicationViewModel>().CurrentPage = page;
        }

        public void DeleteTile()
        {
            Debug.WriteLine("Delelting this tile...");
        }
        #endregion
    }
}
