using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace RMDesktopUI.ViewModels
{
    public class SalesViewModel : Screen
    {
    #region List
    /***********
     * Lists *
     ***********/

        //List products
        private BindingList<string> _products;

        public BindingList<string> Products
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
        /*******************************
         * Textboxes and string fields *
         *******************************/

        //Item quantity text box
        private string _itemQuantity;

        public string ItemQuantity
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
        /***********
         * Buttons *
         ***********/

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
    }
    #endregion
}
