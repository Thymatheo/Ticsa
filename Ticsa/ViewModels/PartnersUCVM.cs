using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Ticsa.BLL.BS;
using Ticsa.BLL.DTOs;
using Ticsa.DAL.Models;

namespace Ticsa.ViewModels {
    public class PartnersUCVM {
        public PartnersBS PartnersBS { get; set; }
        public PartnerTypesBS PartnerTypesBS { get; set; }
        public ObservableCollection<PartnersDTO?>? Partners { get; set; }
        public ObservableCollection<PartnerTypesDTO?>? PartnerTypes { get; set; }

        public PartnersUCVM() {
            PartnersBS = new();
            PartnerTypesBS = new();
            Task.Run(LoadData).Wait();
        }

        public void LoadData() {
            LoadPartner();
            if (PartnerTypes is null) {
                PartnerTypes = new(PartnerTypesBS.Gets());
            }
        }
        public void LoadPartner() {
            if (Partners is not null)
                Partners.Refresh<Partners, PartnersDTO>(PartnersBS.Gets);
            else
                Partners = new(PartnersBS.Gets());
        }
    }
}
