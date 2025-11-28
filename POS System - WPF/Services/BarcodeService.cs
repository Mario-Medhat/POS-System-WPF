using BarcodeLib;
using BarcodeStandard;
using POS_System___WPF.Interfaces;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace POS_System___WPF.Services
{
    public class BarcodeService : IBarcodeService
    {
        public BitmapImage GenerateBarcode(string data)
        {
            var bytes = GenerateBarcodeBytes(data);
            return BytesToBitmapImage(bytes);
        }

        public byte[] GenerateBarcodeBytes(string data)
        {
            var barcode = new Barcode();
            barcode.IncludeLabel = false;

            // Generate SKImage
            using SKImage img = barcode.Encode(
                BarcodeStandard.Type.Code128,
                data,
                SKColor.Parse("#000000"),
                SKColor.Parse("#FFFFFF"),
                300,
                100
            );

            // Convert SKImage to byte[]
            using SKData encoded = img.Encode(SKEncodedImageFormat.Png, 100);

            return encoded.ToArray();
        }

        private BitmapImage BytesToBitmapImage(byte[] bytes)
        {
            BitmapImage bmp = new BitmapImage();
            using var ms = new MemoryStream(bytes);

            bmp.BeginInit();
            bmp.StreamSource = ms;
            bmp.CacheOption = BitmapCacheOption.OnLoad;
            bmp.EndInit();
            bmp.Freeze();

            return bmp;
        }
    }


}
