using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Ticsa.BLL.BS;
using Ticsa.BLL.DTOs;
using Ticsa.DAL.DP;
using Ticsa.DAL.Models;

namespace Ticsa.ViewModels {
    internal class OrderUCVM : INotifyPropertyChanged {
        private const string CLIENT_TYPE = PartnerTypesDP.CLIENT_TYPE;
        private const string PRODUCER_TYPE = PartnerTypesDP.PRODUCER_TYPE;

        public event PropertyChangedEventHandler? PropertyChanged;
        public GammesBS GammesBS { get; set; }
        public LotsBS LotsBS { get; set; }
        public PartnersBS PartnersBS { get; set; }
        public OrdersBS OrdersBS { get; set; }
        public OrderContentsBS OrderContentsBS { get; set; }
        public DeliveryCouponsBS DeliveryCouponsBS { get; set; }
        public PartnerTypesDP PartnerTypesDP { get; set; }
        public ObservableCollection<GammesDTO?>? Gammes { get; set; }
        public ObservableCollection<LotsDTO?>? Lots { get; set; }
        public ObservableCollection<PartnersDTO?>? Clients { get; set; }
        public ObservableCollection<PartnersDTO?>? Producers { get; set; }
        public ObservableCollection<OrdersDTO?>? Orders { get; set; }
        public ObservableCollection<OrderContentsDTO?>? OrderContents { get; set; }
        public ObservableCollection<DeliveryCouponsDTO?>? DeliveryCoupons { get; set; }
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
            PartnerTypesDP = new();
            _deliveryCouponFileName = null;
            Task.Run(LoadData).Wait();
        }

        public void LoadData() {
            LoadGammes();
            LoadLots();
            LoadOrders();
            LoadOrderContents();
            LoadDeliveryCoupons();
            LoadParteners();
        }

        private void LoadParteners() {
            if (Clients is not null)
                Clients.Refresh<Partners, PartnersDTO>(() => PartnersBS.GetByIdType(PartnerTypesDP.GetClient().Id));
            else
                Clients = new(PartnersBS.GetByIdType(PartnerTypesDP.GetClient().Id));

            if (Producers is not null)
                Producers.Refresh<Partners, PartnersDTO>(() => PartnersBS.GetByIdType(PartnerTypesDP.GetProducer().Id));
            else
                Producers = new(PartnersBS.GetByIdType(PartnerTypesDP.GetProducer().Id));
        }

        public void LoadDeliveryCoupons() {
            if (DeliveryCoupons is not null)
                DeliveryCoupons.Refresh<DeliveryCoupons, DeliveryCouponsDTO>(DeliveryCouponsBS.Gets);
            else
                DeliveryCoupons = new(DeliveryCouponsBS.Gets());
        }

        public void LoadGammes() {
            if (Gammes is not null)
                Gammes.Refresh<Gammes, GammesDTO>(GammesBS.Gets);
            else
                Gammes = new(GammesBS.Gets());
        }

        public void LoadLots(Func<IEnumerable<LotsDTO?>>? func = null) {
            if (Lots is not null)
                Lots.Refresh<Lots, LotsDTO>(func ?? (LotsBS.Gets));
            else
                Lots = new(LotsBS.Gets());
        }

        public void LoadOrders() {
            if (Orders is not null)
                Orders.Refresh<Orders, OrdersDTO>(OrdersBS.Gets);
            else
                Orders = new(OrdersBS.Gets());
        }

        public void LoadOrderContents(Func<IEnumerable<OrderContentsDTO?>>? func = null) {
            if (OrderContents is not null)
                OrderContents.Refresh<OrderContents, OrderContentsDTO>(func ?? (OrderContentsBS.Gets));
            else
                OrderContents = new(OrderContentsBS.Gets());
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
