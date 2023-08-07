using Ticsa.DAL.DP;
using Ticsa.DAL.Models;

namespace Ticsa.BLL.DTOs.Interfaces {
    public interface IGammesDependency {
        public Guid IdGamme { get; }
        public Gammes? Gamme { get; set; }
    }
    public static partial class Extention {
        public static void Init(this IGammesDependency gamme, GammesDP gammes) {
            if (gamme.Gamme == null)
                gamme.Gamme = gammes.Get(gamme.IdGamme)!;
        }
    }
}
