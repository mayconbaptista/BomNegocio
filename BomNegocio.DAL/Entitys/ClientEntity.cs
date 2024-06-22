using System;

namespace BomNegocio.Domain.Entitys
{
    public class ClientEntity : BaseEntity
    {
        /* 1 .. 1 */
        public int UserId { get; set; }
        public UserEntity? User { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime DeactivationDate { get; set; }

        /* 1 .. N */
        public ICollection<EvaluetionEntity>? Evaluetions { get; set; }
        public ICollection<WisheEntity>? Wishes { get; set; }
    }
}
