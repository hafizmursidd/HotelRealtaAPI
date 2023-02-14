﻿using Realta.Domain.Base;
using Realta.Domain.Repositories;
using Realta.Persistence.Repositories;
using Realta.Persistence.RepositoryContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realta.Persistence.Base
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly AdoDbContext _adoContext;
        private IVendorRepository _vendorRepository;
        private IPurchaseOrderHeaderRepository _purchaseOrderHeaderRepository;
        private IPurchaseOrderDetailRepository _purchaseOrderDetailRepository;

        public RepositoryManager(AdoDbContext adoContext)
        {
            _adoContext = adoContext;
        }

        public IVendorRepository VendorRepository 
        { 
            get 
            { 
                if (_vendorRepository == null)
                {
                    _vendorRepository = new VendorRepository(_adoContext);
                }
                return _vendorRepository;
            } 
        }

        public IPurchaseOrderHeaderRepository PurchaseOrderHeaderRepository 
        {
            get
            {
                if (_purchaseOrderHeaderRepository == null)
                {
                    _purchaseOrderHeaderRepository = new PurchaseOrderHeaderRepository(_adoContext);
                }
                return _purchaseOrderHeaderRepository;
            }
        }
        public IPurchaseOrderDetailRepository PurchaseOrderDetailRepository
        {
            get
            {
                if (_purchaseOrderDetailRepository == null)
                {
                    _purchaseOrderDetailRepository = new PurchaseOrderDetailRepository(_adoContext);
                }
                return _purchaseOrderDetailRepository;
            }
        }
    }
}
