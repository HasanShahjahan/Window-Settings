using System;
using System.Collections.Generic;
using System.Text;

namespace WindowSettings.DataObjects.Base
{
    public class BaseDto
    {
        public long Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}