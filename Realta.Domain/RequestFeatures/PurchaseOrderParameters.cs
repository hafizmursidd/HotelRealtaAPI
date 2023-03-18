using System.Security.Cryptography.X509Certificates;

namespace Realta.Domain.RequestFeatures
{
    public class PurchaseOrderParameters : RequestParameters
    {
        public string? Keyword { get; set; } = string.Empty;
        public string? Status { get; set; } = string.Empty;
        public string OrderBy { get; set; } = "PoheNumber";
    }
    
    public class PurchaseOrderDetailParameters : RequestParameters
    {
        public string? Keyword { get; set; }
        public string OrderBy { get; set; } = "StockName";
    }
}
