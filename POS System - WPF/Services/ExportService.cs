using POS_System___WPF.Interfaces;
using POS_System___WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System___WPF.Services
{
    public class ExportService : IExportService
    {
        public void ExportInvoiceToPdf(Invoice invoice, string filePath)
        {
            // TODO: Add QuestPDF logic
        }

        public void ExportProductsToExcel(IEnumerable<Product> products, string filePath)
        {
            // TODO: Add ClosedXML logic
        }
    }

}
