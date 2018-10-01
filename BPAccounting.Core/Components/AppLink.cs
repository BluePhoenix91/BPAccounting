using System.Diagnostics;
using System.Windows.Input;

namespace BPAccounting.Core
{
    public class AppLink
    {

        public string Name { get; set; }

        public ICommand OpenPageCommand { get; set; }

        public AppLink(ApplicationPage page)
        {
            OpenPageCommand = new RelayCommand(() => OpenPage(page));
        }

        public void OpenPage(ApplicationPage page)
        {
            Debug.WriteLine("Going to page...");

            //Open the page
            IoC.Get<ApplicationViewModel>().CurrentPage = page;
        }
    }
}
