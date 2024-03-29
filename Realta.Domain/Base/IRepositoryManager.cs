﻿using Realta.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realta.Domain.Base
{
    public interface IRepositoryManager
    {
        IVendorRepository VendorRepository { get; }
        IPurchaseOrderRepository PurchaseOrderRepository { get; }
        ICartRepository CartRepository { get; }
        IStockRepository StockRepository { get; }
        IStockDetailRepository StockDetailRepository { get; }
        IStockPhotoRepository StockPhotoRepository { get; }
        IVendorProductRepository VendorProductRepository { get; }

    }
}
