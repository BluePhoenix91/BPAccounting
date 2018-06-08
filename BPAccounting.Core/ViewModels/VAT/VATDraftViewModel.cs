using BPAccounting.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Input;

namespace BPAccounting.Core
{
    public class VATDraftViewModel : BaseViewModel
    {

        #region Singleton

        public static VATDraftViewModel Instance = new VATDraftViewModel();

        #endregion

        #region Public properties

        /// <summary>
        /// The quarter of the year the invoice belongs too, from a VAT-point of view
        /// </summary>
        public int PeriodQuarter { get; set; }

        /// <summary>
        /// The year of the invoice belongs too, from a VAT-point of view
        /// </summary>
        public int PeriodYear { get; set; }

        /// <summary>
        /// VAT draft model
        /// </summary>
        public VATDraftModel VATDraftModel { get; set; }
        
        /// <summary>
        /// Binding to the caculation of the VAT Draft method, <see cref="CaculateVATDRaft"/>
        /// </summary>
        public ICommand CalculateVATDraftCommand { get; set; }

        /// <summary>
        /// List of all the invoices for this calculation
        /// </summary>
        public List<Invoice> Invoices { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default  constructor
        /// </summary>
        public VATDraftViewModel()
        {
            // Initialise
            if( VATDraftModel == null)
                VATDraftModel = new VATDraftModel();
            CalculateVATDraftCommand = new RelayCommand(() => CaculateVATDRaft());
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Calculates the VAT Draft
        /// TODO:
        /// Make this function for a specific period
        /// </summary>
        public void CaculateVATDRaft()
        {
            VATDraftModel = new VATDraftModel();
            Invoices = IoC.ClientDataStore.GetInvoices(PeriodQuarter,PeriodYear);
            VATCalc.WriteToVATModel(VATDraftModel, Invoices);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        //public void CreateAllEntries(VATRegModel model)
        //{
        //    foreach (PropertyInfo p in typeof(VATRegModel).GetProperties())
        //    {
        //        if (p.PropertyType == typeof(Double))
        //        {
        //            DescriptionAttribute descriptionAttribute = (DescriptionAttribute)p.GetCustomAttribute(typeof(DescriptionAttribute), false);
        //            string Description = descriptionAttribute.Description;

        //            double Amount = 0.0;
        //            if (p.GetValue(model) != null)
        //            {
        //                Amount = (double)p.GetValue(model);
        //            }

        //            string Name = p.Name;

        //            VATEntries.Add(new VATEntryViewModel(Description, Amount, Name));
        //        }
        //    }
        //}

        #endregion

        #region Lists

        [Description("Kwartaal")]
        public int VATQ => VATDraftModel.VATQ;

        [Description("Jaar")]
        public int VATYr => VATDraftModel.VATYr;

        [Description("Speciale regeling")]
        public List<double> R0 => VATDraftModel.R0;

        [Description("VK 6 %")]
        public List<double> R1 => VATDraftModel.R1;

        [Description("VK 12 %")]
        public List<double> R2 => VATDraftModel.R2;

        [Description("VK 21 %")]
        public List<double> R3 => VATDraftModel.R3;

        [Description("EU diensten")]
        public List<double> R44 => VATDraftModel.R44;

        [Description("Medecontractant")]
        public List<double> R45 => VATDraftModel.R45;

        [Description("EU leveringen")]
        public List<double> R46 => VATDraftModel.R46;

        [Description("Uitvoer")]
        public List<double> R47 => VATDraftModel.R47;

        [Description("Correctie 44/46")]
        public List<double> R48 => VATDraftModel.R48;

        [Description("Correcties rest")]
        public List<double> R49 => VATDraftModel.R49;

        [Description("AK handelsgoederen")]
        public List<double> R81 => VATDraftModel.R81;

        [Description("AK diensten")]
        public List<double> R82 => VATDraftModel.R82;

        [Description("AK investeringen")]
        public List<double> R83 => VATDraftModel.R83;

        [Description("Correcties 86/88")]
        public List<double> R84 => VATDraftModel.R84;

        [Description("Correcties rest")]
        public List<double> R85 => VATDraftModel.R85;

        [Description("EU leveringen")]
        public List<double> R86 => VATDraftModel.R86;

        [Description("Uitvoer")]
        public List<double> R87 => VATDraftModel.R87;

        [Description("EU diensten")]
        public List<double> R88 => VATDraftModel.R88;

        [Description("BTW 1/2/3")]
        public List<double> R54 => VATDraftModel.R54;

        [Description("BTW 86/88")]
        public List<double> R55 => VATDraftModel.R55;

        [Description("BTW 87")]
        public List<double> R56 => VATDraftModel.R56;

        [Description("BTW invoer VVH")]
        public List<double> R57 => VATDraftModel.R57;

        [Description("BTW regularisaties voor staat")]
        public List<double> R61 => VATDraftModel.R61;

        [Description("BTW CN's")]
        public List<double> R63 => VATDraftModel.R63;

        [Description("Ongebruikt")]
        public List<double> R65 => VATDraftModel.R65;

        [Description("Totaal verschuldigd")]
        public List<double> RXX => VATDraftModel.RXX;

        [Description("Aftrekbare BTW")]
        public List<double> R59 => VATDraftModel.R59;

        [Description("BTW regularisaties voor ond")]
        public List<double> R62 => VATDraftModel.R62;

        [Description("BTW CN's")]
        public List<double> R64 => VATDraftModel.R64;

        [Description("Ongebruikt")]
        public List<double> R66 => VATDraftModel.R66;

        [Description("Totaal aftrekbaar")]
        public List<double> RYY => VATDraftModel.RYY;

        [Description("XX - YY")]
        public List<double> R71 => VATDraftModel.R71;

        [Description("YY - XX")]
        public List<double> R72 => VATDraftModel.R72;

        [Description("BTW december")]
        public List<double> R91 => VATDraftModel.R91;

        #endregion
    }
}
