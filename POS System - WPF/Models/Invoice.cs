using POS_System___WPF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System___WPF.Models
{
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


    public class Invoice
    {
        public int InvoiceId { get; set; }

        public DateTime InvoiceDate { get; set; } = DateTime.Now;

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [NotMapped]
        public decimal TotalAmount => InvoiceItems?.Sum(i => i.TotalAmount) ?? 0;

        [NotMapped]
        public decimal PaidAmount => Payments?.Sum(p => p.Amount) ?? 0;

        [NotMapped]
        public decimal RemainingAmount => TotalAmount - PaidAmount;

        public List<InvoiceItem> InvoiceItems { get; set; } = new();

        public List<Payment> Payments { get; set; } = new(); // the customer can pay on multible times

        public InvoiceStatus InvoiceStatus { get; set; } = InvoiceStatus.Active;

        [NotMapped]
        public PaymentStatus PaymentStatus
        {
            get
            {
                if (TotalAmount == 0)
                    return PaymentStatus.WaitingForPayment;

                if (PaidAmount == 0)
                    return PaymentStatus.WaitingForPayment;

                if (PaidAmount < TotalAmount)
                    return PaymentStatus.HasRemaining;

                return PaymentStatus.Paid;
            }
        } // Paid, has remaining, Waiting for Payment


        // ================================
        //        DOMAIN METHODS
        // ================================

        /// <summary>
        /// Adds a new item to the Invoice (or increases quantity if already exists).
        /// </summary>
        public void AddItem(Product product, int quantity, decimal priceAtSale)
        {
            if (InvoiceStatus != InvoiceStatus.Active)
                throw new InvalidOperationException("Cannot modify items on a non-active invoice.");

            if (product == null)
                throw new ArgumentNullException(nameof(product));

            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero.");

            var existingItem = InvoiceItems.FirstOrDefault(i => i.ProductId == product.ProductId);

            if (existingItem == null)
            {
                InvoiceItems.Add(new InvoiceItem
                {
                    Product = product,
                    ProductId = product.ProductId,
                    Quantity = quantity,
                    PriceAtSaleTime = priceAtSale,
                    Invoice = this
                });
            }
            else
            {
                existingItem.Quantity += quantity;
            }
        }

        /// <summary>
        /// Register a payment for this invoice.
        /// </summary>
        public void Pay(decimal amount)
        {
            if (InvoiceStatus != InvoiceStatus.Active)
                throw new InvalidOperationException("Cannot pay a non-active invoice.");

            if (amount <= 0)
                throw new ArgumentException("Payment amount must be greater than zero.");

            Payments.Add(new Payment
            {
                Amount = amount,
                Date = DateTime.Now,
                InvoiceId = this.InvoiceId,
                Invoice = this
            });
        }

        /// <summary>
        /// Cancels the invoice.
        /// </summary>
        public void Cancel()
        {
            if (InvoiceStatus == InvoiceStatus.Cancelled)
                return;

            InvoiceStatus = InvoiceStatus.Cancelled;
            InvoiceItems.Clear();
            Payments.Clear();
        }

        /// <summary>
        /// Returns entire invoice (full return).
        /// </summary>
        public void Return()
        {
            if (InvoiceStatus != InvoiceStatus.Active)
                throw new InvalidOperationException("Only active invoices can be returned.");

            InvoiceStatus = InvoiceStatus.Returned;
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
            InvoiceStatus = InvoiceStatus.Draft;
        }
    }
}


// TODO: Inside InvoiceService, Add if (InvoiceItems.Count == 0) InvoiceStatus = InvoiceStatus.Cancelled;