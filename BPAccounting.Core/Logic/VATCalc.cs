using BPAccounting.Data;
using System.Collections.Generic;

namespace BPAccounting.Core
{
    public static class VATCalc
    {
        #region Public methods

        public static void WriteToVATModel(VATDraftModel model, List<Invoice> Invoices)
        {
            foreach (Invoice invoice in Invoices)
            {
                if (invoice.Type.ShortHand.Equals("S0"))
                {
                    model.R0.Add(invoice.AmGoods);
                    model.R54.Add(invoice.AmVat);
                }

                if (invoice.Type.ShortHand.Equals("S6"))
                {
                    model.R1.Add(invoice.AmGoods);
                    model.R54.Add(invoice.AmVat);
                }

                if (invoice.Type.ShortHand.Equals("S12"))
                {
                    model.R2.Add(invoice.AmGoods);
                    model.R54.Add(invoice.AmVat);
                }

                if (invoice.Type.ShortHand.Equals("S21"))
                {
                    model.R3.Add(invoice.AmGoods);
                    model.R54.Add(invoice.AmVat);
                }

                if (invoice.Type.ShortHand.Equals("SEUG"))
                {
                    model.R46.Add(invoice.AmGoods);
                }

                if (invoice.Type.ShortHand.Equals("SEUS"))
                {
                    model.R44.Add(invoice.AmGoods);
                }

                if (invoice.Type.ShortHand.Equals("PG"))
                {
                    model.R81.Add(invoice.AmGoods);
                    model.R59.Add(invoice.AmVat);
                }

                if (invoice.Type.ShortHand.Equals("PS"))
                {
                    model.R82.Add(invoice.AmGoods);
                    model.R59.Add(invoice.AmVat);
                }

                if (invoice.Type.ShortHand.Equals("PINV"))
                {
                    model.R83.Add(invoice.AmGoods);
                    model.R59.Add(invoice.AmVat);
                }

                if (invoice.Type.ShortHand.Equals("PEUG"))
                {
                    model.R81.Add(invoice.AmGoods);
                    model.R86.Add(invoice.AmGoods);
                    model.R59.Add(invoice.AmGoods * 0.21);
                    model.R55.Add(invoice.AmGoods * 0.21);
                }

                if (invoice.Type.ShortHand.Equals("PEUS"))
                {
                    model.R82.Add(invoice.AmGoods);
                    model.R88.Add(invoice.AmGoods);
                    model.R59.Add(invoice.AmGoods * 0.21);
                    model.R55.Add(invoice.AmGoods * 0.21);
                }

                if (invoice.Type.ShortHand.Equals("PO"))
                {
                    model.R87.Add(invoice.AmGoods);
                    model.R59.Add(invoice.AmVat);
                    model.R56.Add(invoice.AmVat);
                }
            }            
        }
        #endregion
    }
}
