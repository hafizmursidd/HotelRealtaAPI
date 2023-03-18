using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realta.Contract.Models
{
    public class VendorHeaderDto
    {
        public int VendorEntityId { get; set; }
        public string VendorName { get; set; }
        public int StockId{ get; set; }
        public string StockName { get; set; }
    }
}
