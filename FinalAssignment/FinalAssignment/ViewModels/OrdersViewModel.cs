using Caliburn.Micro;
using InventoryData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAssignment.ViewModels
{
    class OrdersViewModel : Screen
    {

        /// <summary>
        /// The IInventoryData interface for dependency injection
        /// </summary>
        public IInventoryData DataManager { get; set; }


    }//end of class
}//end of namespace
