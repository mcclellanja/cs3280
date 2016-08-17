using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryData;

namespace FinalAssignment.ViewModels
{
    class NewOrderViewModel : Screen
    {
        protected override void OnActivate()
        {
            base.OnActivate();
            InitializeData();
        }

        private ObservableCollection<OrderItem> _OrderItems;
        private ObservableCollection<Item> _Items;
        private string _OrderNumber;
        private DateTime _PurchaseDate;
        private string _Purchaser;
        private double _OrderTotal;

        public string txt_OrderNumber
        {
            get { return this._OrderNumber; }
            set
            {
                if(this._OrderNumber == value)
                {
                    return;
                }

                this._OrderNumber = value;
                this.NotifyOfPropertyChange(() => this._OrderNumber);
            }
        }

        public DateTime txt_PurchaseDate
        {
            get { return this._PurchaseDate; }
            set
            {
                if (this._PurchaseDate == value)
                {
                    return;
                }

                this._PurchaseDate = value;
                this.NotifyOfPropertyChange(() => this._PurchaseDate);
            }
        }

        public string txt_Purchaser
        {
            get { return this._Purchaser; }
            set
            {
                if (this._Purchaser == value)
                {
                    return;
                }

                this._Purchaser = value;
                this.NotifyOfPropertyChange(() => this._Purchaser);
            }
        }

        public double txt_OrderTotal
        {
            get { return this._OrderTotal; }
            set
            {
                if (this._OrderTotal == value)
                {
                    return;
                }

                this._OrderTotal = value;
                this.NotifyOfPropertyChange(() => this._OrderTotal);
            }
        }

        public ObservableCollection<OrderItem> dg_OrderItems
        {
            get { return this._OrderItems; }
            set
            {
                if (this._OrderItems == value)
                {
                    return;
                }

                this._OrderItems = value;
                this.NotifyOfPropertyChange(() => dg_OrderItems);
            }
        }

        public ObservableCollection<Item> Items
        {
            get { return _Items; }
        }

        public IInventoryData DataManager { get; set; }


        //protected override async void OnActivate()
        //{
        //    base.OnActivate();
        //    OrderItems = await DataManager.GetOrderItemsAsync();
        //}

        protected async void InitializeData()
        {
            var Items = await DataManager.GetItemsAsync();
            Items = new ObservableCollection<Item>(_Items);
        }

        public async void SaveBackToDB()
        {
            
        }

    }
}
