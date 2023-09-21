﻿using Ecommerce_BE.Data.Domains;
using Ecommerce_BE.Data.DTO.BillOfSales;
using Ecommerce_BE.Data.DTO.DetailBillOfSales;

namespace Ecommerce_BE.Services.BillOfSaleServices
{
    public interface IBillOfSaleService
    {
        public Task<List<BillOfSale>> GetAll();
        public Task<string?> Create(CreateBillOfSaleDto model,string id);
        public Task<double?> GetTotal(List<CreateDetailBillOfSaleDto> detailBillOfSale);
    }
}
