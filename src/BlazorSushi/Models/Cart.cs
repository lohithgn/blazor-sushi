using System;
using System.Collections.Generic;
using System.Linq;

namespace BlazorSushi.Models
{
    public class Cart
    {
        private readonly List<CartItem> contents = new List<CartItem>();
        public IReadOnlyList<CartItem> Contents => contents;

        public bool Cleared { get; private set; }

        public int Count { get { return contents.Count; }  }

        public double Total
        {
            get
            {
                return  contents.Sum(cartItem => cartItem.Product.Price * cartItem.Quantity);
            }
        }
        public event Action OnChange;

        public void Add(Product product)
        {
            Cleared = false;
            if(contents.Any(item => item.Product.Id == product.Id))
            {
                var cartItem = contents.Single(item => item.Product.Id == product.Id);
                ++cartItem.Quantity;
            }
            else
            {
                contents.Add(new CartItem { Product = product, Quantity = 1 });
            }
            NotifyChange();
        }

        public void Remove(CartItem cartItem)
        {
            contents.Remove(cartItem);
            NotifyChange();
        }

        public void Empty()
        {
            contents.Clear();
            NotifyChange();
        }

        public void Clear()
        {
            contents.Clear();
            Cleared = true;
            NotifyChange();
        }

        private void NotifyChange() => OnChange?.Invoke();
    }
}
