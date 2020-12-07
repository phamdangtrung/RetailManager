using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManagerAPI.Library.Internal.DataAccess;
using DataManagerAPI.Library.Models;

namespace DataManagerAPI.Library.DataAccess
{
    public class SaleData
    {
        public void SaveSale(SaleModel saleInfo, string userId)
        {
            // TODO: Make this SOLID/DRY/Better
            List<SaleDetailDbModel> saleDetails = new List<SaleDetailDbModel>();
            ProductData product = new ProductData();
            var taxRate = ConfigHelper.GetTaxRate();

            foreach (var item in saleInfo.SaleDetails)
            {
                var detail = new SaleDetailDbModel
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                };

                //TODO: Additional SaleDetail information
                var productInfo = product.GetProductById(detail.ProductId);

                if (productInfo == null)
                {
                    throw new Exception($"The Id of {detail.ProductId} could not be found in the database!");
                }

                detail.PurchasePrice = productInfo.RetailPrice * detail.Quantity;

                if (productInfo.IsTaxable)
                {
                    detail.Tax = ( detail.PurchasePrice * taxRate ) / 100;
                }

                saleDetails.Add(detail);
            }


            //SaleDbModel to save to database
            SaleDbModel sale = new SaleDbModel
            {
                SubTotal = saleDetails.Sum(x => x.PurchasePrice),
                Tax = saleDetails.Sum(x => x.Tax),
                CashierId = userId,
            };
            sale.Total = sale.SubTotal + sale.Tax;


            //Save Sales record
            SqlDataAcces sql = new SqlDataAcces();
            sql.SaveData("dbo.spSales_Insert", sale, "RMDatabase");


            //Get the ID from Sales table
            sale.Id = sql.LoadData<int, dynamic>("dbo.spSales_Latest", 
                new { CashierId = sale.CashierId, SaleDate = sale.SaleDate }, 
                "RMDatabase").FirstOrDefault();


            //Finish filling Sales database model for insertion
            foreach (var item in saleDetails)
            {
                item.SaleId = sale.Id;

                //Save SaleDetails records.
                //If SaveData is being called too much (eg: 1000 calls/time), you can create table parameter and pass all values in 1 table.
                sql.SaveData("dbo.spSaleDetails_Insert", item, "RMDatabase");
            }


            
            
        }

    }
}
