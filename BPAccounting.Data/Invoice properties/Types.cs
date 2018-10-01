using BPAccounting.Data;
using System.Collections.Generic;

namespace BPAccounting.Core
{
    public class Types
    {
        /// <summary>
        /// List of all sale invoice types
        /// </summary>
        static public List<InvoiceType> SalesInvoiceTypes { get; set; }

        /// <summary>
        /// List of all purchase invoice types
        /// </summary>
        static public List<InvoiceType> PurchaseInvoiceTypes { get; set; }

        /// <summary>
        /// List of all division types
        /// </summary>
        static public List<Division> DivisionTypes { get; set; }

        /// <summary>
        /// List of all deductibility types
        /// </summary>
        static public List<Deductibility> DeductibilityTypes { get; set; }

        /// <summary>
        /// List of all country types
        /// </summary>
        static public List<CountryProperty> CountryTypes { get; set; }
        
        /// <summary>
        /// Setup for the sales invoice types
        /// </summary>
        static public void SetupSalesInvoiceTypes()
        {
            SalesInvoiceTypes = new List<InvoiceType>()
            {
                new InvoiceType() { Name = "Sales 0% VAT", ShortHand = "S0" },
                new InvoiceType() { Name = "Sales 6% VAT", ShortHand = "S6" },
                new InvoiceType() { Name = "Sales 12% VAT", ShortHand = "S12" },
                new InvoiceType() { Name = "Sales 21% VAT", ShortHand = "S21" },
                new InvoiceType() { Name = "Sales within EU", ShortHand = "SEUG" },
                new InvoiceType() { Name = "Sales outside EU", ShortHand = "SEUS" },
                new InvoiceType() { Name = "Other sales", ShortHand = "SO" },
            };
        }

        /// <summary>
        /// Setup for the purchase invoice types
        /// </summary>
        static public void SetupPurchaseInvoiceTypes()
        {
            PurchaseInvoiceTypes = new List<InvoiceType>()
            {
                new InvoiceType() { Name = "Purchase goods", ShortHand = "PG" },
                new InvoiceType() { Name = "Purchase services and other goods", ShortHand = "PS" },
                new InvoiceType() { Name = "Purchase investments", ShortHand = "PINV" },
                new InvoiceType() { Name = "Purchase goods wihtin EU", ShortHand = "PEUG" },
                new InvoiceType() { Name = "Purchase services within EU", ShortHand = "PEUS" },
                new InvoiceType() { Name = "Other purchases", ShortHand = "PO" },
            };
        }

        /// <summary>
        /// Setup for the division types
        /// </summary>
        static public void SetupDivisions()
        {
            DivisionTypes = new List<Division>()
            {
                new Division() { Name = "Full professional usage", DivisionPercentage = 1.0m },
                new Division() { Name = "Partial", DivisionPercentage = 0.5m },
            };
        }

        /// <summary>
        /// Setup for the deductibility types
        /// </summary>
        static public void SetupDeductibility()
        {
            DeductibilityTypes = new List<Deductibility>()
            {
                new Deductibility() { Name = "Fully deductible", DedubctibilPercentage = 1.0m },
                new Deductibility() { Name = "Restaurant costs", DedubctibilPercentage = 0.69m },
                new Deductibility() { Name = "Relation gifts", DedubctibilPercentage = 0.5m },
                new Deductibility() { Name = "Reception costs", DedubctibilPercentage = 0.5m },
            };
        }
        
        /// <summary>
        /// Creates all country properties
        /// </summary>
        static public void SetupCountries()
        {
            CountryTypes = new List<CountryProperty>()
            {
                new CountryProperty() { Name = "National" },
                new CountryProperty() { Name = "European" },
                new CountryProperty() { Name = "International" },
            };
        }
    }
}
