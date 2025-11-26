namespace POS.Domain.Models
{
    public class Payment
    {
        public int PaymentID { get; set; }

        public int SaleID { get; set; }
        public SaleItem SaleItem { get; set; }

        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime Date { get; set; }
    }
}
