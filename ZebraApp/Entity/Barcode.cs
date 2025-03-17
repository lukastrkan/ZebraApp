namespace ZebraApp.Entity;

public class Barcode(string code, BarcodeType type)
{
    public string Code { get; set; } = code;
    public BarcodeType Type { get; set; } = type;
}