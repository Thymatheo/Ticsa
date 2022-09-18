using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Ticsa.BLL.BS;
using Ticsa.DAL.Models;

namespace Ticsa.ViewModels {
    public class GammesUCVM {
        private const int PARTNER_TYPE_ID = 2;
        public GammesBS GammesBS { get; set; }
        public LotsBS LotsBS { get; set; }
        public PartnersBS PartnersBS { get; set; }
        public ObservableCollection<Gammes?>? Gammes { get; set; }
        public ObservableCollection<Lots?>? Lots { get; set; }
        public ObservableCollection<Partners?>? Partners { get; set; }
        public GammesUCVM() {
            GammesBS = new();
            LotsBS = new();
            PartnersBS = new();
            Task.Run(async () => await LoadData()).Wait();
        }
        public async Task LoadData() {
            await LoadGammes();
            await LoadLots();
            await LoadPartner();
        }
        public async Task LoadPartner() {
            Task<IEnumerable<Partners?>> partners = PartnersBS.GetByIdType(PARTNER_TYPE_ID);
            if (Partners is not null)
                await Partners.Refresh(() => partners);
            else
                Partners = new(await partners);
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
    }
}
