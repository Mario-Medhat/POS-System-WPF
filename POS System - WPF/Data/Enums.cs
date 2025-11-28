using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace POS_System___WPF.Data
{
    public static class Enums
    {
        //Payment
        public enum PaymentMethod
        {
            Cash,
            Card,
            Mixed,
        }

        //Invoice
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

        //InventoryLog
        public enum StockChangeType
        {
            SaleItem,
            Purchase,
            Manual,
        }

        //NotificationsLog
        public enum NotificationsTypes
        {
            Info,
            Warning,
            Error,

        }

        //StockMovement
        public enum MovementType
        {
            Increase,
            Decrease,
            Correction,
            Transfer,
        }
    }
}
