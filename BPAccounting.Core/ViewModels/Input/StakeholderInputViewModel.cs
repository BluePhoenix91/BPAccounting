using BPAccounting.Data;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BPAccounting.Core
{
    public class StakeholderInputViewModel : BaseViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static StakeholderInputViewModel Instance => new StakeholderInputViewModel();

        #endregion

        #region public properties

        /// <summary>
        /// List with country categories
        /// </summary>
        public ObservableCollection<CountryProperty> Countries { get; set; } = new ObservableCollection<CountryProperty>(Types.CountryTypes);

        public string Name { get; set; }
        
        /// <summary>
        /// True if the stakeholder is a supplier.
        /// If false, the stakeholder is a customer.
        /// </summary>
        public bool IsSupplier { get; set; }
        
        /// <summary>
        /// The contact phone number for the stakeholder
        /// </summary>
        public string PhNr { get; set; }

        /// <summary>
        /// The VAT number of the stakeholder
        /// </summary>
        public string VatNr { get; set; }

        /// <summary>
        /// The bank account of the stakeholder
        /// </summary>
        public string BankAcc { get; set; }

        /// <summary>
        /// The location where the stakeholder is at
        /// </summary>
        public CountryProperty CountrySelected { get; set; }

        #endregion

        #region Public commands

        /// <summary>
        /// Write to database
        /// </summary>
        public ICommand CreateStakeholderCommand { get; set; }

        /// <summary>
        /// Reset form
        /// </summary>
        public ICommand ResetCommand { get; set; }

        /// <summary>
        /// Get stakeholders
        /// </summary>
        public ICommand ViewStakeholdersCommand { get; set; }

        /// <summary>
        /// Get stakeholders
        /// </summary>
        public ICommand ViewVATDraftCommand { get; set; }

        /// <summary>
        /// View invoice input page
        /// </summary>
        public ICommand ViewInvoiceInputCommand { get; set; }

        #endregion

        #region Constructor

        public StakeholderInputViewModel()
        {
            CreateStakeholderCommand = new RelayParameterizedCommand(async (isSupplierBool) => await CreateStakeholderAsync(isSupplierBool));
            ResetCommand = new RelayCommand(() => ResetForm());
            ViewStakeholdersCommand = new RelayCommand(async () => await ViewStakeholders());
            ViewVATDraftCommand = new RelayCommand(async () => await ViewVATDraft());
            ViewInvoiceInputCommand = new RelayCommand(async () => await ViewInvoiceInput());
        }

        #endregion

        /// <summary>
        /// Resets the input form
        /// </summary>
        private void ResetForm()
        {
            Name = "";
            IsSupplier = false;
            PhNr = "";
            VatNr = "";
            BankAcc = "";
        }

        /// <summary>
        /// Sends confirmation for creating a stakeholder
        /// </summary>
        /// <param name="Supplier">Boolean indicatin whether or not this stakeholder is as supplier</param>
        /// <returns></returns>
        private async Task CreateStakeholderAsync(object isSupplierBool)
        {
            //await IoC.UI.ShowMessage(new MessageBoxDialogViewModel
            //{
            //    Title = "Bevestig aanmaking",
            //    Message = $"Aanmaak van: \t {CustSuppSelected} \nNaam: \t\t {Name} \nBTW-nummer: \t {VATNr} \nGelegeven te: \t {LocationSelected}",
            //    OkText = "OK"

            //});

            // Convert the object to a bool
            var isSupplier = isSupplierBool.Equals("False")? false : true;

            // Create the stakeholder
            var newStakeholder = new Stakeholder
            {
                Name = Name,
                IsSupplier = isSupplier,
                PhNr = PhNr,
                VatNr = VatNr,
                BankAcc = BankAcc,
            };
            
            // Save the stakeholder to the database
            await IoC.ClientDataStore.SaveStakeholder(newStakeholder);
            // Reset the form, readying it for a new stakeholder input
            ResetForm();
        }

        private async Task ViewStakeholders()
        {
            IoC.Get<ApplicationViewModel>().CurrentPage = ApplicationPage.ViewStakeholders;

            await Task.Delay(5);
        }

        private async Task ViewVATDraft()
        {
            IoC.Get<ApplicationViewModel>().CurrentPage = ApplicationPage.ViewVATDraft;

            await Task.Delay(5);
        }

        private async Task ViewInvoiceInput()
        {
            IoC.Get<ApplicationViewModel>().CurrentPage = ApplicationPage.InvoiceInput;

            await Task.Delay(5);
        }
    }
}
