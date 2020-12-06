using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Caliburn.Micro;
using RMDesktopUI.Library.Api;
using RMDesktopUI.Library.Models;

namespace RMDesktopUI.ViewModels
{
    public class SalesViewModel : Screen
    {
        private IProductEndpoint _productEndpoint;
        public SalesViewModel(IProductEndpoint productEndpoint)
        {
            _productEndpoint = productEndpoint;
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadProducts();
        }

        private async Task LoadProducts()
        {
            var productList = await _productEndpoint.GetAll();
            Products = new BindingList<ProductModel>(productList);
        }

        #region Lists
        //List products
        private BindingList<ProductModel> _products;

        public BindingList<ProductModel> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                NotifyOfPropertyChange(() => Products);
            }
        }


        //List cart
        private BindingList<CartItemModel> _cart = new BindingList<CartItemModel>();

        public BindingList<CartItemModel> Cart
        {
            get { return _cart; }
            set
            {
                _cart = value;
                NotifyOfPropertyChange(() => Cart);
            }
        }
        #endregion


        #region Textboxes and string fields
        //Item quantity text box
        private int _itemQuantity = 1;

        public int ItemQuantity
        {
            get { return _itemQuantity; }
            set
            {
                _itemQuantity = value;
                NotifyOfPropertyChange(() => ItemQuantity);
                NotifyOfPropertyChange(() => CanAddToCart);
            }
        }

        //SubTotal field
        public string SubTotal
        {
            get
            {
                decimal subTotal = 0;

                foreach (var item in Cart)
                {
                    subTotal += (item.Product.RetailPrice * item.QuantityInCart);
                }
                return subTotal.ToString(format: "C");
            }
        }


        //SubTotal field
        public string Tax
        {
            get
            {
                return "$0.00";
            }
        }


        //SubTotal field
        public string Total
        {
            get
            {
                return "$0.00";
            }
        }
        #endregion


        #region Buttons
        //Button Add to cart
        public bool CanAddToCart
        {
            get
            {
                bool output = false;
                //Make sure a product is selected
                //Make sure item quantity is present and QuantityInStock is greater than ItemQuantity
                if (ItemQuantity > 0 && SelectedProduct?.QuantityInStock >= ItemQuantity)
                {
                    output = true;
                }
                return output;
            }
        }

        public void AddToCart()
        {
            CartItemModel existingItems = Cart.FirstOrDefault(x => x.Product == SelectedProduct);

            //If there's an existing item in the cart, add to the quantity
            if (existingItems != null)
            {
                existingItems.QuantityInCart += ItemQuantity;
                ////Cheaty hack to refresh the Cart
                //Cart.Remove(existingItems);
                //Cart.Add(existingItems);
            }
            //If there's not an existing item, add new item into cart
            else
            {
                CartItemModel item = new CartItemModel
                {
                    Product = SelectedProduct,
                    QuantityInCart = ItemQuantity
                };
                Cart.Add(item);
            }

            SelectedProduct.QuantityInStock -= ItemQuantity;
            ItemQuantity = 1;

            NotifyOfPropertyChange(() => SubTotal);
            Cart.ResetBindings();
        }


        //Button Remove from cart
        public bool CanRemoveFromCart
        {
            get
            {
                bool output = false;
                //Make sure something is in cart

                return output;
            }
        }

        public void RemoveFromCart()
        {
            NotifyOfPropertyChange(() => SubTotal);
        }


        //Button Remove from cart
        public bool CanCheckOut
        {
            get
            {
                bool output = false;
                //Make sure a product is selected

                return output;
            }
        }

        public void CheckOut()
        {

        }
        #endregion


        #region Models

        private ProductModel _selectedProduct;

        public ProductModel SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
                NotifyOfPropertyChange(() => SelectedProduct);
                NotifyOfPropertyChange(() => CanAddToCart);
            }
        }

        #endregion
    }
}
