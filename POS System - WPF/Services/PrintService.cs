using POS_System___WPF.Interfaces;
using POS_System___WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;

namespace POS_System___WPF.Services
{
    public class PrintService : IPrintService
    {
        public void PrintInvoice(Invoice invoice)
        {
            // TODO: Real printing logic
        }

        public void PrintText(string text)
        {
            PrintDialog dialog = new PrintDialog();
            if (dialog.ShowDialog() == true)
            {
                FlowDocument doc = new FlowDocument(new Paragraph(new Run(text)));
                dialog.PrintDocument(((IDocumentPaginatorSource)doc).DocumentPaginator, "Text Print");
            }
        }
    }
}
