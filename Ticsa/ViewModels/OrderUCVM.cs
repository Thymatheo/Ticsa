using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Ticsa.BLL.BS;
using Ticsa.DAL.Models;

namespace Ticsa.ViewModels {
    internal class OrderUCVM : INotifyPropertyChanged {
        private const int CLIENT_TYPE_ID = 1;
        private const int PRODUCER_TYPE_ID = 2;

        public event PropertyChangedEventHandler? PropertyChanged;
        public GammesBS GammesBS { get; set; }
        public LotsBS LotsBS { get; set; }
        public PartnersBS PartnersBS { get; set; }
        public OrdersBS OrdersBS { get; set; }
        public OrderContentsBS OrderContentsBS { get; set; }
        public DeliveryCouponsBS DeliveryCouponsBS { get; set; }
        public ObservableCollection<Gammes?>? Gammes { get; set; }
        public ObservableCollection<Lots?>? Lots { get; set; }
        public ObservableCollection<Partners?>? Clients { get; set; }
        public ObservableCollection<Partners?>? Producers { get; set; }
        public ObservableCollection<Orders?>? Orders { get; set; }
        public ObservableCollection<OrderContents?>? OrderContents { get; set; }
        public ObservableCollection<DeliveryCoupons?>? DeliveryCoupons { get; set; }
        private string? _deliveryCouponFileName;
        public string? DeliveryCouponFileName {
            get => _deliveryCouponFileName;
            set {
                if (_deliveryCouponFileName != value) {
                    DeliveryCouponFileNameShort = value!.Split('\\')[^1];
                    _deliveryCouponFileName = value;
                }
            }
        }
        private string? _deliveryCouponFileNameShort;
        public string? DeliveryCouponFileNameShort {
            get => _deliveryCouponFileNameShort;
            set {
                if (_deliveryCouponFileNameShort != value) {
                    _deliveryCouponFileNameShort = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public OrderUCVM() {
            GammesBS = new();
            LotsBS = new();
            PartnersBS = new();
            OrdersBS = new();
            OrderContentsBS = new();
            DeliveryCouponsBS = new();
            _deliveryCouponFileName = null;
            Task.Run(async () => await LoadData()).Wait();
        }

        public async Task LoadData() {
            await LoadGammes();
            await LoadLots();
            await LoadOrders();
            await LoadOrderContents();
            await LoadDeliveryCoupons();
            await LoadParteners();
        }

        private async Task LoadParteners() {
            if (Clients is not null)
                await Clients.Refresh(() => PartnersBS.GetByIdType(CLIENT_TYPE_ID));
            else
                Clients = new(await PartnersBS.GetByIdType(CLIENT_TYPE_ID));

            if (Producers is not null)
                await Producers.Refresh(() => PartnersBS.GetByIdType(PRODUCER_TYPE_ID));
            else
                Producers = new(await PartnersBS.GetByIdType(PRODUCER_TYPE_ID));
        }

        public async Task LoadDeliveryCoupons() {
            if (DeliveryCoupons is not null)
                await DeliveryCoupons.Refresh(() => DeliveryCouponsBS.GetAll());
            else
                DeliveryCoupons = new(await DeliveryCouponsBS.GetAll());
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

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
