using System;

namespace WindowSettings.Entities.Base
{
    public interface IEntityBase
    {
        Int64 Id { get; set; }

        DateTime CreatedDate { get; set; }

        DateTime? UpdatedDate { get; set; }
    }
}
