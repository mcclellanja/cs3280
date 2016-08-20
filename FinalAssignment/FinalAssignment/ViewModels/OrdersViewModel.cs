using Caliburn.Micro;
using InventoryData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using InventoryData;
using InventoryDataInteraction;

namespace FinalAssignment.ViewModels
{
    class OrdersViewModel : Screen
    {
        protected override async void OnActivate()
        {
            base.OnActivate();

            InitializeData();
        }

        /// <summary>
        /// Observable Collections for my data grids Existing Orders
        /// And Selected Orderd
        /// </summary>
        private ObservableCollection<Item> _ExistingOrders;

        public ObservableCollection<Item> dgExistingOrders
        {
            get { return this._ExistingOrders; }
            set
            {
                if(this._ExistingOrders == value)
                {
                    return;
                }

                this._ExistingOrders = value;
                this.NotifyOfPropertyChange(() => dgExistingOrders);
            }
        }
        private ObservableCollection<Order> _SelectedOrders;

        public ObservableCollection<Order> dgSelectedOrders
        {
            get { return this._SelectedOrders; }
            set
            {
                if(this._SelectedOrders == value)
                {
                    return;
                }

                this._SelectedOrders = value;
                this.NotifyOfPropertyChange(() => dgSelectedOrders);
            }
        }

        public DatabaseInteraction DataManager = new DatabaseInteraction();

        protected async void InitializeData()
        {
            var _Items = await DataManager.GetItemsAsync();
            dgExistingOrders = new ObservableCollection<Item>(_Items);
        }
    }//end of class
}//end of namespace
