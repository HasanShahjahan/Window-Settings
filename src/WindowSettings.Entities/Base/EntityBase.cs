using System;

namespace WindowSettings.Entities.Base
{
    public abstract class EntityBase : IEntityBase
    {
        public Int64 Id { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedDate { get; set; }
    }
}
