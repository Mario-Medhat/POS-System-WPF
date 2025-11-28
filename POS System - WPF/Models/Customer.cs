using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System___WPF.Models
{
    public class Customer
    {
        public int CustomerID { get; private set; }
        public string Name { get; private set; }
        public string? Phone { get; private set; }
        public string? Email { get; private set; }

        public List<Invoice> Invoices { get; private set; } = new();


        private Customer() { }

        public Customer(string name, string? phone = null, string? email = null)
        {
            SetName(name);
            Phone = phone;
            Email = email;
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Customer name cannot be empty");

            Name = name;
        }
    }
}
