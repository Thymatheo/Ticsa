using Ticsa.DAL.Models;

namespace Ticsa.BLL.DTOs.Interfaces {
    public interface IDTO<T> where T : StdEntity {
        public T? BaseEntity { get; set; }
    }
    public static partial class Extention {
        public static IDTO<T> Set<T>(this IDTO<T> dto, T entity) where T : StdEntity {
            dto.BaseEntity = entity;
            return dto;
        }
    }
}
