using ItemCRUD.Core.Entities;

namespace ItemCRUD.Core.Interfaces
{
    public interface IItemService
    {
        Models.Item CastToItemDB(ItemClient itemClient);
        ItemClient CastToItemsClient(Models.Item item);
    }
}
