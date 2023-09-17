using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using Ticsa.BLL.BS;
using Ticsa.BLL.DTOs;
using Ticsa.DAL.DP;
using Ticsa.DAL.Models;
using Ticsa.Filters;
using Ticsa.Filters.ViewModels;

namespace Ticsa.ViewModels {
    public class GammesUCVM {
        private const int PARTNER_TYPE_ID = 2;
        public GammesBS GammesBS => GammesBS.Instance;
        public LotsBS LotsBS => LotsBS.Instance;
        public PartnersBS PartnersBS => PartnersBS.Instance;
        public PartnerTypesDP PartnerTypesDP => PartnerTypesDP.Instance;
        public FiltrableCollection<GammesDTO?>? Gammes { get; set; }
        public FiltrableCollection<LotsDTO?>? Lots { get; set; }
        public ObservableCollection<PartnersDTO?>? Partners { get; set; }
        public GammesDTO? LastSelectedGamme { get; set; }
        public LotsDTO? LastSelectedLots { get; set; }
        public GammesUCVM() {
            Task.Run(LoadData).Wait();
        }
        public void LoadData() {
            Gammes = new(GammesBS.Gets,
                new StringFilter("Partner", (obj) => ((GammesDTO)obj).Partner!.CompanyName!),
                new StringFilter("Label", (obj) => ((GammesDTO)obj).Label));
            Lots = new(LotsBS.Gets,
                new StringFilter("Gamme", (obj) => ((LotsDTO)obj).Gamme!.Label!),
                new IntFilter("Quantity", (obj) => ((LotsDTO)obj).Quantity),
                new DateFilter("Date de reception", (obj) => ((LotsDTO)obj).EntryDate),
                new DateFilter("Date d'expiration", (obj) => ((LotsDTO)obj).ExpirationDate));
            LoadPartner();
        }
        public void LoadPartner() {
            IEnumerable<PartnersDTO?> partners = PartnersBS.GetByIdType(PartnerTypesDP.GetProducer().Id);
            if (Partners is not null)
                Partners.Refresh<Partners, PartnersDTO>(() => partners);
            else
                Partners = new(partners);
        }
    }
}
