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
        private ObservableCollection<OrderItem> _OrderItems;

        public ObservableCollection<OrderItem> OrderItems
        {
            get { return this._OrderItems; }
            set
            {
                if (this._OrderItems == value)
                {
                    return;
                }

                this._OrderItems = value;
                this.NotifyOfPropertyChange(() => this._OrderItems);
            }
        }
    }
}
