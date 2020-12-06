using System.ComponentModel;
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
        private BindingList<string> _cart;

        public BindingList<string> Cart
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
        private int _itemQuantity;

        public int ItemQuantity
        {
            get { return _itemQuantity; }
            set
            {
                _itemQuantity = value;
                NotifyOfPropertyChange(() => ItemQuantity);
            }
        }

        //SubTotal field
        public string SubTotal
        {
            get
            {
                return "$0.00";
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
                //Make sure item quantity is present

                return output;
            }
        }

        public void AddToCart()
        {

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

    }
}
