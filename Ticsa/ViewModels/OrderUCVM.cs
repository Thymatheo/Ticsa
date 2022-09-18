using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Ticsa.BLL.BS;
using Ticsa.DAL.Models;

namespace Ticsa.ViewModels {
    internal class OrderUCVM {
        private const int PARTNER_TYPE_ID = 1;
        public GammesBS GammesBS { get; set; }
        public LotsBS LotsBS { get; set; }
        public PartnersBS PartnersBS { get; set; }
        public OrdersBS OrdersBS { get; set; }
        public OrderContentsBS OrderContentsBS { get; set; }
        public ObservableCollection<Gammes?>? Gammes { get; set; }
        public ObservableCollection<Lots?>? Lots { get; set; }
        public ObservableCollection<Partners?>? Partners { get; set; }
        public ObservableCollection<Orders?>? Orders { get; set; }
        public ObservableCollection<OrderContents?>? OrderContents { get; set; }

        public OrderUCVM() {
            GammesBS = new();
            LotsBS = new();
            PartnersBS = new();
            OrdersBS = new();
            OrderContentsBS = new();
            Task.Run(async () => await LoadData()).Wait();
        }

        public async Task LoadData() {
            await LoadGammes();
            await LoadLots();
            await LoadOrders();
            await LoadOrderContents();
            Partners = new(await PartnersBS.GetByIdType(PARTNER_TYPE_ID));
        }

        public async Task LoadGammes() {
            if (Gammes is not null)
                await Gammes.Refresh(() => GammesBS.GetAll());
            else
                Gammes = new(await GammesBS.GetAll());
        }

        public async Task LoadLots(Func<Task<IEnumerable<Lots?>>>? func = null) {
            if (Lots is not null)
                await Lots.Refresh(func ?? (() => LotsBS.GetAll()));
            else
                Lots = new(await LotsBS.GetAll());
        }

        public async Task LoadOrders() {
            if (Orders is not null)
                await Orders.Refresh(() => OrdersBS.GetAll());
            else
                Orders = new(await OrdersBS.GetAll());
        }

        public async Task LoadOrderContents(Func<Task<IEnumerable<OrderContents?>>>? func = null) {
            if (OrderContents is not null)
                await OrderContents.Refresh(func ?? (() => OrderContentsBS.GetAll()));
            else
                OrderContents = new(await OrderContentsBS.GetAll());
        }
    }
}
