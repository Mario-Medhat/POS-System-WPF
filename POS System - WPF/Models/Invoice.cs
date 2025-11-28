using POS_System___WPF.Data;
using POS_System___WPF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System___WPF.Models
{
    public abstract class Invoice
    {
        public int InvoiceId { get; private set; }
        public DateTime InvoiceDate { get; private set; } = DateTime.Now;


        [NotMapped]
        public decimal TotalAmount => InvoiceItems?.Sum(i => i.TotalAmount) ?? 0;
        [NotMapped]
        public decimal PaidAmount => Payments?.Sum(p => p.Amount) ?? 0;
        [NotMapped]
        public decimal RemainingAmount => TotalAmount - PaidAmount;

        public List<InvoiceItem> InvoiceItems { get; private set; } = new();
        public List<Payment> Payments { get; private set; } = new(); // the customer can pay on multible times

        public Enums.InvoiceStatus InvoiceStatus { get; private set; } = Enums.InvoiceStatus.Active;

        [NotMapped]
        public Enums.PaymentStatus PaymentStatus
        {
            get
            {
                if (TotalAmount == 0)
                    return Enums.PaymentStatus.WaitingForPayment;

                if (PaidAmount == 0)
                    return Enums.PaymentStatus.WaitingForPayment;

                if (PaidAmount < TotalAmount)
                    return Enums.PaymentStatus.HasRemaining;

                return Enums.PaymentStatus.Paid;
            }
        } // Paid, has remaining, Waiting for Payment

        // protected Constructor to make nobody can make a direct instance from this class
        // But we cane inherit from it
        protected Invoice() { }


        // ================================
        //        DOMAIN METHODS
        // ================================

        /// <summary>
        /// Adds a new item to the Invoice (or increases quantity if already exists).
        /// </summary>
        public void AddItem(Product product, int quantity, decimal priceAtSale)
        {
            if (InvoiceStatus != Enums.InvoiceStatus.Active)
                throw new InvalidOperationException("Cannot modify items on a non-active invoice.");

            if (product == null)
                throw new ArgumentNullException(nameof(product));

            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero.");

            var existingItem = InvoiceItems.FirstOrDefault(i => i.ProductId == product.ProductId);

            if (existingItem == null)
            {
                InvoiceItems.Add(new InvoiceItem(invoice: this, productId: product.ProductId, price: priceAtSale, quantity));
            }
            else
            {
                existingItem.Quantity += quantity;
            }
        }

        /// <summary>
        /// Register a payment for this invoice.
        /// </summary>
        public void AddPayment(decimal amount, Enums.PaymentMethod paymentMethod)
        {
            if (InvoiceStatus != Enums.InvoiceStatus.Active)
                throw new InvalidOperationException("Cannot pay a non-active invoice.");

            if (amount <= 0)
                throw new ArgumentException("Payment amount must be greater than zero.");

            Payments.Add(new Payment(invoice: this, amount: amount, paymentMethod: paymentMethod));
        }

        /// <summary>
        /// Cancels the invoice.
        /// </summary>
        public void Cancel()
        {
            if (InvoiceStatus == Enums.InvoiceStatus.Cancelled)
                return;

            InvoiceStatus = Enums.InvoiceStatus.Cancelled;
            InvoiceItems.Clear();
            Payments.Clear();
        }

        /// <summary>
        /// Returns entire invoice (full return).
        /// </summary>
        public void Return()
        {
            if (InvoiceStatus != Enums.InvoiceStatus.Active)
                throw new InvalidOperationException("Only active invoices can be returned.");

            InvoiceStatus = Enums.InvoiceStatus.Returned;
        }

        /// <summary>
        /// Removes a product entirely from the invoice.
        /// </summary>
        public void RemoveItem(int productId)
        {
            var item = InvoiceItems.FirstOrDefault(i => i.ProductId == productId);

            if (item != null)
                InvoiceItems.Remove(item);
        }

        /// <summary>
        /// Marks the invoice as draft.
        /// </summary>
        public void SetDraft()
        {
            InvoiceStatus = Enums.InvoiceStatus.Draft;
        }
    }
}


// TODO: Inside InvoiceService, Add if (InvoiceItems.Count == 0) InvoiceStatus = InvoiceStatus.Cancelled;