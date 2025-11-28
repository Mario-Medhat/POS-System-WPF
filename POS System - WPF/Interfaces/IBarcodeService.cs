using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace POS_System___WPF.Interfaces
{
    public interface IBarcodeService
    {
        BitmapImage GenerateBarcode(string data);
        byte[] GenerateBarcodeBytes(string data);
    }
}
