using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopManagementSystem.Gateway;
using ShopManagementSystem.Models;
using ShopManagementSystem.Models.ViewModels;

namespace ShopManagementSystem.Manager
{
    public class ItemManager
    {
        private ItemGateway itemGateway;

        public ItemManager()
        {
            itemGateway = new ItemGateway();
        }

        public int AddItem(Item item)
        {
            if (itemGateway.IsItemExists(item))
            {
                return 2;
            }
            else
            {
                item.SerialNo = GenerateSerialNo();
                item.Quantity = 0;
                int rowsAffected = itemGateway.AddItem(item);

                if (rowsAffected > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        public List<ItemViewModel> GetAllItems()
        {
            return itemGateway.GetAllItems();
        }

        public string GenerateSerialNo()
        {
            string prevSerial = itemGateway.GetLastSerialNo();

            int no = Convert.ToInt32(prevSerial.Substring(4, 4));
            int serialPost = no + 1;

            string genSerial = "ITM-" + serialPost.ToString();

            return genSerial;
        }

        public List<Item> GetItemsByCompanyId(int id)
        {
            return itemGateway.GetItemByCompanyId(id);
        }

        public Item GetItemInfoById(int id)
        {
            return itemGateway.GetItemInfoByItemId(id);
        }

        public decimal GetItemSellPriceByItemId(int itemId)
        {
            return itemGateway.GetItemSellPriceByItemId(itemId);
        }

        public List<ItemViewModel> GetItemByCompanyAndCategory(int companyId, int categoryId)
        {
            return itemGateway.GetItemByCompanyAndCategory(companyId, categoryId);
        }

        public List<ItemViewModel> GetItemByCompany(int companyId)
        {
            return itemGateway.GetItemByCompany(companyId);
        }

        public List<ItemViewModel> GetItemByCategory(int categoryId)
        {
            return itemGateway.GetItemByCategory(categoryId);
        }

    }
}