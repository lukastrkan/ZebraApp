using ZebraApp.Entity;

namespace ZebraApp.Services;

public class BarcodeScannerUtil
{
    public Barcode? ProcessBarcode(string barcode)
    {
        if (barcode.Length > 0)
        {
            if (barcode.Contains("web+spoolman:s-"))
            {
                return new Barcode(barcode.Replace("web+spoolman:s-", ""), BarcodeType.FILAMENT);
            }

            if (barcode.Contains("web+spoolman:l-"))
            {
                return new Barcode(barcode.Replace("web+spoolman:l-", ""), BarcodeType.LOCATION);
            }
        }

        return null;
    }
    
    
}