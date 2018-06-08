using BPAccounting.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace BPAccounting.Core
{
    public class VATViewModel : BaseViewModel
    {
        #region Private properties

        private VATRegModel _model;
        private VATDraftModel _draftModel;

        #endregion

        #region Public properties

        /// <summary>
        /// Collection based on the model
        /// </summary>
        public List<VATEntryViewModel> VATEntries { get; set; }

        /// <summary>
        /// Collection of VAT registration items regarding the purchases
        /// </summary>
        public List<VATEntryViewModel> VATPurchases { get; set; }

        /// <summary>
        /// Collection of VAT registration items regarding the sales
        /// </summary>
        public List<VATEntryViewModel> VATSales { get; set; }

        /// <summary>
        /// Collection of VAT registration items regarding the VAT itself
        /// </summary>
        public List<VATEntryViewModel> VATVat { get; set; }

        /// <summary>
        /// Collection of VAT registration items regarding the end balance
        /// </summary>
        public List<VATEntryViewModel> VATBalance { get; set; }

        /// <summary>
        /// The VAT registration model
        /// </summary>
        public VATRegModel Model => _model;

        /// <summary>
        /// The VAT draft model
        /// </summary>
        public VATDraftModel DraftModel => _draftModel;

        /// <summary>
        /// VAT Q input
        /// </summary>
        public int VATQInput { get; set; }

        /// <summary>
        /// VAT year input
        /// </summary>
        public int VATYInput { get; set; }


        #endregion

        #region Public commands


        #endregion

        #region Constructor

        public VATViewModel()
        {
            //VATEntries = new List<VATEntryViewModel>();
            //VATPurchases = new List<VATEntryViewModel>();
            //VATSales = new List<VATEntryViewModel>();
            //VATVat = new List<VATEntryViewModel>();
            //VATBalance = new List<VATEntryViewModel>();
            //_model = IoC.VRM;
            //_draftModel = IoC.VDM;
            //ListSums(Model, DraftModel);
            //CreateEntries(Model);
            //CreateSeperateCollections("Speciale regeling", "Correcties rest", VATSales);
            //CreateSeperateCollections("AK handelsgoederen", "AK EU diensten", VATPurchases);
            //CreateSeperateCollections("BTW 1/2/3", "Totaal aftrekbaar", VATVat);
            //CreateSeperateCollections("XX - YY", "BTW december", VATBalance);

        }

        #endregion

        #region Public methods

        public void CreateEntries(VATRegModel model)
        {
            foreach (PropertyInfo p in typeof(VATRegModel).GetProperties())
            {
                if (p.PropertyType == typeof(Double))
                {
                    DescriptionAttribute descriptionAttribute = (DescriptionAttribute)p.GetCustomAttribute(typeof(DescriptionAttribute), false);
                    string Description = descriptionAttribute.Description;

                    double Amount = 0.0;
                    if (p.GetValue(model) != null)
                    {
                        Amount = (double)p.GetValue(model);
                    }

                    string Name = p.Name;

                    VATEntries.Add(new VATEntryViewModel(Description, Amount, Name));
                }
            }
        }

        public void CreateSeperateCollections(string beginDescription, string endDescription, List<VATEntryViewModel> collection)
        {
            int beginIndex = VATEntries.FindIndex(r => r.Description == beginDescription);
            int endIndex = VATEntries.FindIndex(r => r.Description == endDescription);

            for (int i = beginIndex; i <= endIndex; i++)
            {
                collection.Add(VATEntries[i]);
            }
        }

        public void ListSums(VATRegModel model, VATDraftModel draftModel)
        {
            PropertyInfo[] propertyInfos = null;
            propertyInfos = draftModel.GetType().GetProperties();

            foreach (var item in propertyInfos)
            {
                var prop = item.GetValue(draftModel);

                if (item.Name.Substring(0, 1).Equals("R"))
                {
                    if (prop is IEnumerable)
                    {
                        double i = 0;
                        foreach (var listitem in prop as IEnumerable)
                        {
                            double k = (double)listitem;
                            i = i + k;
                        }
                        foreach (PropertyInfo p in typeof(VATRegModel).GetProperties())
                        {
                            if (item.Name.Length == 2 && p.Name.Length == 2)
                                if (p.Name.Substring(0, 2).Equals(item.Name.Substring(0, 2)))
                                    p.SetValue(model, i);
                            if (item.Name.Length == 3 && p.Name.Length == 3)
                                if (p.Name.Substring(0, 3).Equals(item.Name.Substring(0, 3)))
                                    p.SetValue(model, i);
                        }
                    }
                }
            }
        }

        #endregion
    }
}
