using BPAccounting.Core;
using BPAccounting.Relational;
using Dna;
using System.Threading.Tasks;
using System.Windows;

namespace BPAccounting
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Custom startup so we load our IoC immediately before anything else
        /// </summary>
        /// <param name="e"></param>
        protected override async void OnStartup(StartupEventArgs e)
        {
            // Let the base application do what it needs
            base.OnStartup(e);

            // Setup the main application 
            await ApplicationSetupAsync();
        }

        private async Task ApplicationSetupAsync()
        {
            // Setup the Dna Framework
            new DefaultFrameworkConstruction()
                .UseServerDataStore()
                .Build();

            // Setup IoC
            IoC.Setup();

            // Ensure the client data store 
            await IoC.ClientDataStore.EnsureDataStoreAsync();

            // Create types
             // Sales invoice types
            Types.SetupSalesInvoiceTypes();

            // Purchase invoice types
            Types.SetupPurchaseInvoiceTypes();

            // Division types
            Types.SetupDivisions();

            // Deductibility types
            Types.SetupDeductibility();

            // Country types
            Types.SetupCountries();
        }
    }
}
