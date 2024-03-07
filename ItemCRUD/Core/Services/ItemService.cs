using ItemCRUD.Core.Entities;
using ItemCRUD.Core.Interfaces;

namespace ItemCRUD.Core.Services
{
    public class ItemService
    {
        public Models.Item CastToItemDB(ItemClient itemClient)
        {
            if (itemClient == null) return null;
           
            return new Models.Item
            {
                Id = itemClient.Id,
                Code = itemClient.Code,
                Type = itemClient.Type,
                DisplayName = itemClient.DisplayName,
                Department = itemClient.Department,
                HSN = itemClient.HSN,
                BuyingUnit = itemClient.BuyingUnit,
                BuyingUnitPrice = itemClient.SellingUnitPrice,
                SellingUnit = itemClient.SellingUnit,
                SellingUnitPrice = itemClient.SellingUnitPrice,
                Tax = new Models.Tax
                {
                    CGST = itemClient.CGST,
                    SGST = itemClient.SGST,
                    IGST = itemClient.IGST,
                }

            };
        }

        public ItemClient CastToItemsClient(Models.Item item)
        {
            if (item == null) return null;
            var itemCl = new ItemClient { 
                Id = item.Id,
                Code = item.Code,
                Type = item.Type,
                DisplayName = item.DisplayName,
                Department = item.Department,
                HSN = item.HSN,
                BuyingUnit = item.BuyingUnit,
                BuyingUnitPrice = item.SellingUnitPrice,
                SellingUnit = item.SellingUnit,
                SellingUnitPrice = item.SellingUnitPrice,
                CGST = item?.Tax?.CGST,
                SGST = item?.Tax?.SGST,
                IGST = item?.Tax?.IGST

            };
            return itemCl;
        }
    }
}
