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
using Ticsa.Filters;
using Ticsa.Filters.ViewModels;

namespace Ticsa.ViewModels {
    internal class OrderUCVM : INotifyPropertyChanged {
        private const string CLIENT_TYPE = PartnerTypesDP.CLIENT_TYPE;
        private const string PRODUCER_TYPE = PartnerTypesDP.PRODUCER_TYPE;
        public const string ORDER_TAG_FILTER_NAME = "Order Tag";

        public event PropertyChangedEventHandler? PropertyChanged;
        public GammesBS GammesBS => GammesBS.Instance;
        public LotsBS LotsBS => LotsBS.Instance;
        public PartnersBS PartnersBS => PartnersBS.Instance;
        public OrdersBS OrdersBS => OrdersBS.Instance;
        public OrderContentsBS OrderContentsBS => OrderContentsBS.Instance;
        public DeliveryCouponsBS DeliveryCouponsBS => DeliveryCouponsBS.Instance;
        public PartnerTypesDP PartnerTypesDP => PartnerTypesDP.Instance;
        public ObservableCollection<GammesDTO?>? Gammes { get; set; }
        public ObservableCollection<LotsDTO?>? Lots { get; set; }
        public ObservableCollection<PartnersDTO?>? Clients { get; set; }
        public ObservableCollection<PartnersDTO?>? Producers { get; set; }
        public FiltrableCollection<OrdersDTO?>? Orders { get; set; }
        public FiltrableCollection<OrderContentsDTO?>? OrderContents { get; set; }
        public FiltrableCollection<DeliveryCouponsDTO?>? DeliveryCoupons { get; set; }
        public OrdersDTO? LastOrderSelected { get; set; } = null;
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
            _deliveryCouponFileName = null;
            Task.Run(LoadData).Wait();
        }

        public void LoadData() {
            LoadGammes();
            LoadLots();
            OrderContents = new(OrderContentsBS.Gets,
                new StringFilter(ORDER_TAG_FILTER_NAME, (obj) => ((OrderContentsDTO)obj).Order!.OrderTag),
                new DateFilter("Order Date", (obj) => ((OrderContentsDTO)obj).Order!.OrderDate),
                new StringFilter("Lot", (obj) => ((OrderContentsDTO)obj).Lot!.Label));
            Orders = new(OrdersBS.Gets,
                new StringFilter(ORDER_TAG_FILTER_NAME, (obj) => ((OrdersDTO)obj).OrderTag),
                new DateFilter("Order Date", (obj) => ((OrdersDTO)obj).OrderDate),
                new StringFilter("Partner", (obj) => ((OrdersDTO)obj).Partner!.CompanyName));
            DeliveryCoupons = new(DeliveryCouponsBS.Gets,
                new StringFilter(ORDER_TAG_FILTER_NAME, (obj) => ((DeliveryCouponsDTO)obj).Order!.OrderTag),
                new StringFilter("Label", (obj) => ((DeliveryCouponsDTO)obj).Label),
                new StringFilter("Partner", (obj) => ((DeliveryCouponsDTO)obj).Partner!.CompanyName));
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

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
