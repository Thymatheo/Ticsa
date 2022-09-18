using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Ticsa.BLL.BS;
using Ticsa.DAL.Models;

namespace Ticsa.ViewModels {
    public class PartnersUCVM {
        public PartnersBS PartnersBS { get; set; }
        public PartnerTypesBS PartnerTypesBS { get; set; }
        public ObservableCollection<Partners?>? Partners { get; set; }
        public ObservableCollection<PartnerTypes?>? PartnerTypes { get; set; }

        public PartnersUCVM() {
            PartnersBS = new();
            PartnerTypesBS = new();
            Task.Run(async () => await LoadData()).Wait();
        }

        public async Task LoadData() {
            await LoadPartner();
            if (PartnerTypes is null) {
                PartnerTypes = new(await PartnerTypesBS.GetAll());
            }
        }
        public async Task LoadPartner() {
            if (Partners is not null)
                await Partners.Refresh(() => PartnersBS.GetAll());
            else
                Partners = new(await PartnersBS.GetAll());
        }
    }
}
