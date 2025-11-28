using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System___WPF.Data
{
    public static class Enums
    {
        public enum PaymentMethod
        {
            Cash,
            Card,
            Mixed,
        }

        public enum PaymentStatus
        {
            WaitingForPayment,
            HasRemaining,
            Paid,
        }
        public enum InvoiceStatus
        {
            Active,
            Cancelled,
            Returned,
            Draft,
        }

        public enum StockChangeType
        {
            SaleItem,
            Purchase,
            Manual,
        }
    }
}
