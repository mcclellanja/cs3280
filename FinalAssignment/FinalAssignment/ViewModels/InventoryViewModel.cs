using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using InventoryData;
using InventoryDataInteraction;

namespace FinalAssignment.ViewModels
{
    class InventoryViewModel : Screen
    {
        protected override void OnActivate()
        {
            base.OnActivate();
            InitializeData();
        }

        private ObservableCollection<Item> _Inventory;
        public ObservableCollection<Item> dgInventory
        {
            get { return this._Inventory; }
            set
            {
                if (this._Inventory == value)
                {
                    return;
                }

                this._Inventory = value;
                this.NotifyOfPropertyChange(() => dgInventory);
            }
        }

        public DatabaseInteraction DataManager = new DatabaseInteraction();

        protected async void InitializeData()
        {
            var _Items = await DataManager.GetItemsAsync();
            dgInventory = new ObservableCollection<Item>(_Items);

        }

    }
}
