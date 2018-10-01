using System;
using System.Diagnostics;
using System.Globalization;
using BPAccounting.Core;

namespace BPAccounting
{    /// <summary>
     /// Converts the <see cref="ApplicationPage"/> to an actual view/page
     /// </summary>
    class ApplicationPageValueConverter : BaseValueConverter<ApplicationPageValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Find the appropriate page
            switch ((ApplicationPage)value)
            {
                case ApplicationPage.Start:
                    return new SplashPage();

                case ApplicationPage.ViewStakeholders:
                    return new ViewStakeholdersPage();

                case ApplicationPage.ViewVATDraft:
                    return new VATDraftPage();

                case ApplicationPage.InvoiceInput:
                    return new InputPage();

                case ApplicationPage.YearResult:
                    return new YearResultPage();

                default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
