using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Ticsa.BLL.BS;
using Ticsa.BLL.DTOs;
using Ticsa.DAL.DP;
using Ticsa.DAL.Models;

namespace Ticsa.ViewModels {
    public class GammesUCVM {
        private const int PARTNER_TYPE_ID = 2;
        public GammesBS GammesBS { get; set; }
        public LotsBS LotsBS { get; set; }
        public PartnersBS PartnersBS { get; set; }
        public PartnerTypesDP PartnerTypesDP { get; set; }
        public ObservableCollection<GammesDTO?>? Gammes { get; set; }
        public ObservableCollection<LotsDTO?>? Lots { get; set; }
        public ObservableCollection<PartnersDTO?>? Partners { get; set; }
        public GammesUCVM() {
            GammesBS = new();
            LotsBS = new();
            PartnersBS = new();
            PartnerTypesDP = new();
            Task.Run(LoadData).Wait();
        }
        public void LoadData() {
            LoadGammes();
            LoadLots();
            LoadPartner();
        }
        public void LoadPartner() {
            IEnumerable<PartnersDTO?> partners = PartnersBS.GetByIdType(PartnerTypesDP.GetProducer().Id);
            if (Partners is not null)
                Partners.Refresh<Partners, PartnersDTO>(() => partners);
            else
                Partners = new(partners);
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
    }
}
