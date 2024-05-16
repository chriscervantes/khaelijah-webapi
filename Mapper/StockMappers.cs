using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.Stock;
using api.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace api.Mapper
{
    public static class StockMappers
    {
        public static StockDto ToStockDto(this Stock stockModel)
        {
            return new StockDto
            {
                Id = stockModel.Id,
                Symbol = stockModel.Symbol,
                CompanyName = stockModel.CompanyName,
                Purchase = stockModel.Purchase,
                Industry = stockModel.Industry,
                MarketCap = stockModel.MarketCap
            };
        }
    }
}