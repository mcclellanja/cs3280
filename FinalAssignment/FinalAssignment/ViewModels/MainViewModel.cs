using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAssignment.ViewModels
{
    public class MainViewModel : Conductor<IScreen>.Collection.OneActive
    {
        public MainViewModel()
        {
            this.DisplayName = "Inventory Application";
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            NewOrder();
        }

        public void Orders()
        {
            var ordersVM = IoC.Get<OrdersViewModel>();
            ActivateItem(ordersVM);
        }

        public void Inventory()
        {
            var inventoryVM = IoC.Get<InventoryViewModel>();
            ActivateItem(inventoryVM);
        }

        public void NewOrder()
        {
            var newOrderVM = IoC.Get<NewOrderViewModel>();
            ActivateItem(newOrderVM);
        }
    }
}
