using System.Collections.Generic;

namespace DesignPatterns.Behavioral.VisitorPattern
{
    /// <summary>
    /// Object Structure - Collection of elements
    /// </summary>
    public class ShoppingCart
    {
        private List<IShoppingItem> _items;

        public ShoppingCart()
        {
            _items = new List<IShoppingItem>();
        }

        public void AddItem(IShoppingItem item)
        {
            _items.Add(item);
        }

        public void Accept(IShoppingVisitor visitor)
        {
            foreach (var item in _items)
            {
                item.Accept(visitor);
            }
        }
    }
}