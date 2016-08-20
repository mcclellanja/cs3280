﻿using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryData;
using InventoryDataInteraction;

namespace FinalAssignment.ViewModels
{
    class NewOrderViewModel : Screen
    {
        protected override void OnActivate()
        {
            base.OnActivate();
            InitializeData();
        }

        private BindableCollection<OrderItem> _OrderItems;
        private BindableCollection<Item> _Items;
        private int _OrderNumber;
        private DateTime _PurchaseDate;
        private BindableCollection<User> _Purchaser;
        private decimal _OrderTotal;

        public int txt_OrderNumber
        {
            get { return this._OrderNumber; }
            set
            {
                if(this._OrderNumber == value)
                {
                    return;
                }

                this._OrderNumber = value;
                this.NotifyOfPropertyChange(() => txt_OrderNumber);
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
                this.NotifyOfPropertyChange(() => txt_PurchaseDate);
            }
        }

        public BindableCollection<User> txt_Purchaser
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

        public decimal txt_OrderTotal
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

        public BindableCollection<OrderItem> dg_OrderItems
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

        public BindableCollection<Item> Items
        {
            get { return _Items; }
            set
            {
                if (this._Items == value)
                {
                    return;
                }

                this._Items = value;
                this.NotifyOfPropertyChange(() => Items);
            }
        }

        public DatabaseInteraction DataManager = new DatabaseInteraction();


        //protected override async void OnActivate()
        //{
        //    base.OnActivate();
        //    OrderItems = await DataManager.GetOrderItemsAsync();
        //}

        protected async void InitializeData()
        {
            var _Items = await DataManager.GetItemsAsync();
            Items = new BindableCollection<Item>(_Items);

            var _users = await DataManager.GetUsersAsync();

            var _Orders = await DataManager.GetOrdersAsync();

            dg_OrderItems = new BindableCollection<OrderItem>();
            OrderItem OI = new OrderItem();
            OI.Item = Items[0];
            OI.ItemCost = Items[0].Cost;
            OI.ItemNumber = Items[0].ItemNumber;
            OI.Quantity = 1;
            dg_OrderItems.Add(OI);
            //dg_OrderItems.Remove(OI);

            txt_PurchaseDate = DateTime.Now;
            if(_Orders.Count() == 0)
            {
                txt_OrderNumber = 0;
            }
            else
            {
                txt_OrderNumber = (_Orders.Last().OrderNumber + 1);
            }

        }

        public async void SaveToDB()
        {
            User purchaser = new User();
            purchaser.Name = txt_Purchaser;

            foreach (var item in dg_OrderItems)
            {
                item.OrderNumber = txt_OrderNumber;
                txt_OrderTotal += item.ItemCost;
            }

            Order toSave = new Order();
            toSave.DatePlaced = txt_PurchaseDate;
            toSave.OrderNumber = txt_OrderNumber;
            toSave.Purchaser = purchaser;
            toSave.TotalCost = txt_OrderTotal;
            toSave.OrderItems = dg_OrderItems;

            await DataManager.SaveOrderAsync(toSave);

            dg_OrderItems.Clear();

        }
    }
}
